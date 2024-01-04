using BusinessLayer.Abstract;
using EntityLayer.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace E_State.UI.Controllers
{
    public class AdvertController : Controller
    {
        ImagesService im;
        AdvertService advert;
        CityService cityService;
        DistrictService districtService;
        NeighbourhoodService neighbourhoodService;
        SituationService situationService;
        TypeService typeService;

        public AdvertController(ImagesService im, AdvertService advert, CityService cityService, DistrictService districtService, NeighbourhoodService neighbourhoodService, SituationService situationService, TypeService typeService)
        {
            this.im = im;
            this.advert = advert;
            this.cityService = cityService;
            this.districtService = districtService;
            this.situationService = situationService;
            this.typeService = typeService;
            this.neighbourhoodService = neighbourhoodService;
        }

        public IActionResult Details2(int id)
        {
            var detail = advert.GetById(id);

            var image = im.List(x => x.AdvertId == id);
            ViewBag.imgs = image;
            return View(detail);
        }

        public IActionResult Details(int id)
        {
            var detail = advert.GetById(id);

            var image = im.List(x => x.AdvertId == id);
            ViewBag.imgs = image;
            return View(detail);
        }
        public IActionResult AdvertRent()
        {
            DropDown();
            var rent = advert.List(x => x.Type.Situation.SituationName == "Kiralık");

            var images = im.List(x => x.Status == true);
            ViewBag.imgs = images;
            return View(rent);
        }

        public IActionResult AdvertSale()
        {
            DropDown();
            var rent = advert.List(x => x.Type.Situation.SituationName == "Satılık");

            var images = im.List(x => x.Status == true);
            ViewBag.imgs = images;
            return View(rent);
        }


        public List<City> CityGet()
        {
            List<City> cities = cityService.List(x => x.Status == true);
            return cities;
        }
        public List<Situation> SituationGet()
        {
            List<Situation> situation = situationService.List(x => x.Status == true);
            return situation;
        }



        public void DropDown()
        {
            ViewBag.citylist = new SelectList(CityGet(), "CityId", "CityName");
            ViewBag.situations = new SelectList(SituationGet(), "SituationId", "SituationName");

            List<SelectListItem> value1 = (from i in districtService.List(X => X.Status == true)
                                           select new SelectListItem
                                           {
                                               Text = i.DistrictName,
                                               Value = i.DistrictId.ToString()
                                           }).ToList();
            ViewBag.district = value1;

            List<SelectListItem> value2 = (from i in neighbourhoodService.List(x => x.Status == true)
                                           select new SelectListItem
                                           {
                                               Text = i.NeighbourhoodName,
                                               Value = i.NeighbourhoodId.ToString()
                                           }).ToList();
            ViewBag.neighbourhood = value2;
            List<SelectListItem> value3 = (from i in typeService.List(x => x.Status == true)
                                           select new SelectListItem
                                           {
                                               Text = i.TypeName,
                                               Value = i.TypeId.ToString()
                                           }).ToList();
            ViewBag.type = value3;

            List<SelectListItem> value4 = (from i in situationService.List(x => x.Status == true)
                                           select new SelectListItem
                                           {
                                               Text = i.SituationName,
                                               Value = i.SituationId.ToString()
                                           }).ToList();
            ViewBag.situation = value4;
        }

        public IActionResult Create()
        {
            return View();
        }
    }
}
