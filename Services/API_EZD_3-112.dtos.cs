/* Options:
Date: 2023-02-10 10:44:18
Version: 4,052
Tip: To override a DTO option, remove "//" prefix before updating
BaseUrl: https://ezd-szkolenie2-api.blizej.eu

//GlobalNamespace: 
//MakePartial: True
//MakeVirtual: True
//MakeDataContractsExtensible: False
//AddReturnMarker: True
//AddDescriptionAsComments: True
//AddDataContractAttributes: False
//AddIndexesToDataMembers: False
//AddGeneratedCodeAttributes: False
//AddResponseStatus: False
//AddImplicitVersion: 
//InitializeCollections: True
//IncludeTypes: 
//ExcludeTypes: 
//AddDefaultXmlNamespace: http://schemas.servicestack.net/types
*/

using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using ServiceStack;
using ServiceStack.DataAnnotations;
using ezd.api.App.MODEL;
using ezd.api.App.MODEL.Dto.Api3.DTO;
using ezd.api.App.MODEL.Dto;
using ezd.Data.Integration;
using ezd.Data.Domain;
using ezd.Data.Enums;
using ezd.api.App.MODEL.Dto.Api1;
using ezd.api.App.MODEL.Dto.Api3;


namespace ezd.api.App.MODEL
{

    [DataContract]
    public partial class RequestBaseDto
    {
        [DataMember]
        [ApiMember(Description = "Wymagany do procesowości")]
        public virtual int CID { get; set; }

        [DataMember]
        [ApiMember(Description = "Multi use Id Request base")]
        public virtual int IdPracownikaWlasciciela { get; set; }

        [DataMember]
        [ApiMember(Description = "Multi use Id Request base")]
        public virtual int IdStanowiskaWlasciciela { get; set; }
    }

    [DataContract]
    public partial class ResponseBaseDto
    {
        [DataMember]
        public virtual int ResultStatus { get; set; }

        [DataMember]
        public virtual string ResultMessage { get; set; }

        [DataMember]
        public virtual int CID { get; set; }

        [DataMember]
        public virtual string Token { get; set; }

        [DataMember]
        public virtual string Odpowiedz { get; set; }

        [DataMember]
        public virtual string TypOdpowiedzi { get; set; }
    }
}

namespace ezd.api.App.MODEL.Dto
{

    [Route("/Addin/AddinPobierzIdentyfikatoryDokumentowDoDruku", "POST")]
    [Route("/ad/Addin/AddinPobierzIdentyfikatoryDokumentowDoDruku", "POST")]
    [DataContract]
    public partial class AddinPobierzIdentyfikatoryDokumentowDoDruku
        : RequestBaseDto, IReturn<AddinPobierzIdentyfikatoryDokumentowDoDrukuResponse>
    {
        [DataMember]
        public virtual string PrintToken { get; set; }
    }

    [DataContract]
    public partial class AddinPobierzIdentyfikatoryDokumentowDoDrukuResponse
        : ResponseBaseDto
    {
        public AddinPobierzIdentyfikatoryDokumentowDoDrukuResponse()
        {
            IdZalocznikow = new List<long> { };
        }

        [DataMember]
        public virtual List<long> IdZalocznikow { get; set; }
    }

    [Route("/Addin/AddinPobierzZalcznikDoDruku", "POST")]
    [Route("/ad/Addin/AddinPobierzZalcznikDoDruku", "POST")]
    [DataContract]
    public partial class AddinPobierzZalcznikDoDruku
        : RequestBaseDto, IReturn<AddinPobierzZalcznikDoDrukuResponse>
    {
        [DataMember]
        public virtual string PrintToken { get; set; }

        [DataMember]
        public virtual long IdDokumentu { get; set; }
    }

    [DataContract]
    public partial class AddinPobierzZalcznikDoDrukuResponse
        : ResponseBaseDto
    {
        public AddinPobierzZalcznikDoDrukuResponse()
        {
            Bytes = new byte[] { };
        }

        [DataMember]
        public virtual byte[] Bytes { get; set; }

        [DataMember]
        public virtual string NazwaZalcznika { get; set; }
    }

    [Route("/Addin/AddinUtworzTokenDoDruku", "POST")]
    [Route("/ad/Addin/AddinUtworzTokenDoDruku", "POST")]
    [DataContract]
    public partial class AddinUtworzTokenDoDruku
        : RequestBaseDto, IReturn<AddinUtworzTokenDoDrukuResponse>
    {
        [DataMember]
        public virtual int IdKoszulki { get; set; }
    }

    [DataContract]
    public partial class AddinUtworzTokenDoDrukuResponse
        : ResponseBaseDto
    {
    }

    [Route("/Addin/AddinUtworzTokenEdycjiPliku", "POST")]
    [Route("/ad/Addin/AddinUtworzTokenEdycjiPliku", "POST")]
    [DataContract]
    public partial class AddinUtworzTokenEdycjiPliku
        : RequestBaseDto, IReturn<AddinUtworzTokenEdycjiPlikuResponse>
    {
        [DataMember]
        public virtual long IdDokumentu { get; set; }

        [DataMember]
        public virtual int IdZalacznika { get; set; }
    }

    [DataContract]
    public partial class AddinUtworzTokenEdycjiPlikuResponse
        : ResponseBaseDto
    {
    }

    [Route("/api3/AdresatDodaj", "POST")]
    [Route("/ad/api3/AdresatDodaj", "POST")]
    [DataContract]
    public partial class AdresatDodaj
        : RequestBaseDto, IReturn<AdresatDodajResponse>
    {
        [DataMember]
        public virtual string Imie { get; set; }

        [DataMember]
        public virtual string Nazwisko { get; set; }

        [DataMember]
        public virtual string Nazwa { get; set; }

        [DataMember]
        public virtual string IdentyfikatorEpuap { get; set; }

        [DataMember]
        public virtual string AdresOdpowiedziEpuap { get; set; }

        [DataMember]
        public virtual string NIP { get; set; }

        [DataMember]
        public virtual string REGON { get; set; }

        [DataMember]
        public virtual string PESEL { get; set; }

        [DataMember]
        public virtual string AdresEmail { get; set; }

        [DataMember]
        public virtual string Atrybut1 { get; set; }

        [DataMember]
        public virtual string Atrybut2 { get; set; }

        [DataMember]
        public virtual string Atrybut3 { get; set; }

        [DataMember]
        public virtual string Atrybut4 { get; set; }

        [DataMember]
        public virtual string Atrybut5 { get; set; }

        [DataMember]
        public virtual string Atrybut6 { get; set; }

        [DataMember]
        public virtual string Atrybut7 { get; set; }

        [DataMember]
        public virtual string Atrybut8 { get; set; }

        [DataMember]
        public virtual string Atrybut9 { get; set; }

        [DataMember]
        public virtual string Atrybut10 { get; set; }

        [DataMember]
        public virtual string Typ { get; set; }

        [DataMember]
        public virtual bool Blokada { get; set; }

        [DataMember]
        public virtual string Miejscowosc { get; set; }

        [DataMember]
        public virtual string Ulica { get; set; }

        [DataMember]
        public virtual string KodPocztowy { get; set; }

        [DataMember]
        public virtual string Poczta { get; set; }

        [DataMember]
        public virtual string Kraj { get; set; }

        [DataMember]
        public virtual string NumerBudynku { get; set; }

        [DataMember]
        public virtual string NumerLokalu { get; set; }

        [DataMember]
        public virtual string SkrytkaPocztowa { get; set; }
    }

    [DataContract]
    public partial class AdresatDodajResponse
        : ResponseBaseDto
    {
        [DataMember]
        public virtual int IdAdresata { get; set; }

        [DataMember]
        public virtual int IdAdres { get; set; }

        [DataMember]
        public virtual int IdAdresataOriginal { get; set; }

        [DataMember]
        public virtual int IdAdresOriginal { get; set; }
    }

    [Route("/api3/AdresatPobierz", "POST")]
    [Route("/ad/api3/AdresatPobierz", "POST")]
    [DataContract]
    public partial class AdresatPobierz
        : RequestBaseDto, IReturn<AdresatPobierzResponse>
    {
        [DataMember]
        public virtual int IdAdresata { get; set; }

        [DataMember]
        public virtual int IdAdresu { get; set; }
    }

    [DataContract]
    public partial class AdresatPobierzResponse
        : ResponseBaseDto
    {
        [DataMember]
        public virtual AdresatPelnyDto AdresAdresatDto { get; set; }
    }

    [Route("/api3/AktualizujKoszulke", "POST")]
    [Route("/ad/api3/AktualizujKoszulke", "POST")]
    [Route("/Koszuka/AktualizujKoszulke", "POST")]
    [Route("/ad/Koszuka/AktualizujKoszulke", "POST")]
    [DataContract]
    public partial class AktualizujKoszulke
        : RequestBaseDto, IReturn<AktualizujKoszulkeResponse>
    {
        [DataMember]
        public virtual PismoDto koszulka { get; set; }
    }

    [DataContract]
    public partial class AktualizujKoszulkeResponse
        : ResponseBaseDto
    {
        [DataMember]
        public virtual PismoDto koszulka { get; set; }
    }

    ///<summary>
    ///Operacje na załącznikach
    ///</summary>
    [Route("/Zalacznik/AktualizujZalacznik", "POST")]
    [Route("/ad/Zalacznik/AktualizujZalacznik", "POST")]
    [Api("Operacje na załącznikach")]
    [DataContract]
    public partial class AktualizujZalacznik
        : RequestBaseDto, IReturn<AktualizujZalacznikResponse>
    {
        public AktualizujZalacznik()
        {
            Dane = new byte[] { };
        }

        [DataMember]
        [ApiMember(Description = "Binarne dane załącznika")]
        public virtual byte[] Dane { get; set; }

        [DataMember]
        [ApiMember(Description = "Id dokumentu")]
        public virtual long IdDokumentu { get; set; }
    }

    [DataContract]
    public partial class AktualizujZalacznikResponse
        : ResponseBaseDto
    {
        [DataMember]
        public virtual int IdZawartosci { get; set; }
    }

    public partial class CzynnoscMetrykiSprawyDto
    {
        public virtual int IdPisma { get; set; }
        public virtual string Pracownik { get; set; }
        public virtual string Zdarzenie { get; set; }
        public virtual string IdentyfikatorDokumentu { get; set; }
        public virtual DateTime DataZdarzenia { get; set; }
    }

    [Route("/Pracownik/DodajPracownika", "POST")]
    [Route("/ad/Pracownik/DodajPracownika", "POST")]
    [DataContract]
    public partial class DodajPracownika
        : RequestBaseDto, IReturn<DodajPracownikaResponse>
    {
        [DataMember]
        public virtual string Imie { get; set; }

        [DataMember]
        public virtual string Nazwisko { get; set; }

        [DataMember]
        public virtual string Inicjaly { get; set; }

        [DataMember]
        public virtual string Stanowisko { get; set; }

        [DataMember]
        public virtual int IdJednostki { get; set; }

        [DataMember]
        public virtual int? IdWydzialu { get; set; }

        [DataMember]
        public virtual bool ZmienHaslo { get; set; }

        [DataMember]
        public virtual bool Ukryty { get; set; }

        [DataMember]
        public virtual string Login { get; set; }

        [DataMember]
        public virtual string Haslo { get; set; }

        [DataMember]
        public virtual string ActiveDirectory { get; set; }

        [DataMember]
        public virtual string Email { get; set; }

        [DataMember]
        public virtual int? SortOrder { get; set; }

        [DataMember]
        public virtual DateTime? WazneDo { get; set; }

        [DataMember]
        public virtual string Atrybut1 { get; set; }

        [DataMember]
        public virtual string Atrybut2 { get; set; }

        [DataMember]
        public virtual string Atrybut3 { get; set; }

        [DataMember]
        public virtual string Atrybut4 { get; set; }

        [DataMember]
        public virtual string Atrybut5 { get; set; }

        [DataMember]
        public virtual string Atrybut6 { get; set; }
    }

    [DataContract]
    public partial class DodajPracownikaResponse
        : ResponseBaseDto
    {
        [DataMember]
        public virtual int IdPracownika { get; set; }

        [DataMember]
        public virtual int IdStanowiska { get; set; }
    }

    ///<summary>
    ///Operacje na załącznikach
    ///</summary>
    [Route("/Zalacznik/DodajZalcznik", "POST")]
    [Route("/ad/Zalacznik/DodajZalcznik", "POST")]
    [Api("Operacje na załącznikach")]
    [DataContract]
    public partial class DodajZalacznik
        : RequestBaseDto, IReturn<DodajZalacznikResponse>
    {
        public DodajZalacznik()
        {
            Dane = new byte[] { };
        }

        [DataMember]
        [ApiMember(Description = "Binarne dane załącznika")]
        public virtual byte[] Dane { get; set; }

        [DataMember]
        [ApiMember(Description = "Nazwa pliku z rozszerzeniem")]
        public virtual string Nazwa { get; set; }

        [DataMember]
        public virtual string DaneBase64 { get; set; }
    }

    [DataContract]
    public partial class DodajZalacznikResponse
        : ResponseBaseDto
    {
        public DodajZalacznikResponse()
        {
            Lokalizacja = new ZalacznikLokalizacjaDto[] { };
        }

        [DataMember]
        public virtual int ContentId { get; set; }

        [DataMember]
        public virtual string Nazwa { get; set; }

        [DataMember]
        public virtual ZalacznikLokalizacjaDto[] Lokalizacja { get; set; }
    }

