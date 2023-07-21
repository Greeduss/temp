

using ServiceStack;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Services;
using ezd.api.App.MODEL.Dto.Api3;
using ezd.api.App.MODEL.Dto.Api3.DTO;
using ezd.api.App.MODEL.Dto;
using ezd.api.App.MODEL.Dto.Api1;
using Services.pobieranie.models;
using Services.utils;


namespace Services.pobieranie
{
    public class PobieranieWplywow_LUW
    {
        JsonServiceClient jsonClient;

        public PobieranieWplywow_LUW()
        {
            jsonClient = new JsonServiceClient();
        }

        private async Task<bool> StworzPolaczenieAPI()
        {
            try
            {
                await Logs.DodajLog("Połączenie EZDPUW API", "Tworzenie połączenia", Program.user_id, 1);
                jsonClient.BaseUri = CustomConfig.URL_API;
                jsonClient.UserName = CustomConfig.LOGIN;
                jsonClient.Password = CustomConfig.PASSWORD;
                await Logs.DodajLog("Połączenie EZDPUW API", "Poprawnie stworzone połączenie", Program.user_id, 1);
                return true;
            }
            catch (Exception ex)
            {
                await Logs.DodajLog("Połączenie EZDPUW API - błąd", ex.Message + "\r\n" + ex.StackTrace, Program.user_id, 2);
                return false;
            }
        }

