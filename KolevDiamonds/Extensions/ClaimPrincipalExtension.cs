using static KolevDiamonds.Infrastructure.Data.Models.AdminUser;

namespace System.Security.Claims
{
    public static class ClaimPrincipalExtension
    {
        public static bool isAdmin(this ClaimsPrincipal user) 
        {
            return user.IsInRole(AdminRoleName);
        }
    }
}