    [DataContract(Name = "DokumentAkceptacjaDto")]
    public partial class DokumentAkceptacjaDto
    {
        [DataMember]
        public virtual int IdPisma { get; set; }

        [DataMember]
        public virtual long IdDokumentu { get; set; }

        [DataMember]
        public virtual int? IdZawartosci { get; set; }

        [DataMember]
        public virtual string Wersja { get; set; }

        [DataMember]
        public virtual DateTime DataAkceptacji { get; set; }

        [DataMember]
        public virtual int IdStanowiska { get; set; }

        [DataMember]
        public virtual int IdPracownika { get; set; }

        [DataMember]
        public virtual bool CzyAkceptacja { get; set; }

        [DataMember]
        public virtual IList<Security_RoleOrganizacyjne> Role { get; set; }
    }

    [DataContract(Name = "DokumentDto")]
    public partial class DokumentDto
        : ResponseBaseDto
    {
        public DokumentDto()
        {
            Akceptacje = new List<DokumentAkceptacjaDto> { };
            Powiazania = new List<PowiazaniaPismaDto> { };
        }

        [DataMember]
        public virtual long ID { get; set; }

        [DataMember]
        public virtual int IdPisma { get; set; }

        [DataMember]
        public virtual int TypDokumentu { get; set; }

        [DataMember]
        public virtual int RodzajDokumentu { get; set; }

        [DataMember]
        public virtual int? IdZawartosci { get; set; }

        [DataMember]
        public virtual string Nazwa { get; set; }

        [DataMember]
        public virtual DateTime DataUtworzenia { get; set; }

        [DataMember]
        public virtual PobierzPracownikaResponse UtworzeniePracownik { get; set; }

        [DataMember]
        public virtual int UtworzenieIdPracownika { get; set; }

        [DataMember]
        public virtual string PodpisSubject { get; set; }

        [DataMember]
        public virtual DateTime DataPodpisu { get; set; }

        [DataMember]
        public virtual List<DokumentAkceptacjaDto> Akceptacje { get; set; }

        [DataMember]
        public virtual List<PowiazaniaPismaDto> Powiazania { get; set; }
    }

    [Route("/Dokument/Lokalizacja", "POST")]
    [Route("/ad/Dokument/Lokalizacja", "POST")]
    [DataContract]
    public partial class DokumentLokalizacja
        : RequestBaseDto, IReturn<DokumentLokalizacjaResponse>
    {
        [DataMember]
        public virtual LokalizacjaDokumentuTypeDto lokalizacja { get; set; }

        [DataMember]
        public virtual int Identyfikator { get; set; }

        [DataMember]
        public virtual string IdentyfikatorDokumentu { get; set; }
    }

    [DataContract]
    public partial class DokumentLokalizacjaResponse
        : ResponseBaseDto
    {
        [DataMember]
        public virtual long IdDokumentu { get; set; }
    }

    ///<summary>
    ///Import paczki migracyjnej
    ///</summary>
    [Route("/PaczkaMigracyjna/ImportujPaczkeMigracyjna", "POST")]
    [Route("/ad/PaczkaMigracyjna/ImportujPaczkeMigracyjna", "POST")]
    [Api("Import paczki migracyjnej")]
    [DataContract]
    public partial class ImportujPaczkeMigracyjnaRequest
        : RequestBaseDto, IReturn<ImportujPaczkeMigracyjnaResponse>
    {
        public ImportujPaczkeMigracyjnaRequest()
        {
            Dane = new byte[] { };
        }

        [DataMember]
        [ApiMember(Description = "Binarne dane załącznika")]
        public virtual byte[] Dane { get; set; }

        [DataMember]
        [ApiMember(Description = "Nazwa pliku paczki z rozszerzeniem")]
        public virtual string Nazwa { get; set; }
    }

    [DataContract]
    public partial class ImportujPaczkeMigracyjnaResponse
        : ResponseBaseDto
    {
        [DataMember]
        public virtual string Informacja { get; set; }
    }

    [DataContract]
    public partial class InstalacjaDto
    {
        [DataMember]
        public virtual string Nazwa { get; set; }

        [DataMember]
        public virtual string ApiUri { get; set; }
    }

    [DataContract]
    public partial class JednostkaDto
        : ResponseBaseDto
    {
        [DataMember]
        public virtual int ID { get; set; }

        [DataMember]
        public virtual string Nazwa { get; set; }

        [DataMember]
        public virtual string Opis { get; set; }

        [DataMember]
        public virtual string Symbol { get; set; }

        [DataMember]
        public virtual bool Aktywny { get; set; }

        [DataMember]
        public virtual int SortOrder { get; set; }

        [DataMember]
        public virtual DateTime DataDodania { get; set; }

        [DataMember]
        public virtual int? IdNadrzedne { get; set; }

        [DataMember]
        public virtual int? IdPoprzedniego { get; set; }

        [DataMember]
        public virtual int IdTypJednostki { get; set; }

        [DataMember]
        public virtual int? IdWydzialu { get; set; }

        [DataMember]
        public virtual int? IdWydzialuOrginal { get; set; }

        [DataMember]
        public virtual string Atrybut1 { get; set; }

        [DataMember]
        public virtual string Atrybut2 { get; set; }

        [DataMember]
        public virtual string Atrybut3 { get; set; }
    }

    ///<summary>
    ///RWA
    ///</summary>
    [Route("/Rwa/KolejnyNumerTeczkiRWA/{Rwa}/{Rocznik}/{JednostkaIdOryginal}/{idPracownika}", "POST")]
    [Route("/ad/Rwa/KolejnyNumerTeczkiRWA/{Rwa}/{Rocznik}/{JednostkaIdOryginal}/{idPracownika}", "POST")]
    [Route("/Rwa/KolejnyNumerTeczkiRWA/{Rwa}/{JednostkaIdOryginal}/{idPracownika}", "POST")]
    [Route("/ad/Rwa/KolejnyNumerTeczkiRWA/{Rwa}/{JednostkaIdOryginal}/{idPracownika}", "POST")]
    [Route("/Api3/KolejnyNumerTeczkiRWA")]
    [Route("/ad/Api3/KolejnyNumerTeczkiRWA")]
    [Api("RWA")]
    [DataContract]
    public partial class KolejnyNumerTeczkiRwa
        : RequestBaseDto, IReturn<KolejnyNumerTeczkiRwaResponse>
    {
        [DataMember]
        [ApiMember(Description = "RWA")]
        public virtual string Rwa { get; set; }

        [DataMember]
        [ApiMember(Description = "Rocznik")]
        public virtual int? Rocznik { get; set; }

        [DataMember]
        [ApiMember(Description = "Id jednostki (orginał)")]
        public virtual int JednostkaIdOryginal { get; set; }

        [DataMember]
        [ApiMember(Description = "Id pracownika")]
        public virtual int IdPracownika { get; set; }
    }

    [DataContract]
    public partial class KolejnyNumerTeczkiRwaResponse
        : ResponseBaseDto
    {
        [DataMember]
        public virtual int? lp { get; set; }
    }

    [Route("/koszulka/ListaDokumentow", "POST")]
    [Route("/ad/koszulka/ListaDokumentow", "POST")]
    [DataContract]
    public partial class KoszulkaListaDokumentow
        : RequestBaseDto, IReturn<KoszulkaListaDokumentowResponse>
    {
        [DataMember]
        public virtual int IdKoszulki { get; set; }

        [DataMember]
        public virtual int IdSprawy { get; set; }

        [DataMember]
        public virtual string ZnakSprawy { get; set; }
    }

    [DataContract]
    public partial class KoszulkaListaDokumentowResponse
        : ResponseBaseDto
    {
        public KoszulkaListaDokumentowResponse()
        {
            ListaDokumentow = new List<DokumentDto> { };
        }

        [DataMember]
        public virtual List<DokumentDto> ListaDokumentow { get; set; }
    }

    public partial class KoszulkaRejestrPismoDto
    {
        public virtual int Id { get; set; }
        public virtual string Nazwa { get; set; }
        public virtual DateTime DataUtworzenia { get; set; }
        public virtual DateTime? DataZakonczenia { get; set; }
    }

    public partial class KoszulkaRejestrSprawDto
    {
        public virtual int Id { get; set; }
        public virtual DateTime DataRejestracji { get; set; }
        public virtual DateTime? DataZakonczenia { get; set; }
        public virtual DateTime? TerminSprawy { get; set; }
        public virtual int Jednostka { get; set; }
        public virtual string Rwa { get; set; }
        public virtual int Rok { get; set; }
        public virtual string Znak { get; set; }
    }

    public partial class KoszulkaRejestrWplywowDto
    {
        public virtual string NadawcaNazwa { get; set; }
        public virtual DateTime DataWplywu { get; set; }
        public virtual DateTime DataRejestracji { get; set; }
        public virtual string ZnakWplywu { get; set; }
        public virtual long? IdDokumentu { get; set; }
    }

    [Route("/koszulka/KoszulkaFolderyStatus", "POST")]
    [Route("/ad/koszulka/KoszulkaFolderyStatus", "POST")]
    [DataContract]
    public partial class KoszulkiStatus
        : RequestBaseDto, IReturn<KoszulkiStatusResponse>
    {
    }

    [DataContract]
    public partial class KoszulkiStatusResponse
        : ResponseBaseDto
    {
        [DataMember]
        public virtual int Nowe { get; set; }

        [DataMember]
        public virtual int WRealizacj { get; set; }
    }

    [DataContract]
    public partial class MetrykaSprawyResponse
        : ResponseBaseDto
    {
        public MetrykaSprawyResponse()
        {
            ListaCzynnosci = new List<CzynnoscMetrykiSprawyDto> { };
        }

        [DataMember]
        public virtual List<CzynnoscMetrykiSprawyDto> ListaCzynnosci { get; set; }

        [DataMember]
        public virtual int IdPisma { get; set; }

        [DataMember]
        public virtual string ZnakSprawy { get; set; }
    }

    [DataContract]
    public partial class PismoDto
        : ResponseBaseDto
    {
        [DataMember]
        public virtual int ID { get; set; }

        [DataMember]
        public virtual string Nazwa { get; set; }

        [DataMember]
        public virtual string DekretacjaEtapyAutor { get; set; }

        [DataMember]
        public virtual RejestrSprawExtendedResponse RejestrSpraw { get; set; }

        [DataMember]
        public virtual int? Rodzaj { get; set; }

        [DataMember]
        public virtual DateTime? WazneDo { get; set; }

        [DataMember]
        public virtual DateTime DataUtworzenia { get; set; }

        [DataMember]
        public virtual bool Zawieszone { get; set; }

        [DataMember]
        public virtual bool Zakonczone { get; set; }

        [DataMember]
        public virtual DateTime? DataZakonczenia { get; set; }

        [DataMember]
        public virtual DateTime? TerminPisma { get; set; }

        [DataMember]
        public virtual int? ZakonczeniePowod { get; set; }

        [DataMember]
        public virtual bool KoszulkaWrazliwa { get; set; }

        [DataMember]
        public virtual DateTime? KoszulkaWrazliwaData { get; set; }

        [DataMember]
        public virtual bool CzyZarchiwizowany { get; set; }

        [DataMember]
        public virtual StanowiskoDto TworcaStanowisko { get; set; }

        [DataMember]
        public virtual StanowiskoDto ProwadzacyStanowisko { get; set; }
    }

    [Route("/PobierzInstalacje", "POST")]
    [Route("/ad/PobierzInstalacje", "POST")]
    [DataContract]
    public partial class PobierzInstalacje
        : RequestBaseDto, IReturn<PobierzInstalacjeResponse>
    {
    }

    [DataContract]
    public partial class PobierzInstalacjeResponse
        : ResponseBaseDto
    {
        public PobierzInstalacjeResponse()
        {
            Instalacje = new List<InstalacjaDto> { };
        }

        [DataMember]
        public virtual List<InstalacjaDto> Instalacje { get; set; }
    }

    [Route("/Jednostka/PoId", "POST")]
    [Route("/ad/Jednostka/PoId", "POST")]
    [DataContract]
    public partial class PobierzJednostke
        : RequestBaseDto, IReturn<PobierzJednostkeResponse>
    {
        [DataMember]
        public virtual int IdentyfikatorJednostki { get; set; }
    }

    [DataContract]
    public partial class PobierzJednostkeResponse
        : ResponseBaseDto
    {
        [DataMember]
        public virtual JednostkaDto Jednostka { get; set; }
    }

    [Route("/Koszulka", "POST")]
    [Route("/ad/Koszulka", "POST")]
    [DataContract]
    public partial class PobierzKoszulke
        : RequestBaseDto, IReturn<PobierzKoszulkeResponse>
    {
        [DataMember]
        public virtual WskazanieKoszulkiDto Koszulka { get; set; }
    }

    [Route("/KoszulkaRejestry", "POST")]
    [Route("/ad/KoszulkaRejestry", "POST")]
    [DataContract]
    public partial class PobierzKoszulkeRejestry
        : RequestBaseDto, IReturn<PobierzKoszulkeRejestryResponse>
    {
        [DataMember]
        public virtual WskazanieKoszulkiDto Koszulka { get; set; }
    }

    [DataContract]
    public partial class PobierzKoszulkeRejestryResponse
        : ResponseBaseDto
    {
        [DataMember]
        public virtual KoszulkaRejestrPismoDto Pismo { get; set; }

        [DataMember]
        public virtual KoszulkaRejestrSprawDto Sprawa { get; set; }

        [DataMember]
        public virtual KoszulkaRejestrWplywowDto Wplyw { get; set; }
    }

