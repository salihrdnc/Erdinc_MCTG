﻿using Erdinc_MCTG.HTTP;
using Erdinc_MCTG.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Erdinc_MCTG.DB;

namespace Erdinc_MCTG.DB
{
    public class Login : IRouteCommand
    {
        private readonly User user;
        private readonly RequestContext requestContext;
        private Database db;

        public Login(RequestContext request)
        {
            // Setze den RequestContext und prüfe, ob dieser nicht null ist
            requestContext = request ?? throw new ArgumentNullException(nameof(request), "Request context cannot be null");

            // Überprüfe, ob das Payload nicht null oder leer ist
            if (string.IsNullOrEmpty(requestContext.Payload))
            {
                throw new InvalidDataException("Payload cannot be null or empty.");
            }

            // Deserialisiere die Benutzerdaten aus dem Payload
            user = JsonConvert.DeserializeObject<User>(requestContext.Payload) ?? throw new InvalidDataException("Invalid user data in the payload.");
        }
        public IRoute IRoute
        {
            get => default;
            set { }
        }
        public Response Execute()
        {
            // Überprüfe, ob die Datenbankverbindung gesetzt wurde, bevor mit der Ausführung fortgefahren wird
            if (db == null)
            {
                throw new InvalidOperationException("Database connection has not been set.");
            }

            var response = new Response();
            try
            {
                // Versuche, den Benutzer über die Datenbank anzumelden
                if (db.Logging(user))
                {
                    // Wenn die Anmeldung erfolgreich war, setze die Payload und den StatusCode auf OK
                    response.Payload = "User successfully logged in";
                    response.StatusCode = StatusCode.Ok;
                }
                else
                {
                    // Wenn die Anmeldung fehlschlägt, setze die Payload und den StatusCode auf Unauthorized
                    response.Payload = "Invalid username or password";
                    response.StatusCode = StatusCode.Unauthorized; // 401 Unauthorized passt besser zu einem Login-Fehler
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error during user login: {ex.Message}");
                response.Payload = "Internal server error";
                response.StatusCode = StatusCode.InternalServerError;
            }

            return response;
        }

        public void SetDataBase(Database db)
        {
            // Setze die Datenbankinstanz und prüfe, ob diese nicht null ist
            this.db = db ?? throw new ArgumentNullException(nameof(db), "Database cannot be null");
        }
    }
}
