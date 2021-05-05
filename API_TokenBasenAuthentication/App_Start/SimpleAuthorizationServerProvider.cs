using Microsoft.Owin.Security.OAuth;
using System.Security.Claims;
using System.Threading.Tasks;

namespace API_TokenBasenAuthentication.App_Start
{
    internal class SimpleAuthorizationServerProvider : OAuthAuthorizationServerProvider
    {
        public override async Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            context.Validated();
        }

        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            context.OwinContext.Response.Headers.Add("Access-Control-Allow-Origin", new[] { "*" });
            
            // Kullanıcının access_token alabilmesi için gerekli validation işlemlerini yapıyoruz.
            if (context.UserName == "test" && context.Password == "123")
            {
                // Oturum Açan kullanıcının talep edildiğinde erişilmesi istenen claimlerini oluşturuyoruz. Kullanıcıya name ve role özellikleri verdik. Authenticated olan kullanıcıdan bu bilgileri talep edebiliriz.
              var identity = new ClaimsIdentity(context.Options.AuthenticationType);

                identity.AddClaim(new Claim("username", context.UserName));
                identity.AddClaim(new Claim("role", "user"));

                context.Validated(identity);
            }
            else
            {
                // Eğer kullanıcı validasyondan geçemezse bu durumda erşim	yetkisi	olmadığına	dair invalid_grant ile 401 UnAuthorized HttpStatusCode Response Body olarak gönderilir.	
                context.SetError("invalid_grant", "Kullanıcı Adı veya Parola Yanlış!");
            }
        }
    }
}