using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static KolevDiamonds.Areas.Admin.Constants.AdminConstants;

namespace KolevDiamonds.Areas.Admin.Controllers
{
    [Area(AdminAreaName)]
    [Authorize(Roles = AdminRoleName)]
    public class AdminBaseController : Controller
    {
       
    }
}