    [DataContract]
    public partial class PobierzKoszulkeResponse
        : ResponseBaseDto
    {
        [DataMember]
        public virtual PismoDto Pismo { get; set; }
    }

    [Route("/Koszulka/PobierzKoszulki", "POST")]
    [Route("/ad/Koszulka/PobierzKoszulki", "POST")]
    [DataContract]
    public partial class PobierzKoszulki
        : RequestBaseDto, IReturn<PobierzKoszulkiResponse>
    {
        [DataMember]
        public virtual int WielkoscPartii { get; set; }

        [DataMember]
        public virtual int CzescPartii { get; set; }

        [DataMember]
        public virtual bool Zakonczone { get; set; }
    }

    [DataContract]
    public partial class PobierzKoszulkiResponse
        : ResponseBaseDto
    {
        public PobierzKoszulkiResponse()
        {
            Pisma = new List<PismoDto> { };
        }

        [DataMember]
        public virtual List<PismoDto> Pisma { get; set; }
    }

    [Route("/RejestrSpraw/MetrykaSprawy", "POST")]
    [Route("/ad/RejestrSpraw/MetrykaSprawy", "POST")]
    [DataContract]
    public partial class PobierzMetrykeSprawy
        : RequestBaseDto, IReturn<MetrykaSprawyResponse>
    {
        [DataMember]
        [ApiMember(Description = "Rejestr Przesyłek Wpływających")]
        public virtual string Rpw { get; set; }

        [DataMember]
        [ApiMember(Description = "Znak Sprawy")]
        public virtual string ZnakSprawy { get; set; }
    }

    [Route("/Pracownik/PobierzPracownikowJednostki", "POST")]
    [Route("/ad/Pracownik/PobierzPracownikowJednostki", "POST")]
    [DataContract]
    public partial class PobierzPracownikowJednostki
        : RequestBaseDto, IReturn<PobierzPracownikowJednostkiResponse>
    {
        [DataMember]
        public virtual int IdJednostki { get; set; }
    }

    [DataContract]
    public partial class PobierzPracownikowJednostkiResponse
        : ResponseBaseDto
    {
        public PobierzPracownikowJednostkiResponse()
        {
            Pracownicy = new List<PracownikDto> { };
        }

        [DataMember]
        public virtual List<PracownikDto> Pracownicy { get; set; }
    }

    ///<summary>
    ///RWA
    ///</summary>
    [Route("/rwa/PobierzRwa", "POST")]
    [Route("/ad/rwa/PobierzRwa", "POST")]
    [Api("RWA")]
    [DataContract]
    public partial class PobierzRwa
        : RequestBaseDto, IReturn<PobierzRwaResponse>
    {
        [DataMember]
        [ApiMember(Description = "Rocznik")]
        public virtual int Rocznik { get; set; }
    }

    [DataContract]
    public partial class PobierzRwaResponse
        : ResponseBaseDto
    {
        [DataMember]
        public virtual TeczkaRwaDto Teczki { get; set; }
    }

    ///<summary>
    ///API blockchain
    ///</summary>
    [Route("/Blockchain/PobierzUtrwalenie", "POST")]
    [Route("/ad/Blockchain/PobierzUtrwalenie", "POST")]
    [Api("API blockchain")]
    [DataContract]
    public partial class PobierzUtrwalenie
        : RequestBaseDto, IReturn<PobierzUtrwalenieResponse>
    {
        [DataMember]
        public virtual string IdZlecenia { get; set; }
    }

    [DataContract]
    public partial class PobierzUtrwalenieResponse
        : ResponseBaseDto
    {
        [DataMember]
        public virtual string TrescUtrwalenie { get; set; }
    }

    [Route("/Jednostka/PobierzWszytkie", "POST")]
    [Route("/ad/Jednostka/PobierzWszytkie", "POST")]
    [ApiResponse(200, "PobierzWszystkieJednostkiResponse")]
    [DataContract]
    public partial class PobierzWszystkieJednostki
        : RequestBaseDto, IReturn<PobierzWszystkieJednostkiResponse>
    {
    }

    [DataContract]
    public partial class PobierzWszystkieJednostkiResponse
        : ResponseBaseDto
    {
        public PobierzWszystkieJednostkiResponse()
        {
            Jednostki = new List<JednostkaDto> { };
        }

        [DataMember]
        public virtual List<JednostkaDto> Jednostki { get; set; }
    }

    [Route("/Pracownik/PobierzWszytskichPracownikow", "POST")]
    [Route("/ad/Pracownik/PobierzWszytskichPracownikow", "POST")]
    [DataContract]
    public partial class PobierzWszytskichPracownikow
        : RequestBaseDto, IReturn<PobierzWszytskichPracownikowResponse>
    {
        [DataMember]
        public virtual int IdJednostki { get; set; }
    }

    [DataContract]
    public partial class PobierzWszytskichPracownikowResponse
        : ResponseBaseDto
    {
        public PobierzWszytskichPracownikowResponse()
        {
            Pracownicy = new List<PracownikDto> { };
        }

        [DataMember]
        public virtual List<PracownikDto> Pracownicy { get; set; }
    }

    ///<summary>
    ///Operacje na załącznikach
    ///</summary>
    [Route("/Zalacznik/PobierzZalacznik", "POST")]
    [Route("/ad/Zalacznik/PobierzZalacznik", "POST")]
    [Api("Operacje na załącznikach")]
    [DataContract]
    public partial class PobierzZalacznik
        : RequestBaseDto, IReturn<PobierzZalacznikResponse>
    {
        [DataMember]
        [ApiMember(Description = "Id załacznika")]
        public virtual int IdZalacznia { get; set; }

        [DataMember]
        [ApiMember(Description = "Nazwa pliku z rozszerzeniem")]
        public virtual string NazwaZalacznika { get; set; }
    }

    [DataContract]
    public partial class PobierzZalacznikResponse
        : ResponseBaseDto
    {
        public PobierzZalacznikResponse()
        {
            zalacznik = new byte[] { };
        }

        [DataMember]
        public virtual ZalacznikDto zalacznikDto { get; set; }

        [DataMember]
        public virtual byte[] zalacznik { get; set; }

        [DataMember]
        public virtual string Nazwa { get; set; }
    }

    [DataContract(Name = "PowiazaniaPismaDto")]
    public partial class PowiazaniaPismaDto
    {
        [DataMember]
        public virtual int IdPisma { get; set; }

        [DataMember]
        public virtual int IdPismaDowiazanego { get; set; }

        [DataMember]
        public virtual DateTime DataDowiazania { get; set; }
    }

    [Route("/koszulka/PowiazKoszulke", "POST")]
    [Route("/ad/koszulka/PowiazKoszulke", "POST")]
    [DataContract]
    public partial class PowiazKoszulke
        : IReturn<PowiazKoszulkeResponse>
    {
        [DataMember]
        public virtual int IdPracownika { get; set; }

        [DataMember]
        public virtual int IdKoszulkiPowiazywanej { get; set; }

        [DataMember]
        public virtual int IdKoszulki { get; set; }

        [DataMember]
        [ApiMember(Description = "Możliwe rodzaje: DOSPRAWY")]
        public virtual string RodzajPowiazania { get; set; }
    }

    [DataContract]
    public partial class PowiazKoszulkeResponse
        : ResponseBaseDto
    {
        [DataMember]
        public virtual int idKoszulki { get; set; }
    }

    [DataContract]
    public partial class PracownikDto
        : ResponseBaseDto
    {
        [DataMember]
        public virtual int ID { get; set; }

        [DataMember]
        public virtual string Imie { get; set; }

        [DataMember]
        public virtual string Nazwisko { get; set; }

        [DataMember]
        public virtual string Stanowisko { get; set; }

        [DataMember]
        public virtual string Ustawienia { get; set; }

        [DataMember]
        public virtual string Inicjaly { get; set; }

        [DataMember]
        public virtual string Login { get; set; }

        [DataMember]
        public virtual bool Aktywny { get; set; }

        [DataMember]
        public virtual bool Systemowy { get; set; }

        [DataMember]
        public virtual string SystemInfo { get; set; }

        [DataMember]
        public virtual string ActiveDirectory { get; set; }

        [DataMember]
        public virtual string Email { get; set; }

        [DataMember]
        public virtual string DrukarkaKodow { get; set; }

        [DataMember]
        public virtual int IdOryginal { get; set; }

        [DataMember]
        public virtual int SortOrder { get; set; }

        [DataMember]
        public virtual string DomyslnyCert { get; set; }

        [DataMember]
        public virtual string ActiveDirectorySID { get; set; }

        [DataMember]
        public virtual string ActiveDirectoryPrincipal { get; set; }

        [DataMember]
        public virtual string DisplayName { get; set; }

        [DataMember]
        public virtual bool Ukryty { get; set; }

        [DataMember]
        public virtual bool ModulIntegracjaWidocznosc { get; set; }

        [DataMember]
        public virtual int IdJednostki { get; set; }

        [DataMember]
        public virtual JednostkaDto Jednostka { get; set; }

        [DataMember]
        public virtual int IdJednostkiOrginal { get; set; }

        [DataMember]
        public virtual JednostkaDto JednostkaOrginal { get; set; }

        [DataMember]
        public virtual int? IdWydzialu { get; set; }

        [DataMember]
        public virtual JednostkaDto Wydzial { get; set; }

        [DataMember]
        public virtual int? IdWydzialuOrginal { get; set; }

        [DataMember]
        public virtual JednostkaDto WydzialOrginal { get; set; }

        [DataMember]
        public virtual int? IdStanowiska { get; set; }

        [DataMember]
        public virtual int? IdStanowiskaOrginal { get; set; }

        [DataMember]
        public virtual string JednostkaNazwa { get; set; }

        [DataMember]
        public virtual string JednostkaSymbol { get; set; }

        [DataMember]
        public virtual int IdAplikacji { get; set; }

        [DataMember]
        public virtual string ID_App { get; set; }

        [DataMember]
        public virtual int Order { get; set; }

        [DataMember]
        public virtual bool Unused1 { get; set; }

        [DataMember]
        public virtual int? IdRoliPrzelozonej { get; set; }

        [DataMember]
        public virtual DateTime? DataUtworzenia { get; set; }

        [DataMember]
        public virtual DateTime? DataUsuniecia { get; set; }

        [DataMember]
        public virtual int? IdAplikacjiAutoryzacji { get; set; }

        [DataMember]
        public virtual int? IdInstytucjiAutoryzacji { get; set; }

        [DataMember]
        public virtual int? IdPracownikaAutoryzacji { get; set; }

        [DataMember]
        public virtual int? IdStanowiskaAutoryzacji { get; set; }

        [DataMember]
        public virtual string Atrybut1 { get; set; }

        [DataMember]
        public virtual string Atrybut2 { get; set; }

        [DataMember]
        public virtual string Atrybut3 { get; set; }

        [DataMember]
        public virtual string Atrybut4 { get; set; }

        [DataMember]
        public virtual string Atrybut5 { get; set; }

        [DataMember]
        public virtual string Atrybut6 { get; set; }

        [DataMember]
        public virtual DateTime? WazneDo { get; set; }

        [DataMember]
        public virtual DateTime? DataZmianyHasla { get; set; }

        [DataMember]
        public virtual string PoprzednieHaslo { get; set; }

        [DataMember]
        public virtual string OstatniSkrotPBI { get; set; }
    }

    ///<summary>
    ///API pracownika
    ///</summary>
    [Route("/Pracownik/PrzeniesPracownika", "POST")]
    [Route("/ad/Pracownik/PrzeniesPracownika", "POST")]
    [Api("API pracownika")]
    [DataContract]
    public partial class PrzeniesPracownika
        : RequestBaseDto, IReturn<PrzeniesPracownikaResponse>
    {
        [DataMember]
        public virtual int IdJednostki { get; set; }

        [DataMember]
        public virtual bool ZachowajDostep { get; set; }
    }

    [DataContract]
    public partial class PrzeniesPracownikaResponse
        : ResponseBaseDto
    {
        [DataMember]
        public virtual int IdJednostki { get; set; }
    }

    [DataContract]
    public partial class RejestrSprawExtendedResponse
        : RejestrSprawResponseBase
    {
        [DataMember]
        public virtual string RWANazwa { get; set; }

        [DataMember]
        public virtual int RWARok { get; set; }

        [DataMember]
        public virtual string RWASymbol { get; set; }
    }