        public async Task<PobierzDokumenty_flag> RozpocznijProcesPobieraniaAwaryjnego(DateTime dataRozpoczeciaPobierania)
        {

            int zapisanePisma = 0;
            StringBuilder pisma = new StringBuilder();
            bool polaczenieStworzone = await StworzPolaczenieAPI();
            if (!polaczenieStworzone)
                return PobierzDokumenty_flag.BłądPobierania;
            List<PismoModel> lista_ePism = new List<PismoModel>();

            await Logs.DodajLog("Pobieranie wpływów z EZDPUW", "Rozpoczęcie procesu pobierania wpływów ePUAP", Program.user_id, 1);
            PobierzOznaczoneDokumentyResponse pobierzOznaczoneDokumenty = jsonClient.Post(new PobierzOznaczoneDokumenty()
            {
                Oznaczenie = CustomConfig.OZNACZENIE_DOKUMENTU,
                DataOznaczeniaOd = dataRozpoczeciaPobierania.ToString("yyyy-MM-dd"),
                DataOznaczeniaDo = DateTime.Now.AddDays(1).ToString("yyyy-MM-dd")
            });
            //powyższy kod celowo jest ominięty przez try-catch w celu wyłapania błędów w pobieraniu przez nadrzędny try-catch
            //poniższy try-catch służy do wyłapania błędów i wycofania pobierania plików jako 'transakcji'

            try
            {
                if (pobierzOznaczoneDokumenty.DokumentyOznaczone.Count > 0)
                {
                    foreach (DokumentOznaczonyDto dokument in pobierzOznaczoneDokumenty.DokumentyOznaczone)
                    {
                        string pismo = "Dane dokumentu - IdDokumentu: " + dokument.DokumentId + ", IdAdresata: " + dokument.AdresatId + ", IdKoszulki: " + dokument.KoszulkaId;
                        await Logs.DodajLog("Pobrano dokument oznaczony", pismo, Program.user_id, 1);
                        PismoModel ePismo = new PismoModel
                        {
                            IdPisma = dokument.DokumentId,
                            zalacznikiPisma = dokument.ZalacznikiEpisma,
                            IdAdresat = dokument.AdresatId,
                            IdKoszulki = dokument.KoszulkaId
                        };
                        lista_ePism.Add(ePismo);
                    }

                    foreach (PismoModel pismo in lista_ePism)
                    {
                        if (zapisanePisma > 10)
                            break;
                        string idEpuap = await PobierzIDAdresataWplywuePUAP(pismo.IdAdresat);
                        string nazwaKoszulki = await PobierzNazweKoszulki(pismo.IdKoszulki);
                        foreach (var zalacznik in pismo.zalacznikiPisma)
                        {
                            long idZalacznika = zalacznik.Key;
                            Tuple<bool, string> zapisanoDokument = await ZapiszDokument(idZalacznika, pismo.IdKoszulki, idEpuap, nazwaKoszulki);
                            //pismo.ZapisZalacznikow.Add(zapisanoDokument.Item1, zapisanoDokument.Item2);
                        }
                        pismo.ZapisanoNaDysku = true;
                        await Logs.DodajLog("Pismo dodane", "Pismo: " + pismo.IdPisma + ", dodano do listy pism do oznaczenia", Program.user_id, 1);
                        pisma.AppendLine(pismo.IdPisma.ToString() + ',');
                        zapisanePisma++;
                    }
                    string sciezkaPisma = Path.Combine(CustomConfig.folderGlowny, "pisma.txt");
                    await Logs.DodajLog("Poberanie awaryjne", "Pobrano 10 wpływów, zapisuję IdDokumentów do pliku: " + sciezkaPisma, Program.user_id, 1);
                    File.WriteAllText(sciezkaPisma, pisma.ToString());
                   Console.WriteLine("Zapisano pisma");

                    await Logs.DodajLog("Pobieranie wpływów z EZDPUW", "Pliki zostały zapisane na dysku w folderze docelowym", Program.user_id, 1);
                    return PobierzDokumenty_flag.PobranoRaporty;
                }
                else
                {
                    await Logs.DodajLog("Pobieranie wpływów z EZDPUW", "Brak oznaczonych plików do pobrania", Program.user_id, 1);
                    return PobierzDokumenty_flag.BrakRaportówDoPobrania;
                }
            }
            catch (Exception ex)
            {
                await Logs.DodajLog("Błąd w pobieraniu plików", ex.Message + "-__-" + ex.StackTrace, Program.user_id, 2);

                return PobierzDokumenty_flag.BłądPobierania;
            }
        }
        public async Task<PobierzDokumenty_flag> RozpocznijProcesPobierania(DateTime dataRozpoczeciaPobierania)
        {
            bool polaczenieStworzone = await StworzPolaczenieAPI();
            if (!polaczenieStworzone)
                return PobierzDokumenty_flag.BłądPobierania;
            List<PismoModel> lista_ePism = new List<PismoModel>();

            await Logs.DodajLog("Pobieranie wpływów z EZDPUW", "Rozpoczęcie procesu pobierania wpływów ePUAP", Program.user_id, 1);
            PobierzOznaczoneDokumentyResponse pobierzOznaczoneDokumenty = jsonClient.Post(new PobierzOznaczoneDokumenty()
            {
                Oznaczenie = CustomConfig.OZNACZENIE_DOKUMENTU,
                DataOznaczeniaOd = dataRozpoczeciaPobierania.ToString("yyyy-MM-dd"),
                DataOznaczeniaDo = DateTime.Now.AddDays(1).ToString("yyyy-MM-dd")
            });
            //powyższy kod celowo jest ominięty przez try-catch w celu wyłapania błędów w pobieraniu przez nadrzędny try-catch
            //poniższy try-catch służy do wyłapania błędów i wycofania pobierania plików jako 'transakcji'

            try
            {
                if (pobierzOznaczoneDokumenty.DokumentyOznaczone.Count > 0)
                {
                    foreach (DokumentOznaczonyDto dokument in pobierzOznaczoneDokumenty.DokumentyOznaczone)
                    {
                        PismoModel ePismo = new PismoModel
                        {
                            IdPisma = dokument.DokumentId,
                            zalacznikiPisma = dokument.ZalacznikiEpisma,
                            IdAdresat = dokument.AdresatId,
                            IdKoszulki = dokument.KoszulkaId
                        };
                        lista_ePism.Add(ePismo);
                    }

                    foreach (PismoModel pismo in lista_ePism)
                    {
                        string idEpuap = await PobierzIDAdresataWplywuePUAP(pismo.IdAdresat);
                        string nazwaKoszulki = await PobierzNazweKoszulki(pismo.IdKoszulki);
                        foreach (var zalacznik in pismo.zalacznikiPisma)
                        {
                            long idZalacznika = zalacznik.Key;
                            Tuple<bool, string> zapisanoDokument = await ZapiszDokument(idZalacznika, pismo.IdKoszulki, idEpuap, nazwaKoszulki);
                            // pismo.ZapisZalacznikow.Add(zapisanoDokument.Item1, zapisanoDokument.Item2);
                        }
                        pismo.ZapisanoNaDysku = true;
                    }
                    foreach (PismoModel pismo in lista_ePism)
                    {
                        if (pismo.ZapisanoNaDysku)
                        {
                            await OznaczPismo(pismo.IdPisma);
                            pismo.OznaczonoJakoPobrane = true;
                            if (Program.ZakańczanieKoszulek)
                                await ZakonczKoszulke(pismo.IdKoszulki);
                        }
                    }
                    await Logs.DodajLog("Pobieranie wpływów z EZDPUW", "Pliki zostały zapisane na dysku w folderze docelowym", Program.user_id, 1);
                    return PobierzDokumenty_flag.PobranoRaporty;
                }
                else
                {
                    await Logs.DodajLog("Pobieranie wpływów z EZDPUW", "Brak oznaczonych plików do pobrania", Program.user_id, 1);
                    return PobierzDokumenty_flag.BrakRaportówDoPobrania;
                }
            }
            catch (Exception ex)
            {
                await Logs.DodajLog("Błąd w pobieraniu plików", ex.Message + ";__;" + ex.StackTrace, Program.user_id, 2);

                return PobierzDokumenty_flag.BłądPobierania;
            }
        }
        private async Task UsunPobranyPlik(string sciezkaPliku)
        {
            if (File.Exists(sciezkaPliku))
                File.Delete(sciezkaPliku);
            await Logs.DodajLog("Usuwanie pliku", "Usunięto plik: " + sciezkaPliku, Program.user_id, 1);
        }

