using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KolevDiamonds.Web.Areas.Admin
{
    [Comment("Admin constants")]
    public static class AdminConstants
    {
        [Comment("Role name for administrator")]
        public const string AdminRoleName = "Administrator";

        [Comment("Administrator's email")]
        public const string AdminEmail = "admin@gmail.com";

        [Comment("Administrator's area name")]
        public const string AdminAreaName = "Admin";
    }
}