    [DataContract]
    public partial class RejestrSprawResponseBase
        : ResponseBaseDto
    {
        [DataMember]
        public virtual int Id { get; set; }

        [DataMember]
        public virtual int LP { get; set; }

        [DataMember]
        public virtual string OdKogo { get; set; }

        [DataMember]
        public virtual string ZnakPisma { get; set; }

        [DataMember]
        public virtual string DataPisma { get; set; }

        [DataMember]
        public virtual string Uwagi { get; set; }

        [DataMember]
        public virtual string Znak { get; set; }

        [DataMember]
        public virtual int IdPisma { get; set; }

        [DataMember]
        public virtual PismoDto Pismo { get; set; }

        [DataMember]
        public virtual string Rwa { get; set; }

        [DataMember]
        public virtual int RwaId { get; set; }

        [DataMember]
        public virtual int Rok { get; set; }

        [DataMember]
        public virtual DateTime DataRejestracji { get; set; }

        [DataMember]
        public virtual DateTime? DataZakonczenia { get; set; }

        [DataMember]
        public virtual DateTime? TerminSprawy { get; set; }

        [DataMember]
        public virtual DateTime? DataRozpoczecia { get; set; }

        [DataMember]
        public virtual int IdWydzial { get; set; }

        [DataMember]
        public virtual int IdWydzialOrginal { get; set; }

        [DataMember]
        public virtual JednostkaDto Wydzial { get; set; }

        [DataMember]
        public virtual JednostkaDto WydzialOrginal { get; set; }

        [DataMember]
        public virtual string RwaParentCode { get; set; }

        [DataMember]
        public virtual int? InicjatorId { get; set; }

        [DataMember]
        public virtual int IdProwadzacy { get; set; }

        [DataMember]
        public virtual PracownikDto Inicjator { get; set; }

        [DataMember]
        public virtual PracownikDto Prowadzacy { get; set; }

        [DataMember]
        public virtual int? RwaParentId { get; set; }

        [DataMember]
        public virtual string KategoriaArchiwalna { get; set; }

        [DataMember]
        public virtual TypProwadzenia TypProwadzenia { get; set; }

        [DataMember]
        public virtual int? FixedId { get; set; }

        [DataMember]
        public virtual string PoprzedniZnakSprawy { get; set; }

        [DataMember]
        public virtual long? IdDokumentuWszczynajacego { get; set; }

        [DataMember]
        public virtual long? IdDokumentuMeta { get; set; }

        [DataMember]
        public virtual int? IdTypSprawy { get; set; }

        [DataMember]
        public virtual int? IdEtapuUdostepnienia { get; set; }

        [DataMember]
        public virtual int? ArchiwumStatus { get; set; }

        [DataMember]
        public virtual int? TypUsuniecia { get; set; }
    }

    [Route("/SkanPlus/Verification/WyslanePisma/{WyslanePisma}", "PUT")]
    [Route("/ad/SkanPlus/Verification/WyslanePisma/{WyslanePisma}", "PUT")]
    [Route("/SkanPlus/Verification/Konfiguracja/{Konfiguracja}", "PUT")]
    [Route("/ad/SkanPlus/Verification/Konfiguracja/{Konfiguracja}", "PUT")]
    [Route("/SkanPlus/Verification/WyslanePismaOcr/{WyslanePismaOcr}", "PUT")]
    [Route("/ad/SkanPlus/Verification/WyslanePismaOcr/{WyslanePismaOcr}", "PUT")]
    [Route("/SkanPlus/Verification/ZeskanowaneStrony/{ZeskanowaneStrony}", "PUT")]
    [Route("/ad/SkanPlus/Verification/ZeskanowaneStrony/{ZeskanowaneStrony}", "PUT")]
    [Route("/SkanPlus/Verification", "GET")]
    [Route("/ad/SkanPlus/Verification", "GET")]
    [DataContract]
    public partial class SkanPlusVerification
        : RequestBaseDto, IReturn<SkanPlusVerificationResponse>
    {
    }

    [DataContract]
    public partial class SkanPlusVerificationResponse
        : ResponseBaseDto
    {
        [DataMember]
        public virtual PracownikDto Pracownik { get; set; }

        [DataMember]
        public virtual string DynamicDotNetTwain { get; set; }

        [DataMember]
        public virtual string AsposeLic { get; set; }
    }

    [DataContract]
    public partial class StanowiskoDto
        : ResponseBaseDto
    {
        [DataMember]
        public virtual int Id { get; set; }

        [DataMember]
        public virtual int IdJednostki { get; set; }

        [DataMember]
        public virtual int? IdPracownika { get; set; }

        [DataMember]
        public virtual string Nazwa { get; set; }
    }

    ///<summary>
    ///Informacje o sprawach
    ///</summary>
    [Route("/RejestrSpraw/StanSprawy", "POST")]
    [Route("/ad/RejestrSpraw/StanSprawy", "POST")]
    [Api("Informacje o sprawach")]
    [DataContract]
    public partial class StanSprawy
        : RequestBaseDto, IReturn<StanSprawyResponse>
    {
        [DataMember]
        [ApiMember(Description = "Rejestr Przesyłek Wpływających(RPW) - rejestr służący do ewidencjonowania w kolejności chronologicznej przesyłek otrzymywanych przez daną jednostkę, prowadzony w systemie EZD jako jeden rejestr dla całej jednostki.")]
        public virtual string rpw { get; set; }

        [DataMember]
        [ApiMember(Description = "Znak sprawy - zespół symboli, na który składają się co najmniej: oznaczenie komórki organizacyjnej, symbol klasyfikacyjny z wykazu akt, numer, pod którym sprawa została zarejestrowana w spisie spraw i cztery cyfry roku kalendarzowego, w którym sprawa się rozpoczęła.")]
        public virtual string ZnakSprawy { get; set; }
    }

    [DataContract]
    public partial class StanSprawyResponse
        : ResponseBaseDto
    {
        [DataMember]
        public virtual DateTime DataRejestracji { get; set; }

        [DataMember]
        public virtual DateTime DataWplyniecia { get; set; }

        [DataMember]
        public virtual DateTime? DataZakonczenia { get; set; }

        [DataMember]
        public virtual string Jednostka { get; set; }

        [DataMember]
        public virtual string WlascicielNazwaWyswietlana { get; set; }

        [DataMember]
        public virtual bool WRealizacji { get; set; }

        [DataMember]
        public virtual bool Zakonczona { get; set; }

        [DataMember]
        public virtual bool Zawieszona { get; set; }

        [DataMember]
        public virtual string ZnakSprawy { get; set; }
    }

    [DataContract]
    public partial class TeczkaRwaDto
        : ResponseBaseDto
    {
        public TeczkaRwaDto()
        {
            TeczkiPodrzedne = new List<TeczkaRwaDto> { };
        }

        [DataMember]
        public virtual int ID { get; set; }

        [DataMember]
        public virtual List<TeczkaRwaDto> TeczkiPodrzedne { get; set; }

        [DataMember]
        public virtual int Rok { get; set; }

        [DataMember]
        public virtual string Symbol { get; set; }

        [DataMember]
        public virtual string Nazwa { get; set; }

        [DataMember]
        public virtual string KategoriaArchiwalna { get; set; }

        [DataMember]
        public virtual TypProwadzenia TypProwadzenia { get; set; }

        [DataMember]
        public virtual int IloscWyjatkow { get; set; }

        [DataMember]
        public virtual bool UdostepnienieWyjatek { get; set; }

        [DataMember]
        public virtual int NumerLP { get; set; }

        [DataMember]
        public virtual int? LP { get; set; }

        [DataMember]
        public virtual bool Nieaktywny { get; set; }

        [DataMember]
        public virtual int? TerminDni { get; set; }

        [DataMember]
        public virtual int? IdJednostki { get; set; }
    }

    [Route("/koszulka/UdostepnijKoszulke", "POST")]
    [Route("/ad/koszulka/UdostepnijKoszulke", "POST")]
    [DataContract]
    public partial class UdostepnijKoszulke
        : RequestBaseDto, IReturn<UdostepnijKoszulkeResponse>
    {
        public UdostepnijKoszulke()
        {
            UdostepnianeDokumenty = new List<UdostepnionyDokument> { };
            WybraniPracownicyId = new List<int> { };
        }

        [DataMember]
        public virtual int IdPracownika { get; set; }

        [DataMember]
        public virtual int IdKoszulki { get; set; }

        [DataMember]
        public virtual bool CzyPilne { get; set; }

        [DataMember]
        public virtual DateTime? Termin { get; set; }

        [DataMember]
        public virtual bool RejestrPismWewnetrznych { get; set; }

        [DataMember]
        public virtual string Uwagi { get; set; }

        [DataMember]
        public virtual List<UdostepnionyDokument> UdostepnianeDokumenty { get; set; }

        [DataMember]
        public virtual List<int> WybraniPracownicyId { get; set; }
    }

    [DataContract]
    public partial class UdostepnijKoszulkeResponse
        : ResponseBaseDto
    {
        [DataMember]
        public virtual IDictionary<int, int> ListaUdostepnionychKoszulek { get; set; }
    }

    public partial class UdostepnionyDokument
    {
        public virtual long IdDokumentu { get; set; }
        public virtual TrybUdostepnienia Tryb { get; set; }
    }

    [Route("/api3/WyszukajAdresataWplywu", "POST")]
    [Route("/ad/api3/WyszukajAdresataWplywu", "POST")]
    [DataContract]
    public partial class WyszukajAdresataWplywu
        : RequestBaseDto, IReturn<WyszukajAdresataWplywuResponse>
    {
        [DataMember]
        public virtual string NumerRpw { get; set; }

        [DataMember]
        public virtual string Sygnatura { get; set; }

        [DataMember]
        public virtual string DataRejestracjiOd { get; set; }

        [DataMember]
        public virtual string DataRejestracjiDo { get; set; }

        [DataMember]
        public virtual string NadawcaNazwa { get; set; }

        [DataMember]
        public virtual string NadawcaImie { get; set; }

        [DataMember]
        public virtual string NadawcaNazwisko { get; set; }

        [DataMember]
        public virtual string Nip { get; set; }

        [DataMember]
        public virtual string Regon { get; set; }

        [DataMember]
        public virtual string Pesel { get; set; }

        [DataMember]
        public virtual string Email { get; set; }

        [DataMember]
        public virtual string Ulica { get; set; }

        [DataMember]
        public virtual string Budynek { get; set; }

        [DataMember]
        public virtual string Lokal { get; set; }

        [DataMember]
        public virtual string Miejscowosc { get; set; }

        [DataMember]
        public virtual string KodPocztowy { get; set; }
    }

    [DataContract]
    public partial class WyszukajAdresataWplywuResponse
        : ResponseBaseDto
    {
        public WyszukajAdresataWplywuResponse()
        {
            AdresaciWplywu = new List<WyszukajAdresataWplywuDto> { };
        }

        [DataMember]
        public virtual List<WyszukajAdresataWplywuDto> AdresaciWplywu { get; set; }
    }

    [Route("/koszulka/Wyszukaj", "POST")]
    [Route("/ad/koszulka/Wyszukaj", "POST")]
    [DataContract]
    public partial class WyszukajWplyw
        : RequestBaseDto, IReturn<WyszukajWplywResponse>
    {
        [DataMember]
        public virtual long NumerRpw { get; set; }

        [DataMember]
        public virtual int Rocznik { get; set; }

        [DataMember]
        public virtual string KodKreskowy { get; set; }

        [DataMember]
        public virtual string IdDokumentuePUAP { get; set; }
    }

    [DataContract]
    public partial class WyszukajWplywResponse
        : ResponseBaseDto
    {
        public WyszukajWplywResponse()
        {
            IdsKoszulek = new List<long> { };
        }

        [DataMember]
        public virtual long IdKoszulki { get; set; }

        [DataMember]
        public virtual long IdDokumentu { get; set; }

        [DataMember]
        public virtual string ZnakWplywu { get; set; }

        [DataMember]
        [ApiMember(Description = "Lista identyfikatorów koszulek, do których dokument wpływu został udostępniony lub skopiowany")]
        public virtual List<long> IdsKoszulek { get; set; }
    }

    [DataContract]
    public partial class ZalacznikDto
        : ResponseBaseDto
    {
        [DataMember]
        public virtual int ID { get; set; }

        [DataMember]
        public virtual string Nazwa { get; set; }

        [DataMember]
        public virtual string Hash { get; set; }

        [DataMember]
        public virtual int Rozmiar { get; set; }

        [DataMember]
        public virtual bool Podpis { get; set; }

        [DataMember]
        public virtual string Wersja { get; set; }

        [DataMember]
        public virtual int? Oryginal { get; set; }

        [DataMember]
        public virtual int Typ { get; set; }

        [DataMember]
        public virtual ZalacznikDto Poprzedni { get; set; }

        [DataMember]
        public virtual DateTime? DataUtworzenia { get; set; }

        [DataMember]
        public virtual int IdPracownika { get; set; }

        [DataMember]
        public virtual PracownikDto Pracownik { get; set; }

        [DataMember]
        public virtual string PodpisPracownik { get; set; }

        [DataMember]
        public virtual int? LiczbaStron { get; set; }
    }

    ///<summary>
    ///API blockchain
    ///</summary>
    [Route("/Blockchain/ZlecUtrwalenie", "POST")]
    [Route("/ad/Blockchain/ZlecUtrwalenie", "POST")]
    [Api("API blockchain")]
    [DataContract]
    public partial class ZlecUtrwalenie
        : RequestBaseDto, IReturn<ZlecUtrwalenieResponse>
    {
        public ZlecUtrwalenie()
        {
            Dane = new byte[] { };
        }

        [DataMember]
        [ApiMember(Description = "Binarne dane")]
        public virtual byte[] Dane { get; set; }

        [DataMember]
        [ApiMember(Description = "Numer sekwencyjny")]
        public virtual long? NumerSekwencyjny { get; set; }
    }

    [DataContract]
    public partial class ZlecUtrwalenieResponse
        : ResponseBaseDto
    {
        [DataMember]
        public virtual string IdZlecenia { get; set; }
    }
}

namespace ezd.api.App.MODEL.Dto.Api1
{

