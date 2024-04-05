using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KolevDiamonds.Infrastructure.Data.Models
{
    [Comment("Admin user details")]
    public class AdminUser
    {
        [Comment("Role name for administrator")]
        public const string AdminRoleName = "Administrator";

        [Comment("Administrator's email")]
        public const string AdminEmail = "admin@gmail.com";
    }
}
