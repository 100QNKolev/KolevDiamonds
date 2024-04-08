using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static KolevDiamonds.Web.Areas.Admin.AdminConstants;

namespace KolevDiamonds.Areas.Admin.Controllers
{
    [Area(AdminAreaName)]
    [Authorize(Roles = AdminRoleName)]
    public class AdminBaseController : Controller
    {
       
    }
}
