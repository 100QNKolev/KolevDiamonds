using static KolevDiamonds.Areas.Admin.Constants.AdminConstants;

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