        private async Task<Tuple<bool, string>> ZapiszDokument(long IdDokumentu, int IdKoszulki, string IdEpuap, string nazwaKoszulki)
        {
            string sciezkaDoZapisu = string.Empty;
            string nazwaFolderuWplyw = IdEpuap + "_" + IdKoszulki;

            try
            {
                DokumentPobierzResponse dokument = jsonClient.Post(new DokumentPobierz()
                {
                    DokumentId = IdDokumentu
                });
                await Logs.DodajLog("Zapisywanie dokumentu na dysku", "Rozpoczęto pobieranie i zapisywanie załącznika: " + dokument.NazwaDokumentu + "; " + dokument.IdZalacznika, Program.user_id, 1);

                string sciezka = Path.Combine(CustomConfig.folderRaporty, nazwaKoszulki, CustomConfig.folderPlikiRaportu_nazwa, nazwaFolderuWplyw);
                string nazwaDokument = dokument.NazwaDokumentu;
                sciezkaDoZapisu = Path.Combine(sciezka, nazwaDokument);

                if (sciezkaDoZapisu.Length > CustomConfig.MAX_PATH_LENGTH)
                {
                    await Logs.DodajLog("Błąd zapisu dokumentu o ID " + IdDokumentu + ", wpływ: " + IdEpuap + "_" + IdKoszulki,
                        "Nazwa ścieżki zapisu jest za długa, prawdopodobnie nazwa koszulki w EZD PUW jest zbyt długa, ścieżka: " + sciezkaDoZapisu, Program.user_id, 2);
                    string nowaNazwaKoszulka = "UNKNOWN";
                    string nowaSciezka = Path.Combine(CustomConfig.folderRaporty, nowaNazwaKoszulka, CustomConfig.folderPlikiRaportu_nazwa, nazwaFolderuWplyw);
                    await Logs.DodajLog("Błąd zapisu dokumentu o ID " + IdDokumentu, "Z powodu zbyt długiej ścieżki zapisu, zostanie ona skrócona, nowa ścieżka zapisu: " + nowaSciezka, Program.user_id, 1);
                }

                if (!File.Exists(sciezkaDoZapisu))
                {
                    Directory.CreateDirectory(sciezka);
                    File.WriteAllBytes(sciezkaDoZapisu, dokument.Zawartosc);
                }
                await Logs.DodajLog("Zapisywanie dokumentu na dysku", "Dokument został zapisany na dysku: " + sciezkaDoZapisu, Program.user_id, 1);
                return new Tuple<bool, string>(true, sciezkaDoZapisu);
            }
            catch (Exception ex)
            {
                await Logs.DodajLog("Błąd zapisu dokumentu o ID " + IdDokumentu, ex.Message + "\r\n" + ex.StackTrace, Program.user_id, 2);
                return new Tuple<bool, string>(false, sciezkaDoZapisu);
            }
        }

