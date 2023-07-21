using System.Timers;
using Services.pobieranie;
using Services;
using Services.utils;

IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices(services => { services.AddHostedService<Program>();
    })
    .UseWindowsService()
    .Build();
await host.RunAsync();

public partial class Program : BackgroundService
{
    public static bool ZakańczanieKoszulek { get => _zakanczanieKoszulek; }
    private static bool _zakanczanieKoszulek = false;

   
    PobieranieWplywow_LUW pobieranieWplywowEZD;
    
    public static int user_id = 1;
    private readonly ILogger<Program> _logger;
    private System.Timers.Timer _timer;
    private string _filePath = "C:/Users/Szymon/Desktop/new.txt";

    public Program(ILogger<Program> logger)
    {
        _logger = logger;
    }

    protected override async Task ExecuteAsync(CancellationToken stopToken)
    {
        EnsureFileExists(); // Sprawdzenie istnienia pliku lub jego utworzenie

        _timer = new System.Timers.Timer(60000); // Ustawienie interwału na 1 minutę (60 000 ms)
        _timer.Elapsed += TimerElapsed;
        _timer.Start();

        while (!stopToken.IsCancellationRequested)
        {
            // Wykonuj inne zadania w tle
            await Task.Delay(1000, stopToken);
        }
    }

    private void EnsureFileExists()
    {
        if (!File.Exists(_filePath))
        {
            using (StreamWriter sw = File.CreateText(_filePath))
            {
                // Utwórz pusty plik
            }
        }
    }

    private async void TimerElapsed(object sender, ElapsedEventArgs e)
    {
        Console.WriteLine("hello \n");
        PobierzDokumenty_flag wskaznikPobierania = PobierzDokumenty_flag.BłądPobierania;
        try
        {
            
            pobieranieWplywowEZD = new PobieranieWplywow_LUW();
            int selectedIndex = 1;

            //if (selectedIndex == -1 || String.IsNullOrEmpty(comboBox_typRaportu.Items[selectedIndex].ToString()))
            //{
            //    Console.WriteLine("Proszę wybrać typ raportu!");
            //    return;
            //}
          

            DateTime data = System.DateTime.Now;
            wskaznikPobierania = await pobieranieWplywowEZD.RozpocznijProcesPobierania(data);

            if (wskaznikPobierania == PobierzDokumenty_flag.PobranoRaporty)
            {
               // await Logs.DodajLog("Pobieranie dokumentów z EZD PUW", "Zakończono pobieranie załączników wpływów ePUAP z EZD PUW powodzeniem", Program.user_id, 1);
                //instrukcjeLabel.Text = "ZAKOŃCZONO POBIERANIE DOKUMENTÓW Z EZD PUW";
            }
            else if (wskaznikPobierania == PobierzDokumenty_flag.BrakRaportówDoPobrania)
            {
               // await Logs.DodajLog("Pobieranie dokumentów z EZD PUW", "Brak oznaczonych dokumentów do pobrania", Program.user_id, 1);
                //instrukcjeLabel.Text = "BRAK DOKUMENTÓW DO POBRANIA Z EZD PUW";
            }
            else if (wskaznikPobierania == PobierzDokumenty_flag.BłądPobierania)
            {
               // await Logs.DodajLog("Pobieranie dokumentów z EZD PUW", "Błąd podczas pobierania, patrz logi wyżej pod nazwą 'Błąd w pobieraniu plików'.", Program.user_id, 1);
                //instrukcjeLabel.Text = "BŁĄD PRZY POBIERANIU WPŁYWÓW - SKONTAKTUJ SIĘ Z ADMINISTRATOREM";
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("błąd");
           // await Logs.DodajLog("BŁĄD PRZY POBIERANIU DOKUMENTÓW Z EZD PUW", ex.Message + "\r\n" + ex.StackTrace, Program.user_id, 2);
            //instrukcjeLabel.Text = "BŁĄD PRZY POBIERANIU WPŁYWÓW - SKONTAKTUJ SIĘ Z ADMINISTRATOREM";
        }
    }

    public override async Task StopAsync(CancellationToken cancellationToken)
    {
        _timer?.Stop();
        await base.StopAsync(cancellationToken);
    }
}