    [Route("/Pracownik/PobierzPracownika")]
    [Route("/ad/Pracownik/PobierzPracownika")]
    [Route("/api1/PobierzPracownika")]
    [Route("/ad/api1/PobierzPracownika")]
    [DataContract]
    public partial class PobierzPracownika
        : RequestBaseDto, IReturn<PobierzPracownikaResponse>
    {
        public PobierzPracownika()
        {
            RoleOrganizacyjneArray = new string[] { };
            RoleOrganizacyjneKluczArray = new string[] { };
        }

        [DataMember]
        public virtual string RoleOrganizacyjne { get; set; }

        [DataMember]
        public virtual string[] RoleOrganizacyjneArray { get; set; }

        [DataMember]
        public virtual string RoleOrganizacyjneKlucz { get; set; }

        [DataMember]
        public virtual string[] RoleOrganizacyjneKluczArray { get; set; }

        [DataMember]
        public virtual int IdStanowiskaZrodlo { get; set; }

        [DataMember]
        public virtual int IdPracownikaZrodlo { get; set; }

        [DataMember]
        public virtual string TypJednostkiPracownikaZrodlo { get; set; }

        [DataMember]
        public virtual string SymbolJednostkiZrodlo { get; set; }

        [DataMember]
        public virtual int IdJednostkiZrodlo { get; set; }

        [DataMember]
        public virtual string NazwaStanowiska { get; set; }

        [DataMember]
        public virtual string NazwaJednostki { get; set; }

        [DataMember]
        public virtual string ActiveDirectory { get; set; }
    }

    [DataContract]
    public partial class PobierzPracownikaResponse
        : ResponseBaseDto
    {
        public PobierzPracownikaResponse()
        {
            Role = new string[] { };
            RoleKlucz = new string[] { };
        }

        [DataMember]
        public virtual int IdPracownika { get; set; }

        [DataMember]
        public virtual int IdPracownikaOrginal { get; set; }

        [DataMember]
        public virtual int IdStanowiska { get; set; }

        [DataMember]
        public virtual int IdStanowiskaOrginal { get; set; }

        [DataMember]
        public virtual int IdJednostki { get; set; }

        [DataMember]
        public virtual int IdJednostkiOrginal { get; set; }

        [DataMember]
        public virtual string NazwaJednostki { get; set; }

        [DataMember]
        public virtual string SymbolJednostki { get; set; }

        [DataMember]
        public virtual int IdWydzial { get; set; }

        [DataMember]
        public virtual int IdWydzialOrginal { get; set; }

        [DataMember]
        public virtual string NazwaWydzialu { get; set; }

        [DataMember]
        public virtual string SymbolWydzialu { get; set; }

        [DataMember]
        public virtual string ImieNazwisko { get; set; }

        [DataMember]
        public virtual string Stanowisko { get; set; }

        [DataMember]
        public virtual string[] Role { get; set; }

        [DataMember]
        public virtual string[] RoleKlucz { get; set; }

        [DataMember]
        public virtual string Email { get; set; }
    }

    [Route("/Api1/PrzekazKoszulke", "POST")]
    [Route("/ad/Api1/PrzekazKoszulke", "POST")]
    [Route("/Koszulka/PrzekazKoszulke", "POST")]
    [Route("/ad/Koszulka/PrzekazKoszulke", "POST")]
    [DataContract]
    public partial class PrzekazKoszulke
        : RequestBaseDto, IReturn<PrzekazKoszulkeResponse>
    {
        [DataMember]
        public virtual int IdKoszulki { get; set; }

        [DataMember]
        public virtual string ZnakPisma { get; set; }

        [DataMember]
        public virtual int IdPracownikaZrodlowego { get; set; }

        [DataMember]
        public virtual int IdStanowiskaZrodlowego { get; set; }

        [DataMember]
        public virtual int IdPracownikaDocelowego { get; set; }

        [DataMember]
        public virtual int IdStanowiskaDocelowego { get; set; }

        [DataMember]
        public virtual string Uwagi { get; set; }
    }

    [DataContract]
    public partial class PrzekazKoszulkeResponse
        : ResponseBaseDto
    {
        [DataMember]
        public virtual int IdEtapPisma { get; set; }
    }

    [Route("/Formularz/UstawWidokFormularza", "POST")]
    [Route("/ad/Formularz/UstawWidokFormularza", "POST")]
    [Route("/Api1/UstawWidokFormularza", "POST")]
    [Route("/ad/Api1/UstawWidokFormularza", "POST")]
    [DataContract]
    public partial class UstawWidokFormularza
        : RequestBaseDto, IReturn<UstawWidokFormularzaResponse>
    {
        [DataMember]
        public virtual int IdFormularza { get; set; }

        [DataMember]
        public virtual int Widok { get; set; }
    }

    [DataContract]
    public partial class UstawWidokFormularzaResponse
        : ResponseBaseDto
    {
    }

    [Route("/Widok/UstawWidokPrzekaz", "POST")]
    [Route("/ad/Widok/UstawWidokPrzekaz", "POST")]
    [Route("/Api1/UstawWidokPrzekaz", "POST")]
    [Route("/ad/Api1/UstawWidokPrzekaz", "POST")]
    [DataContract]
    public partial class UstawWidokPrzekaz
        : RequestBaseDto, IReturn<UstawWidokPrzekazResponse>
    {
        [DataMember]
        [ApiMember(Description = "RWA")]
        public virtual int IdKoszulki { get; set; }

        [DataMember]
        [ApiMember(Description = "Rocznik")]
        public virtual int IdFormularza { get; set; }

        [DataMember]
        [ApiMember(Description = "Id jednostki (orginał)")]
        public virtual long IdDokumentu { get; set; }

        [DataMember]
        [ApiMember(Description = "Widok")]
        public virtual int Widok { get; set; }

        [DataMember]
        [ApiMember(Description = "Id pracownika źródłowego")]
        public virtual int IdPracownikaZrodlowego { get; set; }

        [DataMember]
        [ApiMember(Description = "Id stanowiska źródłowego")]
        public virtual int IdStanowiskaZrodlowego { get; set; }

        [DataMember]
        [ApiMember(Description = "Id pracownika docelowego")]
        public virtual int IdPracownikaDocelowego { get; set; }

        [DataMember]
        [ApiMember(Description = "Id stanowiska docelowego")]
        public virtual int IdStanowiskaDocelowego { get; set; }
    }

    [DataContract]
    public partial class UstawWidokPrzekazResponse
        : ResponseBaseDto
    {
        [DataMember]
        public virtual int IdEtapPisma { get; set; }
    }

    [Route("/Formularz/UtworzFormularzKoszulki", "POST")]
    [Route("/ad/Formularz/UtworzFormularzKoszulki", "POST")]
    [Route("/api1/UtworzFormularzKoszulki", "POST")]
    [Route("/ad/api1/UtworzFormularzKoszulki", "POST")]
    [DataContract]
    public partial class UtworzFormularzKoszulki
        : RequestBaseDto, IReturn<UtworzFormularzKoszulkiResponse>
    {
        [DataMember]
        public virtual string NazwaFormularza { get; set; }

        [DataMember]
        public virtual int IdKoszulki { get; set; }
    }

    [DataContract]
    public partial class UtworzFormularzKoszulkiResponse
        : ResponseBaseDto
    {
        [DataMember]
        public virtual int IdInstancjiFormularza { get; set; }
    }

    [Route("/api1/UtworzKoszulke", "POST")]
    [Route("/ad/api1/UtworzKoszulke", "POST")]
    [Route("/koszulka/utworzkoszulke", "POST")]
    [Route("/ad/koszulka/utworzkoszulke", "POST")]
    [DataContract]
    public partial class UtworzKoszulke
        : RequestBaseDto, IReturn<UtworzKoszulkeResponse>
    {
        [DataMember]
        public virtual string Nazwa { get; set; }
    }

    [DataContract]
    public partial class UtworzKoszulkeResponse
        : ResponseBaseDto
    {
        [DataMember]
        public virtual int IdKoszulki { get; set; }
    }

    [Route("/koszulka/wznowkoszulke", "POST")]
    [Route("/ad/koszulka/wznowkoszulke", "POST")]
    [Route("/api1/WznowKoszulke", "POST")]
    [Route("/ad/api1/WznowKoszulke", "POST")]
    [DataContract]
    public partial class WznowKoszulke
        : RequestBaseDto, IReturn<ZakonczKoszulkeResponse>
    {
        [DataMember]
        [ApiMember(Description = "Identyfikator wznawianej koszulki / sprawy")]
        public virtual int IdKoszulki { get; set; }

        [DataMember]
        [ApiMember(Description = "Identyfikator pracownika wznawiającego koszulkę / sprawę")]
        public virtual int IdPracownika { get; set; }
    }

    [Route("/koszulka/zakonczkoszulke", "POST")]
    [Route("/ad/koszulka/zakonczkoszulke", "POST")]
    [Route("/api1/ZakonczKoszulke", "POST")]
    [Route("/ad/api1/ZakonczKoszulke", "POST")]
    [DataContract]
    public partial class ZakonczKoszulke
        : RequestBaseDto, IReturn<ZakonczKoszulkeResponse>
    {
        [DataMember]
        public virtual WskazanieKoszulkiDto Koszulka { get; set; }

        [DataMember]
        public virtual int IdKoszulki { get; set; }

        [DataMember]
        public virtual bool ZwykleZakonczenie { get; set; }

        [DataMember]
        public virtual bool SprawaProwadzonaPozaEzd { get; set; }

        [DataMember]
        public virtual string PismoNieStanowiAktSprawyKlasa { get; set; }

        [DataMember]
        public virtual int Rocznik { get; set; }
    }

    [DataContract]
    public partial class ZakonczKoszulkeResponse
        : ResponseBaseDto
    {
        [DataMember]
        public virtual int IdEtapPisma { get; set; }
    }
}

namespace ezd.api.App.MODEL.Dto.Api3
{

    [Route("/Dokument/AkceptujDokument", "POST")]
    [Route("/ad/Dokument/AkceptujDokument", "POST")]
    [DataContract]
    public partial class AkceptujDokument
        : RequestBaseDto, IReturn<AkceptujDokumentResponse>
    {
        [DataMember]
        public virtual WskazanieDokumentuDto Dokument { get; set; }
    }

    [DataContract]
    public partial class AkceptujDokumentResponse
        : ResponseBaseDto
    {
        [DataMember]
        public virtual long IdAkceptacji { get; set; }
    }

    [Route("/Dokument/Aktualizuj", "POST")]
    [Route("/ad/Dokument/Aktualizuj", "POST")]
    [Route("/Api3/AktualizujDokument", "POST")]
    [Route("/ad/Api3/AktualizujDokument", "POST")]
    [DataContract]
    public partial class AktualizujDokument
        : RequestBaseDto, IReturn<AktualizujDokumentResponse>
    {
        [DataMember]
        public virtual DokumentSystemowyTypeDto Dokument { get; set; }
    }

    [DataContract]
    public partial class AktualizujDokumentResponse
        : ResponseBaseDto
    {
        [DataMember]
        public virtual long IdDokumentu { get; set; }

        [DataMember]
        public virtual int IdZawartosci { get; set; }
    }

    [Route("/Dokument/DokumentDodaj", "POST")]
    [Route("/ad/Dokument/DokumentDodaj", "POST")]
    [DataContract]
    public partial class DokumentDodaj
        : RequestBaseDto, IReturn<DokumentDodajResponse>
    {
        public DokumentDodaj()
        {
            Dane = new byte[] { };
        }

        [DataMember]
        public virtual int KoszulkaId { get; set; }

        [DataMember]
        [ApiMember(Description = "Nazwa pliku z rozszerzeniem")]
        public virtual string Nazwa { get; set; }

        [DataMember]
        [ApiMember(Description = "Binarne dane pliku")]
        public virtual byte[] Dane { get; set; }

        [DataMember]
        [ApiMember(Description = "Etykieta systemu zewnetrzego - parametr niewymagany")]
        public virtual string Oznaczenie { get; set; }

        [DataMember]
        [ApiMember(Description = "Zapisz metadane dokumentu")]
        public virtual bool Metadane { get; set; }

        [DataMember]
        [ApiMember(Description = "Ustawione na True wymusi ekstrakcję załączników z dodawanego dokumentu xml")]
        public virtual bool EpismoZalaczniki { get; set; }

        [DataMember]
        [ApiMember(Description = "Rodzaj dokumentu (Decyzja, Faktura, Pismo, Rachunek itp.)")]
        public virtual string Rodzaj { get; set; }

        [DataMember]
        [ApiMember(Description = "Dostęp: Publiczny / Niepubliczny")]
        public virtual string Dostep { get; set; }
    }

    [DataContract]
    public partial class DokumentDodajResponse
        : ResponseBaseDto
    {
        [DataMember]
        public virtual long DokumentId { get; set; }

        [DataMember]
        public virtual int ZawartoscId { get; set; }
    }

    [Route("/Dokument/DokumentMonit", "POST")]
    [Route("/ad/Dokument/DokumentMonit", "POST")]
    [DataContract]
    public partial class DokumentMonit
        : RequestBaseDto, IReturn<DokumentMonitResponse>
    {
        [DataMember]
        public virtual long IdDokumentu { get; set; }
    }

    [DataContract]
    public partial class DokumentMonitResponse
        : ResponseBaseDto
    {
        [DataMember]
        public virtual bool Monit { get; set; }

        [DataMember]
        public virtual DateTime DataMonit { get; set; }

        [DataMember]
        public virtual int PracownikMonit { get; set; }
    }

    [Route("/Dokument/DokumentPobierz", "POST")]
    [Route("/ad/Dokument/DokumentPobierz", "POST")]
    [DataContract]
    public partial class DokumentPobierz
        : RequestBaseDto, IReturn<DokumentPobierzResponse>
    {
        [DataMember]
        public virtual long DokumentId { get; set; }

        [DataMember]
        [ApiMember(Description = "Etykieta systemu zewnetrzego - parametr niewymagany")]
        public virtual string Oznaczenie { get; set; }
    }

