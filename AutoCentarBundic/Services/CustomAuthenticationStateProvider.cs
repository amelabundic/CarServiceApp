using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.JSInterop;
using System.Security.Claims;

namespace AutoCentarBundic.Services
{
    public class CustomAuthenticationStateProvider : AuthenticationStateProvider
    {
        private readonly IJSRuntime jsRuntime;
        private ClaimsPrincipal _user = new ClaimsPrincipal(new ClaimsIdentity());
        private bool _initialized = false;

        public CustomAuthenticationStateProvider(IJSRuntime jsRuntime)
        {
            this.jsRuntime = jsRuntime;
        }

        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            // Ako već nismo inicijalizovali, pokušaj čitati iz sessionStorage
            if (!_initialized)
            {
                try
                {
                    var email = await jsRuntime.InvokeAsync<string>("sessionStorage.getItem", "userEmail");

                    if (!string.IsNullOrEmpty(email))
                    {
                        var identity = new ClaimsIdentity(new[]
                        {
                            new Claim(ClaimTypes.Name, email),
                            new Claim(ClaimTypes.Email, email)
                        }, "apiauth_type");

                        _user = new ClaimsPrincipal(identity);
                    }

                    _initialized = true;
                }
                catch
                {
                    // Ako se desi prerendering -> ignoriši, pokušaće kasnije
                }
            }

            return new AuthenticationState(_user);
        }

        public async Task MarkUserAsAuthenticated(string email)
        {
            var identity = new ClaimsIdentity(new[]
            {
                new Claim(ClaimTypes.Name, email),
                new Claim(ClaimTypes.Email, email)
            }, "apiauth_type");

            _user = new ClaimsPrincipal(identity);

            try
            {
                await jsRuntime.InvokeVoidAsync("sessionStorage.setItem", "userEmail", email);
            }
            catch
            {
                // ako prerendering -> preskoči, ali user ostaje prijavljen
            }

            NotifyAuthenticationStateChanged(GetAuthenticationStateAsync());
        }

        public async Task MarkUserAsLoggedOut()
        {
            _user = new ClaimsPrincipal(new ClaimsIdentity());

            try
            {
                await jsRuntime.InvokeVoidAsync("sessionStorage.removeItem", "userEmail");
            }
            catch
            {
                // ignorisati ako prerendering
            }

            NotifyAuthenticationStateChanged(GetAuthenticationStateAsync());
        }
    }
}




//using AutoCentarBundic.Data;
//using Microsoft.AspNetCore.Components.Authorization;
//using System.Security.Claims;

//namespace AutoCentarBundic.Services
//{
//    public class CustomAuthenticationStateProvider : AuthenticationStateProvider
//    {
//        private ClaimsPrincipal _user = new ClaimsPrincipal(new ClaimsIdentity());

//        public override Task<AuthenticationState> GetAuthenticationStateAsync()
//        {
//            return Task.FromResult(new AuthenticationState(_user));
//        }

//        public async Task MarkUserAsAuthenticated(string email)
//        {
//            var identity = new ClaimsIdentity(new[]
//            {
//                new Claim(ClaimTypes.Name, email),
//                new Claim(ClaimTypes.Email, email)   // Dodali Email claim
//            }, "apiauth_type");

//            _user = new ClaimsPrincipal(identity);
//            NotifyAuthenticationStateChanged(GetAuthenticationStateAsync());
//        }

//        public void MarkUserAsLoggedOut()
//        {
//            _user = new ClaimsPrincipal(new ClaimsIdentity());
//            NotifyAuthenticationStateChanged(GetAuthenticationStateAsync());
//        }
//    }
//}
