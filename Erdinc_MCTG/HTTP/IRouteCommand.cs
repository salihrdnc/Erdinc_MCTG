using Erdinc_MCTG.DB;
using Microsoft.AspNetCore.Routing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Erdinc_MCTG.HTTP
{
    //Definiert die grundlegenden Operationen für eine Routenanfrage
    public interface IRouteCommand
    {
        // Führt den Befehl aus und gibt eine entsprechende Antwort zurück
        Response Execute();
        
        // Setzt die Datenbankinstanz für die spätere Verwendung im Befehl
        void SetDataBase(Database db);
    }
}