    [DataContract]
    public partial class DokumentPobierzResponse
        : ResponseBaseDto
    {
        public DokumentPobierzResponse()
        {
            Zawartosc = new byte[] { };
        }

        [DataMember]
        public virtual string NazwaDokumentu { get; set; }

        [DataMember]
        public virtual int AutorId { get; set; }

        [DataMember]
        public virtual string DokumentDataUtworzenia { get; set; }

        [DataMember]
        public virtual string DokumentDataModyfikacji { get; set; }

        [DataMember]
        public virtual string NazwaZalacznika { get; set; }

        [DataMember]
        public virtual string ZalacznikDataUtworzenia { get; set; }

        [DataMember]
        public virtual string Wersja { get; set; }

        [DataMember]
        public virtual int IdZalacznika { get; set; }

        [DataMember]
        public virtual byte[] Zawartosc { get; set; }

        [DataMember]
        public virtual string Sha512 { get; set; }
    }

    [Route("/api3/EpuapWplyw", "POST")]
    [Route("/ad/api3/EpuapWplyw", "POST")]
    [DataContract]
    public partial class EpuapWplyw
        : RequestBaseDto, IReturn<EpuapWplywResponse>
    {
        [DataMember]
        public virtual string IdentyfikatorKorelacjiCID { get; set; }

        [DataMember]
        public virtual string IdentyfikatorDokumentu { get; set; }
    }

    [DataContract]
    public partial class EpuapWplywResponse
        : ResponseBaseDto
    {
        public EpuapWplywResponse()
        {
            ListaWplywow = new List<EpuapWplywRejestrDto> { };
        }

        [DataMember]
        public virtual List<EpuapWplywRejestrDto> ListaWplywow { get; set; }
    }

    [Route("/api3/KorespondencjaRejestruj", "POST")]
    [Route("/ad/api3/KorespondencjaRejestruj", "POST")]
    [DataContract]
    public partial class KorespondencjaRejestruj
        : RequestBaseDto, IReturn<KorespondencjaRejestrujResponse>
    {
        public KorespondencjaRejestruj()
        {
            IdsDokumentyWychodzace = new List<long> { };
            Adresaci = new List<AdresatTypeDto> { };
        }

        [DataMember]
        public virtual int IdPracownika { get; set; }

        [DataMember]
        public virtual int IdKoszulki { get; set; }

        [DataMember]
        public virtual List<long> IdsDokumentyWychodzace { get; set; }

        [DataMember]
        [ApiMember(Description = "Możliwe typy: KOPERTA, MAIL, FAX")]
        public virtual string TypKorespondencji { get; set; }

        [DataMember]
        [ApiMember(Description = "Rodzaj zdefiniowany w Słowniku Aplikacji")]
        public virtual string RodzajPrzesylki { get; set; }

        [DataMember]
        [ApiMember(Description = "Dołącz zwrotkę")]
        public virtual bool Zwrotka { get; set; }

        [DataMember]
        [ApiMember(Description = "Możliwe strefy: 0 - Krajowa, 1 - Europa, 2 - Ameryka Północna, Afryka, 3 - Ameryka Południowa i Środkowa, Azja, 4 - Australi, Oceania")]
        public virtual int Strefa { get; set; }

        [DataMember]
        public virtual bool Priorytet { get; set; }

        [DataMember]
        public virtual string Uwagi { get; set; }

        [DataMember]
        public virtual string UwagiDodatkowe { get; set; }

        [DataMember]
        public virtual string DodatkoweInformacje { get; set; }

        [DataMember]
        public virtual List<AdresatTypeDto> Adresaci { get; set; }

        [DataMember]
        public virtual string ePUAP_AdresOdpowiedzi { get; set; }

        [DataMember]
        public virtual string ePUAP_Identyfikator { get; set; }

        [DataMember]
        public virtual string ePUAP_TrybDostarczenia { get; set; }
    }

    [DataContract]
    public partial class KorespondencjaRejestrujResponse
        : ResponseBaseDto
    {
        public KorespondencjaRejestrujResponse()
        {
            Korespondencja = new List<KorespondencjaZarejestrowanaDto> { };
        }

        [DataMember]
        public virtual List<KorespondencjaZarejestrowanaDto> Korespondencja { get; set; }
    }

    [Route("/api3/KorespondencjaStatus", "POST")]
    [Route("/ad/api3/KorespondencjaStatus", "POST")]
    [DataContract]
    public partial class KorespondencjaStatus
        : RequestBaseDto, IReturn<KorespondencjaStatusResponse>
    {
        [DataMember]
        [ApiMember(Description = "Data i godzina w formacie rrrr-mm-dd hh-mm")]
        public virtual string DataRejestracjiOd { get; set; }

        [DataMember]
        [ApiMember(Description = "Data i godzina w formacie rrrr-mm-dd hh-mm")]
        public virtual string DataRejestracjiDo { get; set; }

        [DataMember]
        [ApiMember(Description = "Możliwe wartości: 0 - NIEWYSŁANA, 1 - WYSŁANA, 2 - ANULOWANA, 3 - USUNIĘTA, 6 - PRZYJĘTA; brak - zwróci wszystkie")]
        public virtual int Status { get; set; }

        [DataMember]
        [ApiMember(Description = "Rodzaj zdefiniowany w Słowniku Aplikacji")]
        public virtual string RodzajPrzesylki { get; set; }

        [DataMember]
        [ApiMember(Description = "Możliwe typy: KOPERTA, MAIL, FAX")]
        public virtual string TypKorespondencji { get; set; }
    }

    [DataContract]
    public partial class KorespondencjaStatusResponse
        : ResponseBaseDto
    {
        public KorespondencjaStatusResponse()
        {
            ListaKwStatusu = new List<KorespondencjaStatusDto> { };
        }

        [DataMember]
        public virtual List<KorespondencjaStatusDto> ListaKwStatusu { get; set; }
    }

    [Route("/api3/EpuapWyplyw", "POST")]
    [Route("/ad/api3/EpuapWyplyw", "POST")]
    [DataContract]
    public partial class KorespondencjaWychodzacaEpuap
        : RequestBaseDto, IReturn<KorespondencjaWychodzacaEpuapResponse>
    {
        [DataMember]
        public virtual long IdKorespondencjiWychodzacej { get; set; }

        [DataMember]
        public virtual string IdentyfikatorKorelacjiCID { get; set; }

        [DataMember]
        public virtual string IdentyfikatorDokumentu { get; set; }

        [DataMember]
        public virtual int IdKoszulki { get; set; }
    }

    [DataContract]
    public partial class KorespondencjaWychodzacaEpuapResponse
        : ResponseBaseDto
    {
        public KorespondencjaWychodzacaEpuapResponse()
        {
            WychodzacaEpuapLista = new List<KorespondencjaWychodzacaEpuapDto> { };
        }

        [DataMember]
        public virtual List<KorespondencjaWychodzacaEpuapDto> WychodzacaEpuapLista { get; set; }
    }

    [Route("/api3/PapierWyplyw", "POST")]
    [Route("/ad/api3/PapierWyplyw", "POST")]
    [DataContract]
    public partial class KorespondencjaWychodzacaPapierowa
        : RequestBaseDto, IReturn<KorespondencjaWychodzacaPapierowaResponse>
    {
        [DataMember]
        public virtual long IdKorespondencjiWychodzacej { get; set; }

        [DataMember]
        public virtual long IdDokumentZwrotki { get; set; }
    }

    [DataContract]
    public partial class KorespondencjaWychodzacaPapierowaResponse
        : ResponseBaseDto
    {
        public KorespondencjaWychodzacaPapierowaResponse()
        {
            WychodzacaPapierowaLista = new List<KorespondencjaWychodzacaPapierowaDto> { };
        }

        [DataMember]
        public virtual List<KorespondencjaWychodzacaPapierowaDto> WychodzacaPapierowaLista { get; set; }
    }

    [Route("/Dokument/PobierzMetadaneDokumentu", "POST")]
    [Route("/ad/Dokument/PobierzMetadaneDokumentu", "POST")]
    [DataContract]
    public partial class PobierzMetadaneDokumentu
        : RequestBaseDto, IReturn<PobierzMetadaneDokumentuResponse>
    {
        [DataMember]
        [Required]
        public virtual long Identyfikator { get; set; }
    }

    [DataContract]
    public partial class PobierzMetadaneDokumentuResponse
        : ResponseBaseDto
    {
        public PobierzMetadaneDokumentuResponse()
        {
            Atrybuty = new AtrybutObiektuTypeDto[] { };
            Akceptacje = new List<DokumentAkceptacjaDto> { };
        }

        [DataMember]
        public virtual long IdDokumentu { get; set; }

        [DataMember]
        public virtual DateTime? MetaDataAktualizacji { get; set; }

        [DataMember]
        public virtual bool MetadaneZapisane { get; set; }

        [DataMember]
        public virtual string RodzajDokumentu { get; set; }

        [DataMember]
        public virtual string TypDokumentu { get; set; }

        [DataMember]
        public virtual string Dostep { get; set; }

        [DataMember]
        public virtual DateTime? DataWidniejaca { get; set; }

        [DataMember]
        public virtual string ZnakWidniejacy { get; set; }

        [DataMember]
        public virtual bool BrakDatyNaPismie { get; set; }

        [DataMember]
        public virtual bool BrakZnakuNaPismie { get; set; }

        [DataMember]
        public virtual bool DokumentElektroniczny { get; set; }

        [DataMember]
        public virtual bool NiePodlegaPrzechowywaniu { get; set; }

        [DataMember]
        public virtual int? AdresatId { get; set; }

        [DataMember]
        public virtual int? AdresatAdresId { get; set; }

        [DataMember]
        public virtual DateTime? DataNadania { get; set; }

        [DataMember]
        public virtual string NadawcaNazwa { get; set; }

        [DataMember]
        public virtual string Imie { get; set; }

        [DataMember]
        public virtual string Nazwisko { get; set; }

        [DataMember]
        public virtual string Miejscowosc { get; set; }

        [DataMember]
        public virtual string KodPocztowy { get; set; }

        [DataMember]
        public virtual string Poczta { get; set; }

        [DataMember]
        public virtual string Ulica { get; set; }

        [DataMember]
        public virtual string NumerDomu { get; set; }

        [DataMember]
        public virtual string NumerLokalu { get; set; }

        [DataMember]
        public virtual string AdresEmail { get; set; }

        [DataMember]
        public virtual string Nip { get; set; }

        [DataMember]
        public virtual string Regon { get; set; }

        [DataMember]
        public virtual string Pesel { get; set; }

        [DataMember]
        public virtual string TypAdresata { get; set; }

        [DataMember]
        public virtual string ZnakWplywu { get; set; }

        [DataMember]
        public virtual DateTime DataNadaniaPrzesylki { get; set; }

        [DataMember]
        public virtual DateTime DataWplywuPrzesylki { get; set; }

        [DataMember]
        public virtual DateTime DataRejestracjiPrzesylki { get; set; }

        [DataMember]
        public virtual string SposobDostarczenia { get; set; }

        [DataMember]
        public virtual string AdresEmailFax { get; set; }

        [DataMember]
        public virtual string NumerR { get; set; }

        [DataMember]
        public virtual int? LiczbaZalacznikow { get; set; }

        [DataMember]
        public virtual string Uwagi { get; set; }

        [DataMember]
        public virtual AtrybutObiektuTypeDto[] Atrybuty { get; set; }

        [DataMember]
        public virtual string PodpisSubject { get; set; }

        [DataMember]
        public virtual DateTime DataPodpisu { get; set; }

        [DataMember]
        public virtual List<DokumentAkceptacjaDto> Akceptacje { get; set; }
    }

    [Route("/Dokument/PobierzOznaczoneDokumenty", "POST")]
    [Route("/ad/Dokument/PobierzOznaczoneDokumenty", "POST")]
    [DataContract]
    public partial class PobierzOznaczoneDokumenty
        : RequestBaseDto, IReturn<PobierzOznaczoneDokumentyResponse>
    {
        [DataMember]
        public virtual string Oznaczenie { get; set; }

        [DataMember]
        public virtual string DataOznaczeniaOd { get; set; }

        [DataMember]
        public virtual string DataOznaczeniaDo { get; set; }

        [DataMember]
        public virtual bool Pobrane { get; set; }
    }

    [DataContract]
    public partial class PobierzOznaczoneDokumentyResponse
        : ResponseBaseDto
    {
        public PobierzOznaczoneDokumentyResponse()
        {
            DokumentyOznaczone = new List<DokumentOznaczonyDto> { };
        }

        [DataMember]
        public virtual List<DokumentOznaczonyDto> DokumentyOznaczone { get; set; }
    }

    [Route("/Api3/PobierzSprawe")]
    [Route("/ad/Api3/PobierzSprawe")]
    [Route("/RejestrSpraw/PobierzSprawe")]
    [Route("/ad/RejestrSpraw/PobierzSprawe")]
    [DataContract]
    public partial class PobierzSprawe
        : RequestBaseDto, IReturn<PobierzSpraweResponse>
    {
        [DataMember]
        public virtual string Znak { get; set; }
    }

    [DataContract]
    public partial class PobierzSpraweResponse
        : ResponseBaseDto
    {
        [DataMember]
        public virtual PobierzSprawyResponseDto Sprawa { get; set; }
    }

