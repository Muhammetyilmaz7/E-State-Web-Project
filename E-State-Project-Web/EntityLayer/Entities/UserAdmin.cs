using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace EntityLayer.Entities
{
    public class UserAdmin : IdentityUser
    {
        public string FullName { get; set; }
        public bool Status { get; set; }
        public virtual List<Advert> Adverts { get; set; }

    }
}
