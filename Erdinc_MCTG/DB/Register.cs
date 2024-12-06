using Erdinc_MCTG.HTTP;
using Erdinc_MCTG.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Erdinc_MCTG.DB
{
    public class Register : IRouteCommand
    {
        private User user;
        private readonly RequestContext requestContext;
        private Database db;

        public Register(RequestContext request)
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
        public PwHasher PwHasher { get; set; }

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
                // Versuche, den Benutzer in der Datenbank zu registrieren
                if (db.CheckAndRegister(user))
                {
                    // Wenn die Registrierung erfolgreich war, setze die Payload und den StatusCode auf Created
                    response.Payload = "User created successfully";
                    response.StatusCode = StatusCode.Created;
                }
                else
                {
                    // Wenn die Registrierung fehlschlägt, setze die Payload und den StatusCode auf BadRequest
                    response.Payload = "User could not be created";
                    response.StatusCode = StatusCode.BadRequest;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error during user registration: {ex.Message}");
                response.Payload = "Internal server error";
                response.StatusCode = StatusCode.InternalServerError;
            }

            return response;
        }

        public void SetDataBase(Database db)
        {
            this.db = db ?? throw new ArgumentNullException(nameof(db), "Database cannot be null");
        }
    }
}

