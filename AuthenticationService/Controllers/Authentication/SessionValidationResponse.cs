using System;
namespace AuthenticationService.Controllers.Authentication
{
    public class SessionValidationResponse
    {
        public bool success { get; set; }
        public bool failure { get; set; }
        public string mensaje { get; set; }
    }
}

