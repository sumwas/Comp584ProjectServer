using Microsoft.AspNetCore.Identity;

namespace Comp584ProjectServer.Repositories.Interface
{
    public interface ITokenRepository
    {
        string CreateJwtToken(IdentityUser user, List<string> roles);
    }
}
