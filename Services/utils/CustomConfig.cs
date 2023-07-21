using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Services
{

        public static class CustomConfig
        {
            public static string[] poprawneRozszerzeniaRaport;

            public static string folderUruchamiania;
            public static string folderSzkielety;
            public static string folderRaporty;
            public static string folderGlowny;
            public static string folderLogi;
            public static bool weryfikacjaNaStronie = false;

            //API EZD
            public static string URL_API;
            public static string LOGIN;
            public static string PASSWORD;
            public static string OZNACZENIE_DOKUMENTU;

            public static string db_connectionString;
            public static string IdKoszulkiMax;

            //private static string CONFIG_FILE_PATH = "C:\\Excel.config";

            private static string sciezkaGlowna = (System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase)).Substring(6);
            private static string config_nazwa = "lck_agregator.config";
            private static string folderSzkielety_nazwa = "szkielety";
            private static string folderRaporty_nazwa = "raporty";
            private static string folderGlowny_nazwa = "MAIN_AGREGATOR";
            private static string folderLogi_nazwa = "logs";
            public static string folderPlikiRaportu_nazwa = "export";

            //wartość podstawowej ścieżki programu, do której dochodzą jeszcze kolejno foldery z raportami
            private static int MAX_CONFIG_PATH_LENGTH = 210;
            public static int MAX_PATH_LENGTH = 260;
            public static string CONFIG_FILE_PATH = Path.Combine(sciezkaGlowna, folderGlowny_nazwa, config_nazwa);

            public static void GetConfigurationValues()
            {
                try
                {
                    if (File.Exists(CONFIG_FILE_PATH))
                    {
                        ExeConfigurationFileMap configFileMap = new ExeConfigurationFileMap();
                        configFileMap.ExeConfigFilename = CONFIG_FILE_PATH;
                        Configuration config = System.Configuration.ConfigurationManager.OpenMappedExeConfiguration(configFileMap, ConfigurationUserLevel.None);

                        folderUruchamiania = sciezkaGlowna;
                        folderSzkielety = Path.Combine(folderUruchamiania, folderGlowny_nazwa, folderSzkielety_nazwa);
                        folderRaporty = Path.Combine(folderUruchamiania, folderGlowny_nazwa, folderRaporty_nazwa);
                        folderGlowny = Path.Combine(folderUruchamiania, folderGlowny_nazwa);
                        folderLogi = Path.Combine(folderUruchamiania, folderGlowny_nazwa, folderLogi_nazwa);

                        if (folderUruchamiania.Length > MAX_PATH_LENGTH || folderSzkielety.Length > MAX_PATH_LENGTH || folderRaporty.Length > MAX_PATH_LENGTH || folderGlowny.Length > MAX_PATH_LENGTH ||
                            folderLogi.Length > MAX_PATH_LENGTH)
                            throw new Exception("Ścieżka do folderu programu jest zbyt długa, aby program mógł poprawnie funkcjonować. Jeżeli uważasz, że to błąd skontaktuj się z Administratorem.");

                        string dostepneRozszerzenia = ".xlsx;.xls;.ods";
                        poprawneRozszerzeniaRaport = dostepneRozszerzenia.Split(';');

                        db_connectionString = config.AppSettings.Settings["db_connectionString"].Value;
                        IdKoszulkiMax = config.AppSettings.Settings["IdKoszulkiMax"].Value;
                        Boolean.TryParse(config.AppSettings.Settings["weryfikacjaNaStronie"].Value, out weryfikacjaNaStronie);
                        //część z configiem do API EZD
                        URL_API = config.AppSettings.Settings["URL_API"].Value;
                        LOGIN = config.AppSettings.Settings["API_LOGIN"].Value;
                        PASSWORD = config.AppSettings.Settings["API_PASSWORD"].Value;
                        OZNACZENIE_DOKUMENTU = config.AppSettings.Settings["OZNACZENIE_DOKUMENTU"].Value;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Błąd odczytu pliku konfiguracyjnego! Skontaktuj się z administratorem:\r\n" + "piotr.cisowski@lck.moszczenica.eu lub lck@moszczenica.eu+\r\n\r\n" + ex.Message);
                }



            }
            private static string KEY_ID_KOSZULKI = "IdKoszulkiMax";

            public static void SaveIdKoszulkiMaxToConfig(string value)
            {
                try
                {
                    ExeConfigurationFileMap configFileMap = new ExeConfigurationFileMap();
                    configFileMap.ExeConfigFilename = CONFIG_FILE_PATH;
                    Configuration config = System.Configuration.ConfigurationManager.OpenMappedExeConfiguration(configFileMap, ConfigurationUserLevel.None);
                    var settings = config.AppSettings.Settings;
                    if (settings[KEY_ID_KOSZULKI] == null)
                    {
                        settings.Add(KEY_ID_KOSZULKI, value);
                    }
                    else
                    {
                        settings[KEY_ID_KOSZULKI].Value = (value);
                    }
                    config.Save(ConfigurationSaveMode.Modified);
                    System.Configuration.ConfigurationManager.RefreshSection(config.AppSettings.SectionInformation.Name);
                    Logs.DodajLog("Zapis IdKoszulkiMax do pliku konfiguracyjnego", "Pomyślnie zapisano największe IdKoszulki dla wpływów ePUAP, wartość zapisana: " + value, Program.user_id, 1);
                }
                catch (Exception ex)
                {
                    Logs.DodajLog("Błąd zapisu w pliku konfiguracyjnym - IdKoszulkiMax", ex.Message + "\r\n" + ex.StackTrace, Program.user_id, 2);
                }
            }

            public static void GetIdKoszulkiMaxFromConfig()
            {
                try
                {
                    ExeConfigurationFileMap configFileMap = new ExeConfigurationFileMap();
                    configFileMap.ExeConfigFilename = CONFIG_FILE_PATH;
                    Configuration config = System.Configuration.ConfigurationManager.OpenMappedExeConfiguration(configFileMap, ConfigurationUserLevel.None);
                    var settings = config.AppSettings.Settings;
                    IdKoszulkiMax = config.AppSettings.Settings["IdKoszulkiMax"].Value;
                    Logs.DodajLog("Odczyt IdKoszulkiMax z pliku konfiguracyjnego", "Pomyślnie odczytano największe IdKoszulki dla wpływów ePUAP", Program.user_id, 1);
                }
                catch (Exception ex)
                {
                    Logs.DodajLog("Błąd przy odczycie z pliku konfiguracyjnego - IdKoszulkiMax", ex.Message + "\r\n" + ex.StackTrace, Program.user_id, 2);
                    IdKoszulkiMax = 0.ToString();
                }
            }

        }
    
}
