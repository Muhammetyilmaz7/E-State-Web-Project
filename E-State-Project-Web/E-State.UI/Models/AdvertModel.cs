using System.ComponentModel.DataAnnotations.Schema;

namespace E_State.UI.Models
{
    public class AdvertModel
    {
        public int AdvertId { get; set; }

        public string AdvertTitle { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public string Garage { get; set; }
        public bool Garden { get; set; }
        public bool Fireplace { get; set; }
        public bool Furniture { get; set; }
        public bool Pool { get; set; }
        public bool Teras { get; set; }
        public bool AirCordinator { get; set; }
        public int NumberOfooms { get; set; }
        public int BathroomNumbers { get; set; }
        public bool Credit { get; set; }
        public int Area { get; set; }
        public DateTime AdvertDate { get; set; }
        public int Floor { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public int CityId { get; set; }
        public int DistrictId { get; set; }
        public int NeighbourhoodId { get; set; }
        public int SituationId { get; set; }
        public int TypeId { get; set; }
        public string UserAdminId { get; set; }
        public bool Status { get; set; }

        [NotMapped]
        public IEnumerable<IFormFile> Image { get; set; }
    }
}