        private async Task<string> PobierzNazweKoszulki(int idKoszulki)
        {
            string nazwaKoszulki = "";
            try
            {
                await Logs.DodajLog("Pobieranie nazwy koszulki", "Rozpoczęcie pobierania nazwy koszulki", Program.user_id, 1);
                var koszulka = new WskazanieKoszulkiDto
                {
                    IdKoszulki = idKoszulki
                };
                PobierzKoszulkeResponse koszulkaPobrana = jsonClient.Post(new PobierzKoszulke()
                {
                    Koszulka = koszulka
                });
                nazwaKoszulki = koszulkaPobrana.Pismo.Nazwa.Substring(0, koszulkaPobrana.Pismo.Nazwa.Length - 8);
                await Logs.DodajLog("Nazwa koszulki(tytuł ePUAP) pobrana", "Pobrano nazwę koszulki o ID: " + idKoszulki + ",nazwa: " + nazwaKoszulki, Program.user_id, 1);

            }
            catch (Exception ex)
            {
                await Logs.DodajLog("Błąd pobierania nazwy koszulki (tytułu ePUAP)", ex.Message + "\r\n" + ex.StackTrace, Program.user_id, 2);
            }
            return nazwaKoszulki.Trim();
        }

        private async Task<string> PobierzIDAdresataWplywuePUAP(int IdAdresata)
        {
            string nazwaAdresata = "identyfiaktor_nieznany";
            try
            {
                await Logs.DodajLog("Pobierania adresata", "Pobieranie adresata o id: " + IdAdresata, Program.user_id, 1);
                AdresatPobierzResponse response = jsonClient.Post(new AdresatPobierz()
                {
                    IdAdresata = IdAdresata
                });

                if (response.ResultStatus == 1)
                {
                    await Logs.DodajLog("Pobierania adresata", "Adresat pobrany: " + response.AdresAdresatDto.IdentyfikatorEpuap, Program.user_id, 1);
                    string[] idEpuap = response.AdresAdresatDto.AdresOdpowiedziEpuap.Split('/');
                    nazwaAdresata = idEpuap[1];
                    //return nazwaAdresata;
                }
            }
            catch (Exception ex)
            {
                await Logs.DodajLog("Błąd pobierania adresata: " + IdAdresata, ex.Message + "\r\n" + ex.StackTrace, Program.user_id, 2);
            }
            return nazwaAdresata;
        }
        private async Task ZakonczKoszulke(int IdKoszulki)
        {
            try
            {
                await Logs.DodajLog("Zakańczanie koszulki", "Rozpoczęto zakańczanie koszulki o id: " + IdKoszulki.ToString(), Program.user_id, 1);
                ZakonczKoszulkeResponse zakoncz = jsonClient.Post(new ZakonczKoszulke()
                {
                    IdKoszulki = IdKoszulki,
                    ZwykleZakonczenie = true
                });
                await Logs.DodajLog("Zakańczanie koszulki", "Zakończono koszulkę: " + IdKoszulki.ToString(), Program.user_id, 1);
            }
            catch (Exception ex)
            {
                await Logs.DodajLog("Błąd zakańczania koszulki: " + IdKoszulki, ex.Message + "\r\n" + ex.StackTrace, Program.user_id, 2);
            }
        }

        private async Task OznaczPismo(long IdPisma)
        {
            try
            {
                DokumentPobierzResponse dokumentPobierzReq = jsonClient.Post(new DokumentPobierz
                {
                    DokumentId = IdPisma,
                    Oznaczenie = CustomConfig.OZNACZENIE_DOKUMENTU
                });
                await Logs.DodajLog("Załącznik został oznaczony jako pobrany", "Załącznik został oznaczony jako pobrany", Program.user_id, 1);

            }
            catch (Exception ex)
            {
                await Logs.DodajLog("Błąd podczas oznaczania dokumentów", ex.Message + "\r\n" + ex.StackTrace, Program.user_id, 2);
            }
        }



    }
}


