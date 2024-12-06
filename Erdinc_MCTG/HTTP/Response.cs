using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Erdinc_MCTG.HTTP;

namespace Erdinc_MCTG.HTTP
{
    public class Response
    {
        //Der Statuscode der Antwort
        public StatusCode StatusCode {  get; set; }

        //Der Payload der Antwort - die eigentlichen Daten, die im Body der Antwort enthalten sind
        public string? Payload { get; set; }
        public IRoute IRoute { get; set; }
        public HttpClient HttpClient { get; set; }
    }
}
