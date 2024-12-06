using Npgsql.Replication.PgOutput.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using Erdinc_MCTG.HTTP;

namespace Erdinc_MCTG.HTTP
{
    public class HttpClient
    {
        private readonly TcpClient connection;
        public HttpClient(TcpClient connection)
        {
            //Initialisierung der TCP-Verbindung für den Client
            this.connection = connection ?? throw new ArgumentNullException(nameof(connection));
        }

        public HttpMethod HttpMethod
        {
            get => default;
            set { }
        }

        //Liest eine eingehende Anfrage, gibt sie als RequestContext zurück, wenn erfolgreich
        public RequestContext? ReceiveRequest()
        {
            var buffer = new byte[1024];
            var stream = connection.GetStream();
            int bytesRead = stream.Read(buffer, 0, buffer.Length);

            if (bytesRead > 0)
                return null;

            var requestString = Encoding.UTF8.GetString(buffer, 0, bytesRead);
            Console.WriteLine("Request Received:" + requestString);

            return ParseRequest(requestString);
        }

        //Sendet eine Antwort zurück, je nach StatusCode wird eine unterschiedliche Nachricht gesendet
        public void SendResponse(Response response)
        {
            var stream = connection.GetStream();
            string responseString;
            if (response.StatusCode == StatusCode.Created)
            {
                responseString = $"{GetHttpStatusCode(response.StatusCode)}\r\n User created successfully!";
            }
            else
            {
                responseString = $"{GetHttpStatusCode(response.StatusCode)}\r\n {response.Payload}!";
            }

            var responseBytes = Encoding.UTF8.GetBytes(responseString);

            stream.Write(responseBytes, 0, responseBytes.Length);
            stream.Flush();

            Console.WriteLine("Response Sent:" + responseString);
        }

        //Parst die Anfrage, extrahiert Methode, Pfad und Payload und gibt ein RequestContext-Objekt zurück
        private RequestContext? ParseRequest(string requestString)
        {
            var lines = requestString.Split("\r\n");
            if (lines.Length > 0)
            {
                var parts = lines[0].Split(' ');
                if (parts.Length >= 2)
                {
                    var methodString = parts[0];
                    var path = parts[1];

                    if (Enum.TryParse<HTTPMethod>(methodString, true, out var method))
                    {
                        var body = lines.LastOrDefault();

                        return new RequestContext
                        {
                            Method = method,
                            ResourcePath = path,
                            Payload = body
                        };
                    }
                }
            }
            return null;
        }

        //Gibt den entsprechenden HTTP-Statuscode als Text basierend auf dem StatusCode zurück
        private string GetHttpStatusCode(StatusCode statusCode)
        {
            return statusCode switch
            {
                StatusCode.Ok => "200 OK",
                StatusCode.Created => "201 Created",
                StatusCode.Accepted => "202 Accepted",
                StatusCode.NoContent => "204 No Content",
                StatusCode.BadRequest => "400 Bad Request",
                StatusCode.Unauthorized => "401 Unauthorized",
                StatusCode.Forbidden => "403 Forbidden",
                StatusCode.NotFound => "404 Not Found",
                StatusCode.Conflict => "409 Conflict",
                StatusCode.InternalServerError => "500 Internal Server Error",
                StatusCode.NotImplemented => "501 Not Implemented",
                //Gibt standardmäßig "500 Internal Server Error" zurück, wenn der StatusCode nicht übereinstimmt.
                _ => "500 Internal Server Error"
            };
        }
    }
}
