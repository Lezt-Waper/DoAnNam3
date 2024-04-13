using System.Globalization;
using RSA_Encrypt;
using RSA_Encrypt.RSALib;

namespace WebApplication1.Middleware
{
    public class RSAEncryptMiddleware
    {
        private readonly RequestDelegate _next;
        private RSA serverRSA;

        public RSAEncryptMiddleware(RequestDelegate next)
        {
            this._next = next;
            serverRSA = new RSA();
        }

        public async Task InvokeAsync(HttpContext context)
        {
            //Request 

            await _next(context);

            //Response
        }
    }
}