    [Route("/Api3/PobierzSprawy")]
    [Route("/ad/Api3/PobierzSprawy")]
    [Route("/RejestrSpraw/PobierzSprawy")]
    [Route("/ad/RejestrSpraw/PobierzSprawy")]
    [DataContract]
    public partial class PobierzSprawy
        : RequestBaseDto, IReturn<PobierzSprawyResponse>
    {
        [DataMember]
        public virtual int Rocznik { get; set; }

        [DataMember]
        public virtual string SymbolJRWA { get; set; }

        [DataMember]
        public virtual int IdJednostki { get; set; }
    }

    [DataContract]
    public partial class PobierzSprawyResponse
        : ResponseBaseDto
    {
        [DataMember]
        public virtual IList<PobierzSprawyResponseDto> ListaSpraw { get; set; }
    }

    [Route("/Dokument/RejestrujDokument", "POST")]
    [Route("/ad/Dokument/RejestrujDokument", "POST")]
    [Route("/Api3/RejestrujDokument", "POST")]
    [Route("/ad/Api3/RejestrujDokument", "POST")]
    [DataContract]
    public partial class RejestrujDokument
        : RequestBaseDto, IReturn<RejestrujDokumentResponse>
    {
        [DataMember]
        public virtual DokumentSystemowyTypeDto Dokument { get; set; }

        [DataMember]
        public virtual WskazanieKoszulkiDto Koszulka { get; set; }
    }

    [DataContract]
    public partial class RejestrujDokumentResponse
        : ResponseBaseDto
    {
        [DataMember]
        public virtual long IdDokumentu { get; set; }

        [DataMember]
        public virtual int IdZawartosci { get; set; }
    }

    ///<summary>
    ///Informacje o sprawach
    ///</summary>
    [Route("/Api3/RejestrujSprawe")]
    [Route("/ad/Api3/RejestrujSprawe")]
    [Route("/RejestrSpraw/RejestrujSprawe")]
    [Route("/ad/RejestrSpraw/RejestrujSprawe")]
    [Api("Informacje o sprawach")]
    [DataContract]
    public partial class RejestrujSprawe
        : RequestBaseDto, IReturn<RejestrujSpraweResponse>
    {
        [DataMember]
        [ApiMember(Description = "Kolejny numer zakładanej sprawy jest wyliczany automatycznie. <br />Zakładanie sprawy pod wskazanym numerem jest możliwe tylko wtedy, gdy ustawiono Rejestrowanie spraw w środku spisu (Ustawienia EZD)")]
        public virtual int NumerKolejnySprawy { get; set; }

        [DataMember]
        public virtual string Uwagi { get; set; }

        [DataMember]
        public virtual string ZnakSprawy { get; set; }

        [DataMember]
        [ApiMember(Description = "Id teczki z RWA")]
        public virtual int IdKoszulki { get; set; }

        [DataMember]
        [ApiMember(Description = "Rocznik")]
        public virtual int Rok { get; set; }

        [DataMember]
        [ApiMember(Description = "Symbol teczki z RWA")]
        public virtual string TeczkaSymbol { get; set; }

        [DataMember]
        [ApiMember(Description = "Id teczki z RWA")]
        public virtual int TeczkaId { get; set; }

        [DataMember]
        public virtual string KategoriaArchiwalna { get; set; }

        [DataMember]
        [ApiMember(Description = "Id pracownika prowadzącego sprawę")]
        public virtual int IdProwadzacegoSprawe { get; set; }

        [DataMember]
        [ApiMember(Description = "Id pracownika zakładającego sprawę")]
        public virtual int IdRejestrujacegoSprawe { get; set; }

        [DataMember]
        public virtual string TypProwadzenia { get; set; }

        [DataMember]
        public virtual string DataRozpoczecia { get; set; }

        [DataMember]
        [ApiMember(Description = "Należy go wskazać jeżeli sprawa ma zostać założona na podstawie wpływu zarejestrowanego w innej koszulce, niż ta określona w parametrze IdKoszulki")]
        public virtual int IdKoszulkiWplywu { get; set; }
    }

    [DataContract]
    public partial class RejestrujSpraweResponse
        : ResponseBaseDto
    {
        [DataMember]
        public virtual int IdSprawy { get; set; }

        [DataMember]
        public virtual DateTime DataRejestracjiSprawy { get; set; }

        [DataMember]
        public virtual int IdTeczki { get; set; }

        [DataMember]
        [ApiMember(Description = "Znak założonej sprawy")]
        public virtual string SymbolTeczki { get; set; }

        [DataMember]
        public virtual int IdTeczkiParent { get; set; }

        [DataMember]
        public virtual string SymbolTeczkiParent { get; set; }

        [DataMember]
        public virtual string KategoriaArchiwalna { get; set; }

        [DataMember]
        public virtual string TypProwadzenia { get; set; }
    }

    [Route("/api3/RejestrujWplyw", "POST")]
    [Route("/ad/api3/RejestrujWplyw", "POST")]
    [DataContract]
    public partial class RejestrujWplyw
        : RequestBaseDto, IReturn<RejestrujWplywResponse>
    {
        [DataMember]
        public virtual long IdDokumentu { get; set; }

        [DataMember]
        public virtual int IdPracownikaRejestracji { get; set; }

        [DataMember]
        public virtual int IdStanowiskaRejestracji { get; set; }

        [DataMember]
        public virtual string DataPisma { get; set; }

        [DataMember]
        public virtual string DataNadania { get; set; }

        [DataMember]
        public virtual string Tytul { get; set; }

        [DataMember]
        public virtual string DataWplywu { get; set; }

        [DataMember]
        public virtual string SygnaturaWplywu { get; set; }

        [DataMember]
        public virtual int LiczbaZalacznikow { get; set; }

        [DataMember]
        public virtual string SposobDostarczenia { get; set; }

        [DataMember]
        public virtual string AdresMailFax { get; set; }

        [DataMember]
        public virtual string Uwagi { get; set; }

        [DataMember]
        public virtual string NumerNadania { get; set; }

        [DataMember]
        public virtual string Rodzaj { get; set; }

        [DataMember]
        public virtual bool CzyDokumentElektroniczny { get; set; }

        [DataMember]
        public virtual bool NiePodlegaPrzechowywaniuWSkladzieChronologicznym { get; set; }

        [DataMember]
        public virtual int AdresatID { get; set; }

        [DataMember]
        public virtual string AdresatNazwa { get; set; }

        [DataMember]
        public virtual string AdresatNazwisko { get; set; }

        [DataMember]
        public virtual string AdresatImie { get; set; }

        [DataMember]
        public virtual string AdresatIdentyfikator_ePUPAP { get; set; }

        [DataMember]
        public virtual string AdresatAdresOdpowiedzi_ePUPAP { get; set; }

        [DataMember]
        public virtual string AdresatNip { get; set; }

        [DataMember]
        public virtual string AdresatRegon { get; set; }

        [DataMember]
        public virtual string AdresatPesel { get; set; }

        [DataMember]
        public virtual string AdresatTelefon { get; set; }

        [DataMember]
        public virtual string AdresatEmail { get; set; }

        [DataMember]
        public virtual string AdresatTyp { get; set; }

        [DataMember]
        public virtual int AdresatAdresID { get; set; }

        [DataMember]
        public virtual string AdresatAdresKodPocztowy { get; set; }

        [DataMember]
        public virtual string AdresatAdresMiejscowosc { get; set; }

        [DataMember]
        public virtual string AdresatAdresUlica { get; set; }

        [DataMember]
        public virtual string AdresatAdresNumerDomu { get; set; }

        [DataMember]
        public virtual string AdresatAdresNumerLokalu { get; set; }

        [DataMember]
        public virtual string AdresatAdresSkrytkaPocztowa { get; set; }

        [DataMember]
        public virtual string AdresatAdresPoczta { get; set; }

        [DataMember]
        public virtual string AdresatAdresKraj { get; set; }
    }

    [DataContract]
    public partial class RejestrujWplywResponse
        : ResponseBaseDto
    {
        [DataMember]
        public virtual long IdDokumentu { get; set; }

        [DataMember]
        public virtual int IdWplywu { get; set; }

        [DataMember]
        public virtual int IdKoszulki { get; set; }

        [DataMember]
        public virtual string ZnakWplywu { get; set; }

        [DataMember]
        public virtual int IdAdresata { get; set; }

        [DataMember]
        public virtual int IdAdresu { get; set; }
    }

    [Route("/Api3/UsunSprawe")]
    [Route("/ad/Api3/UsunSprawe")]
    [Route("/RejestrSpraw/UsunSprawe")]
    [Route("/ad/RejestrSpraw/UsunSprawe")]
    [DataContract]
    public partial class UsunSprawe
        : RequestBaseDto, IReturn<RejestrujSpraweResponse>
    {
        [DataMember]
        public virtual int IdKoszulki { get; set; }

        [DataMember]
        [ApiMember(Description = "Możliwe powody: BLEDNA_REJESTRACJA")]
        public virtual string PowodUsuniecia { get; set; }

        [DataMember]
        public virtual string Uwagi { get; set; }

        [DataMember]
        [ApiMember(Description = "Identyfikator użytkownika usuwającego sprawę")]
        public virtual int IdPracownika { get; set; }
    }
}

namespace ezd.api.App.MODEL.Dto.Api3.DTO
{

    [DataContract]
    public partial class AdresatAdresPelnyDto
    {
        public AdresatAdresPelnyDto()
        {
            Atrybuty = new AtrybutObiektuTypeDto[] { };
        }

        [DataMember]
        public virtual int Id { get; set; }

        [DataMember]
        public virtual string Miejscowosc { get; set; }

        [DataMember]
        public virtual string Ulica { get; set; }

        [DataMember]
        public virtual string KodPocztowy { get; set; }

        [DataMember]
        public virtual string Poczta { get; set; }

        [DataMember]
        public virtual string Kraj { get; set; }

        [DataMember]
        public virtual string NumerBudynku { get; set; }

        [DataMember]
        public virtual string NumerLokalu { get; set; }

        [DataMember]
        public virtual string SkrytkaPocztowa { get; set; }

        [DataMember]
        public virtual string TypAdresu { get; set; }

        [DataMember]
        public virtual int AdresatAdresOrginalId { get; set; }

        [DataMember]
        public virtual DateTime DataUtworzenia { get; set; }

        [DataMember]
        public virtual AtrybutObiektuTypeDto[] Atrybuty { get; set; }
    }

    [DataContract]
    public partial class AdresatPelnyDto
    {
        public AdresatPelnyDto()
        {
            Adresy = new AdresatAdresPelnyDto[] { };
            Atrybuty = new AtrybutObiektuTypeDto[] { };
        }

        [DataMember]
        public virtual int Id { get; set; }

        [DataMember]
        public virtual int AdresatOrginalId { get; set; }

        [DataMember]
        public virtual string Imie { get; set; }

        [DataMember]
        public virtual string Nazwisko { get; set; }

        [DataMember]
        public virtual string Nazwa { get; set; }

        [DataMember]
        public virtual DateTime DataUtworzenia { get; set; }

        [DataMember]
        public virtual string IdentyfikatorEpuap { get; set; }

        [DataMember]
        public virtual string AdresOdpowiedziEpuap { get; set; }

        [DataMember]
        public virtual string NIP { get; set; }

        [DataMember]
        public virtual string REGON { get; set; }

        [DataMember]
        public virtual string PESEL { get; set; }

        [DataMember]
        public virtual string TypAdresata { get; set; }

        [DataMember]
        public virtual string PrefiksNazwa { get; set; }

        [DataMember]
        public virtual string PrefiksNazwisko { get; set; }

        [DataMember]
        public virtual string PelnionaFunkcja { get; set; }

        [DataMember]
        public virtual bool Aktualny { get; set; }

        [DataMember]
        public virtual AdresatAdresPelnyDto[] Adresy { get; set; }

        [DataMember]
        public virtual AtrybutObiektuTypeDto[] Atrybuty { get; set; }

        [DataMember]
        public virtual string Atrybut1 { get; set; }

        [DataMember]
        public virtual string Atrybut2 { get; set; }

        [DataMember]
        public virtual string Atrybut3 { get; set; }

        [DataMember]
        public virtual string Atrybut4 { get; set; }

        [DataMember]
        public virtual string Atrybut5 { get; set; }

        [DataMember]
        public virtual string Atrybut6 { get; set; }

        [DataMember]
        public virtual string Atrybut7 { get; set; }

        [DataMember]
        public virtual string Atrybut8 { get; set; }

        [DataMember]
        public virtual string Atrybut9 { get; set; }

        [DataMember]
        public virtual string Atrybut10 { get; set; }

        [DataMember]
        public virtual DateTime? DataBlokady { get; set; }
    }

    [DataContract]
    public partial class AdresatTypeDto
    {
        public AdresatTypeDto()
        {
            AtrybutyAdresata = new AtrybutObiektuTypeDto[] { };
            AtrybutyAdresu = new AtrybutObiektuTypeDto[] { };
        }

        [DataMember]
        public virtual string Nazwa { get; set; }

        [DataMember]
        public virtual string Imie { get; set; }

        [DataMember]
        public virtual string Nazwisko { get; set; }

        [DataMember]
        public virtual string Miejscowosc { get; set; }

        [DataMember]
        public virtual string Ulica { get; set; }

        [DataMember]
        public virtual string KodPocztowy { get; set; }

        [DataMember]
        public virtual string Poczta { get; set; }

        [DataMember]
        public virtual string Kraj { get; set; }

        [DataMember]
        public virtual string NumerBudynku { get; set; }

