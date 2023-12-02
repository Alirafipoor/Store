using System.Security.Claims;

namespace Store.Utilities
{
    public static class ClaimUtility
    {
        public static long? GetUserId(ClaimsPrincipal user)
        {
            try
            {
                var ClaimIdentity = user.Identity as ClaimsIdentity;
                long userid = long.Parse(ClaimIdentity.FindFirst(ClaimTypes.NameIdentifier).Value);
                return userid;
            }
            catch(Exception ) {
                return null;
            
            }

            
        }
    }
}
