using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class AdvertManager : AdvertService
    {
        IAdvertRepository _advertRepository;

        public AdvertManager(IAdvertRepository advertRepository)
        {
            _advertRepository = advertRepository;
        }

        public void Add(Advert p)
        {
            p.Status = true;
            p.AdvertDate = DateTime.Now;
            _advertRepository.Add(p);
        }

        public void Delete(Advert p)
        {
            var delete = _advertRepository.GetById(p.AdvertId);
            p.Status = false;
            _advertRepository.Update(delete);
        }

        public void FullDelete(Advert p)
        {
            var delete = _advertRepository.GetById(p.AdvertId);
            _advertRepository.FullDelete(delete);
        }

        public Advert GetById(int id)
        {
            return _advertRepository.GetById(id);
        }

        public List<Advert> List()
        {
            return _advertRepository.List();
        }

        public List<Advert> List(Expression<Func<Advert, bool>> filter)
        {
            return _advertRepository.List(filter);
        }

        public void RestoreDelete(Advert p)
        {
            var delete = _advertRepository.GetById(p.AdvertId);
            p.Status = true;
            _advertRepository.Update(delete);
        }

        public void Update(Advert p)
        {
            var advert = _advertRepository.GetById(p.AdvertId);
            advert.Address = p.Address;
            advert.Description = p.Description;
            advert.BathroomNumbers = p.BathroomNumbers;
            advert.NumberOfooms = p.NumberOfooms;
            advert.Floor = p.Floor;
            advert.AirCordinator = p.AirCordinator;
            advert.NumberOfooms = p.NumberOfooms;
            advert.Garage = p.Garage;
            advert.Garden = p.Garden;
            advert.Furniture = p.Furniture;
            advert.Fireplace = p.Fireplace;
            advert.Area = p.Area;
            advert.Pool = p.Pool;
            advert.Teras = p.Teras;
            advert.DistrictId = p.DistrictId;
            advert.CityId = p.CityId;
            advert.NeighbourhoodId = p.NeighbourhoodId;
            advert.PhoneNumber = p.PhoneNumber;
            advert.AdvertDate = DateTime.Now;
            _advertRepository.Update(advert);
        }
    }
}
