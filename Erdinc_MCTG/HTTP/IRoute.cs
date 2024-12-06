using Microsoft.AspNetCore.Routing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Erdinc_MCTG.HTTP
{
    //Definiert eine Methode zur Auflösung von Anfragen in Befehle
    public interface IRoute
    {
        Route Route { get; protected set; }

        // Methode zur Auflösung einer Anfrage (RequestContext) in einen entsprechenden Routenbefehl (IRouteCommand)
        IRouteCommand? Resolve(RequestContext request);
    }
}
