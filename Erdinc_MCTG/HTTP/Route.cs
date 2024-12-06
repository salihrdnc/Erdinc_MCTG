using Erdinc_MCTG.DB;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Erdinc_MCTG.HTTP;

namespace Erdinc_MCTG.HTTP
{
    public class Route
    {
        private readonly Dictionary<(HTTPMethod method, string resourcePath),Func<RequestContext, IRouteCommand>> routes;

        public Route()
        {
            //Initialisiert alle bekannten Routen
            routes = new Dictionary<(HTTPMethod, string), Func<RequestContext, IRouteCommand>>
            {
                { (HTTPMethod.Post, "/users"), request => new Register(request) },
                { (HTTPMethod.Post, "/sessions"), request => new Login(request) },
            };
        }

        public IRouteCommand? Resolve(RequestContext request)
        {
            if (request == null)
            {
                throw new ArgumentNullException(nameof(request), "Request cannot be null.");
            }

            if (routes.TryGetValue((request.Method, request.ResourcePath), out var routeHandler))
            {
                return routeHandler(request);
            }

            Console.WriteLine($"No matching route found for Method: {request.Method} and Path: {request.ResourcePath}");
            return null;
        }

        //Diese Methode stellt sicher, dass der Payload-Body nicht null ist
        private string EnsureBody(string? body)
        {
            if (body == null)
            {
                throw new InvalidDataException("Request body cannot be null.");
            }
            return body;
        }

        //Deserialisiert den JSON-Body in das angegebene Typ-Objekt
        private T Deserialize<T>(string? body) where T : class
        {
            if (string.IsNullOrEmpty(body))
            {
                throw new InvalidDataException("Request body is empty or null.");
            }

            var data = JsonConvert.DeserializeObject<T>(body);
            if (data == null)
            {
                throw new InvalidDataException("Failed to deserialize request body.");
            }
            return data;
        }
    }
}