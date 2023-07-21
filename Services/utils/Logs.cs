using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;


namespace Services
{
    static class Logs
    {
        private static StringBuilder stringBuilderLogs = new StringBuilder();

        static string sciezkaLogi = CustomConfig.folderLogi;
        static string nazwaPlikuLogi_N = "log_" + DateTime.Now.ToString("dd_MM_yyyy_HH_mm_ss") + ".txt";
        static string nazwaPlikuLogi_csv = "log_" + DateTime.Now.ToString("dd_MM_yyyy_HH_mm_ss") + ".csv";
        public static int IloscBledow { get { return _iloscBledow; } }
        public static List<String> BledyAgregacji { get { return _bledyAgregacji; } }
        private static int _iloscBledow = 0;
        private static List<String> _bledyAgregacji = new List<string>();
        private static readonly Object lockObject = new Object();
        //private static readonly ReaderWriterLock writeLock = new ReaderWriterLock();

        public static async Task DodajLog(string wiadomosc, string opis, int user_id, int typ_zdarzenia) //typ_zdarzenia: 1 - info, 2 - error
        {
            try
            {
                lock (lockObject)
                {
                    if (!Directory.Exists(sciezkaLogi))
                        Directory.CreateDirectory(sciezkaLogi);
                    File.AppendAllText(Path.Combine(sciezkaLogi, nazwaPlikuLogi_csv), DateTime.Now.ToString("dd-MM-yyyy_HH:mm:ss") + ";" + user_id + "; " + wiadomosc + ";             " + opis + ";  " + typ_zdarzenia + "\r\n");
                    if (typ_zdarzenia == 2)
                    {
                        _iloscBledow++;
                        _bledyAgregacji.Add(opis);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Thread.Sleep(30);
            }
        }

        public static async Task InitLogsFile(string wiadomosc, string opis, string user_id, string typ)
        {
            try
            {
                lock (lockObject)
                {
                    if (!Directory.Exists(sciezkaLogi))
                        Directory.CreateDirectory(sciezkaLogi);
                    File.AppendAllText(Path.Combine(sciezkaLogi, nazwaPlikuLogi_csv), "DATA" + ";" + "ID UŻYTKOWNIKA" + "; " + "TYTUŁ" + ";" + "OPIS" + ";  " + "TYP ZDARZENIA" + "\r\n");

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Thread.Sleep(30);
            }
        }

        //public static async Task InitLogsFile(string wiadomosc, string opis, int user_id, int typ_zdarzenia)
        //{
        //    try
        //    {
        //        int writeTimeout = 5000;
        //        writeLock.AcquireWriterLock(writeTimeout);
        //        string log = DateTime.Now.ToString("dd-MM-yyyy_HH:mm:ss") + "; USER: " + user_id + "; " + wiadomosc + ";      OPIS: " + opis + "; TYP: " + typ_zdarzenia;
        //        byte[] encodedText = Encoding.Unicode.GetBytes(log);
        //        using (FileStream sourceStream = new FileStream(Path.Combine(sciezkaLogi, nazwaPlikuLogi_csv),
        //            FileMode.Append, FileAccess.Write, FileShare.None, bufferSize: 4096, useAsync: true))
        //        {
        //            await sourceStream.WriteAsync(encodedText, 0, encodedText.Length);
        //        }
        //    }
        //    finally { writeLock.ReleaseWriterLock(); }

        //}

        //    public static async Task InitLogsFile(string wiadomosc, string opis, string user_id, string typ_zdarzenia)
        //    {
        //        try
        //        {
        //            int writeTimeout = 5000;
        //            writeLock.AcquireWriterLock(writeTimeout);
        //            string log = DateTime.Now.ToString("dd-MM-yyyy_HH:mm:ss") + "; USER: " + user_id + "; " + wiadomosc + ";      OPIS: " + opis + "; TYP: " + typ_zdarzenia;
        //            byte[] encodedText = Encoding.Unicode.GetBytes(log);
        //            using (FileStream sourceStream = new FileStream(Path.Combine(sciezkaLogi, nazwaPlikuLogi_csv),
        //                FileMode.Append, FileAccess.Write, FileShare.None, bufferSize: 4096, useAsync: true))
        //            {
        //                await sourceStream.WriteAsync(encodedText, 0, encodedText.Length);
        //            }
        //        }
        //        finally { writeLock.ReleaseWriterLock(); }

        //    }
        //}
    }
}
