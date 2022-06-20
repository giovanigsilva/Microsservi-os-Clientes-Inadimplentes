using Duende.IdentityServer;
using Duende.IdentityServer.Models;

namespace VInadiplentes.IdentityServer.Configuration
{
    public class IdentityConfiguration
    {
        public const string Admin = "Admin";
        public const string Client = "Client";

        public static IEnumerable<IdentityResource> IdentityResources =>
            new List<IdentityResource>
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Email(),
                new IdentityResources.Profile()
            };
        public static IEnumerable<ApiScope> ApiScopes =>
            new List<ApiScope>
            {
                new ApiScope("ClientesApi", "Clientes Server"),
                new ApiScope(name: "read", "read data"),
                new ApiScope(name: "write", "write data"),
                new ApiScope(name: "delete", "delete data"),

            };
        public static IEnumerable<Client> Clients =>
            new List<Client>
            {
                new Client
                {
                    ClientId = "client",
                    ClientSecrets = {new Secret("abracadabra#simsalabim".Sha256())},
                    AllowedGrantTypes = GrantTypes.ClientCredentials,
                    AllowedScopes = {"read", "write","profile"}
                },
                new Client
                {
                    ClientId = "vshop",
                    ClientSecrets = {new Secret("abracadabra#simsalabim".Sha256())},
                    AllowedGrantTypes = GrantTypes.ClientCredentials,
                    RedirectUris = {"https://localhost:7165/signin-oidc" },
                    PostLogoutRedirectUris = {"https://localhost:7165/signout-callback-oidc" },
                    AllowedScopes = new List<string>
                    {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        IdentityServerConstants.StandardScopes.Email,
                        "vshop"
                    }

                }
            };

    }
}
