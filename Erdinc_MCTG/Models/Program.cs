using Erdinc_MCTG.DB;
using Erdinc_MCTG.HTTP;
using System.Diagnostics.Metrics;
using System.Net;
//using Erdinc_MCTG.db;
//using Erdinc_MCTG.Http;

// Logge den Start des Servers
Console.WriteLine("Server starting...");

// Erstelle eine Instanz der Datenbank und initialisiere die Tabellen
Database db = new Database();
db.CreateTables();

// Erstelle die Routen-Konfiguration
Route route = new Route();

// Erstelle den Server und binde ihn an die lokale IP-Adresse und den angegebenen Port
HttpServer server = new HttpServer(IPAddress.Loopback, 10001, route);

// Starte den Server und logge den Status
try
{
    server.Start();
}
catch (Exception ex)
{
    Console.WriteLine($"Fehler beim Starten des Servers: {ex.Message}");
}
finally
{
    Console.WriteLine("Server shutdown.");
}

