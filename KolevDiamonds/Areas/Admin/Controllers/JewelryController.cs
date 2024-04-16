using KolevDiamonds.Core.Contracts;
using KolevDiamonds.Core.Contracts.InvestmentCoin;
using KolevDiamonds.Core.Contracts.InvestmentDiamond;
using KolevDiamonds.Core.Contracts.MetalBar;
using KolevDiamonds.Core.Contracts.Necklace;
using KolevDiamonds.Core.Contracts.Ring;
using KolevDiamonds.Core.Models;
using KolevDiamonds.Core.Models.Admin;
using KolevDiamonds.Core.Models.InvestmentCoin;
using KolevDiamonds.Core.Models.InvestmentDiamond;
using KolevDiamonds.Core.Models.MetalBar;
using KolevDiamonds.Core.Models.Necklace;
using KolevDiamonds.Core.Models.Ring;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Security.Claims;
using KolevDiamonds.Areas.Admin.Services;
using static KolevDiamonds.Areas.Admin.Constants.JewelryConstants;
using KolevDiamonds.Areas.Admin.Contracts;

namespace KolevDiamonds.Areas.Admin.Controllers
{
    public class JewelryController : AdminBaseController
    {
        private readonly IRingService _ringService;
        private readonly INecklaceService _necklaceService;
        private readonly IMetalBarService _metalBarService;
        private readonly IInvestmentDiamondService _investmentDiamondService;
        private readonly IInvestmentCoinService _investmentCoinService;
        private readonly IAdminJewelryServiceContract _adminJewelryService;

        public JewelryController(
            IRingService ringService,
            INecklaceService necklaceService,
            IMetalBarService metalBarService,
            IInvestmentDiamondService investmentDiamondService,
            IInvestmentCoinService investmentCoinService,
            IAdminJewelryServiceContract adminJewelryService,
            )
        {
            this._ringService = ringService;
            this._necklaceService = necklaceService;
            this._metalBarService = metalBarService;
            this._investmentCoinService = investmentCoinService;
            this._investmentDiamondService = investmentDiamondService;
            this._adminJewelryService = adminJewelryService;
        }

        [HttpGet]
        public async Task<IActionResult> All([FromQuery] ProductQueryModel query)
        {
            var model = new ProductQueryModel { Products = await this._adminJewelryService.GetAllJewelry(query) };

            query.TotalProductCount = model.TotalProductCount;
            query.Products = model.Products;
            query.ProductType = JewelryQueryProductType;

            return View(query);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id, string productType)
        {
            if (User.isAdmin())
            {
                switch (productType)
                {
                    case "Ring":
                        await this._ringService.Delete(id);
                        break;

                    case "Necklace":
                        await this._necklaceService.Delete(id);
                        break;

                    case "MetalBar":
                        await this._metalBarService.Delete(id);
                        break;

                    case "InvestmentDiamond":
                        await this._investmentDiamondService.Delete(id);
                        break;

                    case "InvestmentCoin":
                        await this._investmentCoinService.Delete(id);
                        break;
                    default:
                        return BadRequest();
                }
            }

            return RedirectToAction(nameof(All));
        }


        [HttpGet]
        public async Task<IActionResult> Add([FromQuery] AdminQueryModel query)
        {
            return View(query);
        }

        [HttpPost]
        public async Task<IActionResult> SubmitRingForm(RingModel model)
        {
            return await ProcessForm(model, _ringService);
        }

        [HttpPost]
        public async Task<IActionResult> SubmitNecklaceForm(NecklaceModel model)
        {
            return await ProcessForm(model, _necklaceService);
        }

        [HttpPost]
        public async Task<IActionResult> SubmitMetalBarForm(MetalBarModel model)
        {
            return await ProcessForm(model, _metalBarService);
        }

        [HttpPost]
        public async Task<IActionResult> SubmitInvestmentDiamondForm(InvestmentDiamondModel model)
        {
            return await ProcessForm(model, _investmentDiamondService);
        }

        [HttpPost]
        public async Task<IActionResult> SubmitInvestmentCoinForm(InvestmentCoinModel model)
        {
            return await ProcessForm(model, _investmentCoinService);
        }

        private async Task<IActionResult> ProcessForm<T>(T model, IService<T> service)
        {
            var modelErrors = GetModelErrors(model);
            if (modelErrors.Any())
            {
                // Model validation failed, return validation errors
                return Json(new { success = false, errors = modelErrors });
            }

            try
            {
                await service.Create(model);
                return Json(new { success = true, message = "Operation completed successfully" });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = "An error occurred while processing the request: " + ex.Message });
            }
        }

        [NonAction]
        private List<string> GetModelErrors<T>(T model)
        {
            var modelState = new ModelStateDictionary();

            // Validate the model
            TryValidateModel(model);

            // Check if the model is valid
            if (!ModelState.IsValid)
            {
                // Model validation failed, collect validation errors
                return ModelState.Values
                    .SelectMany(v => v.Errors)
                    .Select(e => e.ErrorMessage)
                    .ToList();
            }

            return new List<string>(); // No errors
        }
    }
}
