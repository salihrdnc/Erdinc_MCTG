using System;
using System.Collections.Generic;
namespace Erdinc_MCTG.HTTP
{
    public class RequestContext
    {
        //Die HTTP-Methode der Anfrage
        public HTTPMethod Method {  get; set; } = HTTPMethod.Get;

        //Der Pfad der angeforderten Ressource (z. B. "/users")
        public string ResourcePath { get; set; } = string.Empty;

        //Die HTTP-Version der Anfrage, standardmäßig "HTTP/1.1" aber es wird trotzdem 0.9 angezeigt, wenn ich das curl script ausführe, verstehe nicht warum
        public string HttpVersion { get; set; } = "HTTP/1.1";

        //Das Token zur Authentifizierung, falls vorhanden
        public string Token {  get; set; } = string.Empty;

        //Die Header der Anfrage als Dictionary, wobei der Schlüssel der Header-Name ist und der Wert der entsprechende Header-Wert
        public Dictionary<string, string> Header { get; set; } = new Dictionary<string, string>();

        //Der Payload der Anfrage, der optionale Daten enthält
        public string? Payload {  get; set; }
        public IRoute? IRoute
        {
            get => default;
            set { }
        }
        public IRouteCommand? IRouteCommand
        {
            get => default;
            set { }
        }
    }
}