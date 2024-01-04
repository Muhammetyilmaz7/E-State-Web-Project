using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using BusinessLayer.ValidationRules;
using EntityLayer.Entities;
using FluentValidation.Results;

namespace Estate.UI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class NeighbourhoodController : Controller
    {
        NeighbourhoodService neighbourhoodService;
        DistrictService districtService;

        public NeighbourhoodController(NeighbourhoodService neighbourhoodService, DistrictService districtService)
        {
            this.neighbourhoodService = neighbourhoodService;
            this.districtService = districtService;
        }

        public IActionResult Index()
        {
            var list = neighbourhoodService.List(x => x.Status == true);
            return View(list);
        }
        public IActionResult Create()
        {
            DropDown();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Neighbourhood data)
        {
            NeighbourhoodValidation validationRules = new NeighbourhoodValidation();
            ValidationResult result = validationRules.Validate(data);
            if (result.IsValid)
            {
                neighbourhoodService.Add(data);
                TempData["Success"] = "Mahalle Ekleme İşlemi Başarıyla Gerçekleşti";
                return RedirectToAction("Index");
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);

                }
            }
            DropDown();
            return View();
        }

        public IActionResult Delete(int id)
        {
            var neigh = neighbourhoodService.GetById(id);
            neighbourhoodService.Delete(neigh);
            return RedirectToAction("Index");
        }

        public IActionResult Update(int id)
        {
            DropDown();
            var neigh = neighbourhoodService.GetById(id);
            return View(neigh);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(Neighbourhood data)
        {
            NeighbourhoodValidation validationRules = new NeighbourhoodValidation();
            ValidationResult result = validationRules.Validate(data);
            if (result.IsValid)
            {
                neighbourhoodService.Update(data);
                TempData["Update"] = "Mahalle Güncelleme İşlemi Başarıyla Gerçekleşti";
                return RedirectToAction("Index");
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);

                }
            }
            DropDown();
            return View();
        }
        public void DropDown()
        {
            List<SelectListItem> value = (from i in districtService.List(x => x.Status == true).ToList()
                                          select new SelectListItem
                                          {
                                              Text = i.DistrictName,
                                              Value = i.DistrictId.ToString()
                                          }).ToList();

            ViewBag.district = value;
        }
    }
}