        [DataMember]
        public virtual string NumerLokalu { get; set; }

        [DataMember]
        public virtual int AdresatId { get; set; }

        [DataMember]
        public virtual int AdresatOrginalId { get; set; }

        [DataMember]
        public virtual int AdresatAdresId { get; set; }

        [DataMember]
        public virtual int AdresatAdresOrginalId { get; set; }

        [DataMember]
        public virtual AtrybutObiektuTypeDto[] AtrybutyAdresata { get; set; }

        [DataMember]
        public virtual AtrybutObiektuTypeDto[] AtrybutyAdresu { get; set; }

        [DataMember]
        public virtual string Atrybut1 { get; set; }

        [DataMember]
        public virtual string Atrybut2 { get; set; }

        [DataMember]
        public virtual string Atrybut3 { get; set; }

        [DataMember]
        public virtual string Atrybut4 { get; set; }

        [DataMember]
        public virtual string Atrybut5 { get; set; }

        [DataMember]
        public virtual string Atrybut6 { get; set; }

        [DataMember]
        public virtual string Atrybut7 { get; set; }

        [DataMember]
        public virtual string Atrybut8 { get; set; }

        [DataMember]
        public virtual string Atrybut9 { get; set; }

        [DataMember]
        public virtual string Atrybut10 { get; set; }
    }

    [DataContract]
    public partial class AtrybutObiektuTypeDto
    {
        [DataMember]
        public virtual string Klucz { get; set; }

        [DataMember]
        public virtual string Wartosc { get; set; }
    }

    [DataContract]
    public partial class DokumentOznaczonyDto
    {
        public DokumentOznaczonyDto()
        {
            ZalacznikiEpisma = new Dictionary<long, string> { };
            UppEpisma = new Dictionary<long, string> { };
        }

        [DataMember]
        public virtual long DokumentId { get; set; }

        [DataMember]
        public virtual string Nazwa { get; set; }

        [DataMember]
        public virtual int KoszulkaId { get; set; }

        [DataMember]
        public virtual int AutorId { get; set; }

        [DataMember]
        public virtual string DataOznaczenia { get; set; }

        [DataMember]
        public virtual string WersjaDokument { get; set; }

        [DataMember]
        public virtual int ZalacznikId { get; set; }

        [DataMember]
        public virtual string OstatniePobranie { get; set; }

        [DataMember]
        public virtual string OstatniePrzekazanie { get; set; }

        [DataMember]
        public virtual int WplywId { get; set; }

        [DataMember]
        public virtual string ZnakWplywu { get; set; }

        [DataMember]
        public virtual int AdresatId { get; set; }

        [DataMember]
        public virtual int AdresId { get; set; }

        [DataMember]
        public virtual Dictionary<long, string> ZalacznikiEpisma { get; set; }

        [DataMember]
        public virtual Dictionary<long, string> UppEpisma { get; set; }

        [DataMember]
        public virtual string PracownikOznaczenia { get; set; }
    }

    [DataContract]
    public partial class DokumentSkladuDto
    {
        public DokumentSkladuDto()
        {
            Atrybuty = new AtrybutObiektuTypeDto[] { };
        }

        [DataMember]
        public virtual string Identyfikator { get; set; }

        [DataMember]
        public virtual DateTime DataUtworzenia { get; set; }

        [DataMember]
        public virtual string Nazwa { get; set; }

        [DataMember]
        public virtual LokalizacjaDokumentuTypeDto Lokalizacja { get; set; }

        [DataMember]
        public virtual string PracownikUtworzenia { get; set; }

        [DataMember]
        public virtual AtrybutObiektuTypeDto[] Atrybuty { get; set; }
    }

    [DataContract]
    public partial class DokumentSystemowyTypeDto
        : DokumentTypeDto
    {
    }

    [DataContract]
    public partial class DokumentTypeDto
    {
        public DokumentTypeDto()
        {
            Podpis = new PodpisTypeDto[] { };
            Atrybuty = new AtrybutObiektuTypeDto[] { };
            Sklad = new DokumentSkladuDto[] { };
        }

        [DataMember]
        public virtual WskazanieDokumentuDto Identyfikator { get; set; }

        [DataMember]
        public virtual DateTime? DataUtworzenia { get; set; }

        [DataMember]
        public virtual string Nazwa { get; set; }

        [DataMember]
        public virtual string Sygnatura { get; set; }

        [DataMember]
        public virtual string Tytul { get; set; }

        [DataMember]
        public virtual string DataDokumentu { get; set; }

        [DataMember]
        public virtual LokalizacjaDokumentuTypeDto Lokalizacja { get; set; }

        [DataMember]
        public virtual string PracownikUtworzenia { get; set; }

        [DataMember]
        public virtual PodpisTypeDto[] Podpis { get; set; }

        [DataMember]
        public virtual string Rodzaj { get; set; }

        [DataMember]
        public virtual string Dostep { get; set; }

        [DataMember]
        public virtual AtrybutObiektuTypeDto[] Atrybuty { get; set; }

        [DataMember]
        public virtual DokumentSkladuDto[] Sklad { get; set; }

        [DataMember]
        public virtual bool Metadane { get; set; }

        [DataMember]
        public virtual bool? MetaBrakDaty { get; set; }

        [DataMember]
        public virtual bool? MetaBrakZnaku { get; set; }
    }

    public partial class EpuapWplywRejestrDto
    {
        public virtual string NadawcaNazwa { get; set; }
        public virtual DateTime DataWplywu { get; set; }
        public virtual DateTime DataRejestracji { get; set; }
        public virtual string ZnakWplywu { get; set; }
        public virtual string AdresSkrytki { get; set; }
        public virtual int IdPisma { get; set; }
        public virtual long? IdDokumentu { get; set; }
        public virtual string IdentyfikatorDokumentu { get; set; }
        public virtual string IdentyfikatorKorelacji { get; set; }
        public virtual bool ZP { get; set; }
    }

    public partial class KorespondencjaStatusDto
    {
        public KorespondencjaStatusDto()
        {
            Zalaczniki = new List<KorespondencjaZawartoscDto> { };
        }

        public virtual long IdentyfikatorKW { get; set; }
        public virtual DateTime DataRejestracji { get; set; }
        public virtual int Status { get; set; }
        public virtual int IdKoszulki { get; set; }
        public virtual int AdresatId { get; set; }
        public virtual int AdresatAdresId { get; set; }
        public virtual string AdresatNazwa { get; set; }
        public virtual string AdresatImie { get; set; }
        public virtual string AdresatNazwisko { get; set; }
        public virtual string AdresatKodPocztowy { get; set; }
        public virtual string AdresatMiejscowosc { get; set; }
        public virtual string AdresatUlica { get; set; }
        public virtual string AdresatBudynek { get; set; }
        public virtual string AdresatLokal { get; set; }
        public virtual string AdresatKraj { get; set; }
        public virtual DateTime? ZwrotkaDataOdbioru { get; set; }
        public virtual DateTime? ZwrotkaDataPowtorneAwizo { get; set; }
        public virtual int? ZwrotkaIdZawartosci { get; set; }
        public virtual bool? ZwrotkaNieodebrana { get; set; }
        public virtual string ZwrotkaOdbiorca { get; set; }
        public virtual string ZwrotkaPowod { get; set; }
        public virtual List<KorespondencjaZawartoscDto> Zalaczniki { get; set; }
    }

    public partial class KorespondencjaWychodzacaEpuapDto
    {
        public virtual string AdresatNazwa { get; set; }
        public virtual DateTime? DataWyslania { get; set; }
        public virtual string AdresatSkrytki { get; set; }
        public virtual int IdPisma { get; set; }
        public virtual long? IdDokumentu { get; set; }
        public virtual int? IdZalacznika { get; set; }
        public virtual string IdentyfikatorDokumentu { get; set; }
        public virtual string IdentyfikatorKorelacji { get; set; }
        public virtual string TrybWyslania { get; set; }
        public virtual string StatusKomunikat { get; set; }
        public virtual DateTime? TerminDoreczenia { get; set; }
        public virtual long? IdDokumentUPO { get; set; }
    }

    public partial class KorespondencjaWychodzacaPapierowaDto
    {
        public KorespondencjaWychodzacaPapierowaDto()
        {
            ListaZalacznikow = new List<KorespondencjaZawartoscDto> { };
        }

        public virtual string AdresatNazwa { get; set; }
        public virtual string RodzajPrzesylki { get; set; }
        public virtual DateTime? DataWyslania { get; set; }
        public virtual long IdKorespondencji { get; set; }
        public virtual int IdPisma { get; set; }
        public virtual long? IdZwrotki { get; set; }
        public virtual string ZwrotkaStatus { get; set; }
        public virtual List<KorespondencjaZawartoscDto> ListaZalacznikow { get; set; }
    }

    public partial class KorespondencjaZarejestrowanaDto
    {
        public virtual long IdentyfikatorKW { get; set; }
        public virtual string Status { get; set; }
        public virtual DateTime DataRejestracji { get; set; }
        public virtual string ZwrotkaEtykieta { get; set; }
    }

    public partial class KorespondencjaZawartoscDto
    {
        public virtual long? IdDokumentu { get; set; }
        public virtual int? IdZalacznika { get; set; }
    }

    [DataContract]
    public partial class LokalizacjaDokumentuTypeDto
    {
        [DataMember]
        public virtual string IdentyfikatorKontenera { get; set; }

        [DataMember]
        public virtual string IdentyfikatorZawartosci { get; set; }

        [DataMember]
        public virtual string NazwaZawartosci { get; set; }

        [DataMember]
        public virtual int IdZalacznika { get; set; }
    }

    public partial class PobierzSprawyResponseDto
    {
        public virtual int Id { get; set; }
        public virtual int IdPisma { get; set; }
        public virtual string NazwaPisma { get; set; }
        public virtual string Znak { get; set; }
        public virtual string Rwa { get; set; }
        public virtual int Rok { get; set; }
        public virtual int IdJednostki { get; set; }
        public virtual DateTime DataRejestracji { get; set; }
        public virtual DateTime? DataZakonczenia { get; set; }
        public virtual DateTime? TerminSprawy { get; set; }
        public virtual DateTime? DataRozpoczecia { get; set; }
        public virtual long? IdDokumentuWszczynajacego { get; set; }
        public virtual long? IdDokumentuMeta { get; set; }
        public virtual int IdProwadzacego { get; set; }
        public virtual int IdWszczynajacego { get; set; }
        public virtual int IdWlasciciela { get; set; }
        public virtual string Uwagi { get; set; }
    }

    [DataContract]
    public partial class PodpisTypeDto
    {
        [DataMember]
        public virtual DateTime DataPodpisu { get; set; }

        [DataMember]
        public virtual string SubjectPodpisu { get; set; }
    }

    [DataContract]
    public partial class WskazanieDokumentuDto
    {
        [DataMember]
        public virtual long Identyfikator { get; set; }

        [DataMember]
        public virtual string IdentyfikatorDokumentu { get; set; }
    }

    [DataContract]
    public partial class WskazanieKoszulkiDto
    {
        [DataMember]
        public virtual int IdKoszulki { get; set; }

        [DataMember]
        public virtual int IdSprawy { get; set; }

        [DataMember]
        public virtual string ZnakSprawy { get; set; }
    }

    [DataContract]
    public partial class WyszukajAdresataWplywuDto
    {
        [DataMember]
        public virtual int idKoszulki { get; set; }

        [DataMember]
        public virtual string NumerRpw { get; set; }

        [DataMember]
        public virtual string Sygnatura { get; set; }

        [DataMember]
        public virtual string DataRejestracji { get; set; }

        [DataMember]
        public virtual string NadawcaNazwa { get; set; }

        [DataMember]
        public virtual string NadawcaImie { get; set; }

        [DataMember]
        public virtual string NadawcaNazwisko { get; set; }

        [DataMember]
        public virtual string Nip { get; set; }

        [DataMember]
        public virtual string Regon { get; set; }

        [DataMember]
        public virtual string Pesel { get; set; }

        [DataMember]
        public virtual string Email { get; set; }

        [DataMember]
        public virtual string Ulica { get; set; }

        [DataMember]
        public virtual string Budynek { get; set; }

        [DataMember]
        public virtual string Lokal { get; set; }

        [DataMember]
        public virtual string Miejscowosc { get; set; }

        [DataMember]
        public virtual string KodPocztowy { get; set; }

        [DataMember]
        public virtual string IdentyfikatorEpuap { get; set; }

        [DataMember]
        public virtual string AdresOdpowiedziEpuap { get; set; }

        [DataMember]
        public virtual int IdAdresat { get; set; }

        [DataMember]
        public virtual int IdAdresuAdresata { get; set; }
    }
}

namespace ezd.Data.Domain
{

    public partial class Security_RoleOrganizacyjne
    {
        public virtual int ID { get; set; }
        public virtual string Nazwa { get; set; }
        public virtual string Klucz { get; set; }
    }
}

namespace ezd.Data.Enums
{

    public enum TrybUdostepnienia
    {
        ODCZYT,
        EDYCJA,
    }

    public enum TypProwadzenia
    {
        Elektroniczna,
        Tradycyjna,
    }
}

namespace ezd.Data.Integration
{

    [DataContract]
    public partial class ZalacznikLokalizacjaDto
    {
        [DataMember]
        public virtual string IdentyfikatorKontenera { get; set; }

        [DataMember]
        public virtual string IdentyfikatorZawartosci { get; set; }

        [DataMember]
        public virtual string NazwaZawartosci { get; set; }
    }
}

