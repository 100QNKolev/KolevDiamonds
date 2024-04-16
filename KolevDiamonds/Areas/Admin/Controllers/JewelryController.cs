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
using KolevDiamonds.Infrastructure.Data.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Security.Claims;
using static KolevDiamonds.Core.Constants.JewelryConstants;


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
            IAdminJewelryServiceContract adminJewelryService
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
            else
            {
                return BadRequest();
            }

            return RedirectToAction(nameof(All));
        }

        [HttpGet]
        public async Task<IActionResult> Add([FromQuery] AdminQueryModel query)
        {
            return View(query);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id, string productType)
        {
            object model;
            object query;

            if (!User.isAdmin())
            {
                return BadRequest("User is not authorized.");
            }

            switch (productType)
            {
                case "Ring":
                    model = await this._ringService.GetByIdAsync(id);
                    var ringModel = model as Ring;
                    if (ringModel == null)
                    {
                        return BadRequest("Invalid model type for Ring.");
                    }
                    query = new RingModel
                    {
                        Id = id,
                        Name = ringModel.Name,
                        ImagePath = ringModel.ImagePath,
                        Price = ringModel.Price,
                        Carats = ringModel.Carats,
                        Colour = ringModel.Colour,
                        Clarity = ringModel.Clarity,
                        Cut = ringModel.Cut,
                        Metal = ringModel.Metal,
                        Purity = ringModel.Purity,
                        IsForSale = ringModel.IsForSale
                    };
                    ViewBag.Category = "Ring";
                    break;

                case "Necklace":
                    model = await this._necklaceService.GetByIdAsync(id);
                    var necklaceModel = model as Necklace;
                    if (necklaceModel == null)
                    {
                        return BadRequest("Invalid model type for Necklace.");
                    }
                    query = new NecklaceModel
                    {
                        Id = id,
                        Name = necklaceModel.Name,
                        ImagePath = necklaceModel.ImagePath,
                        Price = necklaceModel.Price,
                        Carats = necklaceModel.Carats,
                        Colour = necklaceModel.Colour,
                        Clarity = necklaceModel.Clarity,
                        Cut = necklaceModel.Cut,
                        Metal = necklaceModel.Metal,
                        Purity = necklaceModel.Purity,
                        IsForSale = necklaceModel.IsForSale,
                        Length = necklaceModel.Length
                    };
                    ViewBag.Category = "Necklace";
                    break;

                case "MetalBar":
                    model = await this._metalBarService.GetByIdAsync(id);
                    var metalBarModel = model as MetalBar;
                    if (metalBarModel == null)
                    {
                        return BadRequest("Invalid model type for MetalBar.");
                    }
                    query = new MetalBarModel
                    {
                        Id = id,
                        Name = metalBarModel.Name,
                        ImagePath = metalBarModel.ImagePath,
                        Price = metalBarModel.Price,
                        Metal = metalBarModel.Metal,
                        Purity = metalBarModel.Purity,
                        IsForSale = metalBarModel.IsForSale,
                        Weight = metalBarModel.Weight,
                        Dimensions = metalBarModel.Dimensions
                    };
                    ViewBag.Category = "MetalBar";
                    break;

                case "InvestmentDiamond":
                    model = await this._investmentDiamondService.GetByIdAsync(id);
                    var investmentDiamondModel = model as InvestmentDiamond;
                    if (investmentDiamondModel == null)
                    {
                        return BadRequest("Invalid model type for InvestmentDiamond.");
                    }
                    query = new InvestmentDiamondModel
                    {
                        Id = id,
                        Name = investmentDiamondModel.Name,
                        ImagePath = investmentDiamondModel.ImagePath,
                        Price = investmentDiamondModel.Price,
                        Carats = investmentDiamondModel.Carats,
                        Colour = investmentDiamondModel.Colour,
                        Clarity = investmentDiamondModel.Clarity,
                        Cut = investmentDiamondModel.Cut,
                        CertifyingLaboratory = investmentDiamondModel.CertifyingLaboratory,
                        Proportions = investmentDiamondModel.Proportions,
                        IsForSale = investmentDiamondModel.IsForSale
                    };
                    ViewBag.Category = "InvestmentDiamond";
                    break;

                case "InvestmentCoin":
                    model = await this._investmentCoinService.GetByIdAsync(id);
                    var investmentCoinModel = model as InvestmentCoin;
                    if (investmentCoinModel == null)
                    {
                        return BadRequest("Invalid model type for InvestmentCoin.");
                    }
                    query = new InvestmentCoinModel
                    {
                        Id = id,
                        Name = investmentCoinModel.Name,
                        ImagePath = investmentCoinModel.ImagePath,
                        Price = investmentCoinModel.Price,
                        Metal = investmentCoinModel.Metal,
                        Purity = investmentCoinModel.Purity,
                        Weight = investmentCoinModel.Weight,
                        Quality = investmentCoinModel.Quality,
                        Circulation = investmentCoinModel.Circulation,
                        Diameter = investmentCoinModel.Diameter,
                        LegalTender = investmentCoinModel.LegalTender,
                        Manufacturer = investmentCoinModel.Manufacturer,
                        Packaging = investmentCoinModel.Packaging,
                        IsForSale = investmentCoinModel.IsForSale
                    };
                    ViewBag.Category = "InvestmentCoin";
                    break;

                default:
                    return BadRequest("Invalid product type.");
            }

            return View(query);
        }

        [HttpPost]
        public async Task<IActionResult> EditRing(RingModel model)
        {
            if (ModelState.IsValid)
            {
                var modelErrors = GetModelErrors(model);
                if (modelErrors.Count > 0)
                {
                    // Pass model errors to the view
                    ViewBag.ModelErrors = modelErrors;
                    return View(model);
                }

                if (model != null)
                {
                    await ProcessForm(model, this._ringService, (int)model.Id!);
                    return RedirectToAction(nameof(All));
                }
                else
                {
                    return BadRequest("Invalid model");
                }
            }
            else
            {
                // ModelState is not valid, return the form with errors
                return View("_RingDetailsProductCardPartial", model);
            }
        }

        [HttpPost]
        public async Task<IActionResult> EditNecklace(NecklaceModel model)
        {
            if (ModelState.IsValid)
            {
                var modelErrors = GetModelErrors(model);
                if (modelErrors.Count > 0)
                {
                    // Pass model errors to the view
                    ViewBag.ModelErrors = modelErrors;
                    return View(model);
                }

                if (model != null)
                {
                    await ProcessForm(model, this._necklaceService, (int)model.Id!);
                    return RedirectToAction(nameof(All));
                }
                else
                {
                    return BadRequest("Invalid model");
                }
            }
            else
            {
                // ModelState is not valid, return the form with errors
                return View("_NecklaceDetailsProductCardPartial", model);
            }
        }

        [HttpPost]
        public async Task<IActionResult> EditMetalBar(MetalBarModel model)
        {
            if (ModelState.IsValid)
            {
                var modelErrors = GetModelErrors(model);
                if (modelErrors.Count > 0)
                {
                    // Pass model errors to the view
                    ViewBag.ModelErrors = modelErrors;
                    return View(model);
                }

                if (model != null)
                {
                    await ProcessForm(model, this._metalBarService, (int)model.Id!);
                    return RedirectToAction(nameof(All));
                }
                else
                {
                    return BadRequest("Invalid model");
                }
            }
            else
            {
                // ModelState is not valid, return the form with errors
                return View("_MetalBarDetailsProductCardPartial", model);
            }
        }

        [HttpPost]
        public async Task<IActionResult> EditInvestmentDiamond(InvestmentDiamondModel model)
        {
            if (ModelState.IsValid)
            {
                var modelErrors = GetModelErrors(model);
                if (modelErrors.Count > 0)
                {
                    // Pass model errors to the view
                    ViewBag.ModelErrors = modelErrors;
                    return View(model);
                }

                if (model != null)
                {
                    await ProcessForm(model, this._investmentDiamondService, (int)model.Id!);
                    return RedirectToAction(nameof(All));
                }
                else
                {
                    return BadRequest("Invalid model");
                }
            }
            else
            {
                // ModelState is not valid, return the form with errors
                return View("_InvestmentDiamondDetailsProductCardPartial", model);
            }
        }

        [HttpPost]
        public async Task<IActionResult> EditInvestmentCoin(InvestmentCoinModel model)
        {
            if (ModelState.IsValid)
            {
                var modelErrors = GetModelErrors(model);
                if (modelErrors.Count > 0)
                {
                    // Pass model errors to the view
                    ViewBag.ModelErrors = modelErrors;
                    return View(model);
                }

                if (model != null)
                {
                    await ProcessForm(model, this._investmentCoinService, (int)model.Id!);
                    return RedirectToAction(nameof(All));
                }
                else
                {
                    return BadRequest("Invalid model");
                }
            }
            else
            {
                // ModelState is not valid, return the form with errors
                return View("_InvestmentCoinDetailsProductCardPartial", model);
            }
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

        [NonAction]
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
        private async Task<IActionResult> ProcessForm<T>(T model, IService<T> service, int id)
        {
            var modelErrors = GetModelErrors(model);
            if (modelErrors.Any())
            {
                // Model validation failed, return validation errors
                return Json(new { success = false, errors = modelErrors });
            }

            try
            {
                await service.Update(id, model);
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
