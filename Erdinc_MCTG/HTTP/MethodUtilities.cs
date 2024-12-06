using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Erdinc_MCTG.HTTP;

namespace Erdinc_MCTG.HTTP
{
    //Definiert die möglichen HTTP-Methoden, die verwendet werden können
    public enum HTTPMethod
    {
        Get,
        Post,
        Put,
        Delete,
        Patch
    }
    public static class MethodUtilities
    {
        public static Response? Response { get; private set; }

        // Methode zur Bestimmung der HTTP-Methode aus einem String
        public static HTTPMethod GetMethod(string method)
        {
            //Konvertiert die übergebene Methode in eine der bekannten HTTP-Methoden
            return method.ToUpperInvariant() switch
            {
                "GET" => HTTPMethod.Get,
                "POST" => HTTPMethod.Post,
                "PUT" => HTTPMethod.Put,
                "DELETE" => HTTPMethod.Delete,
                "PATCH" => HTTPMethod.Patch,
                _ => throw new InvalidDataException($"Unknown HTTP Method:{method}")
            };
        }
    }
}
