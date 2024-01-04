using System;
using EntityLayer.Entities;
using FluentValidation;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class NeighbourhoodValidation : AbstractValidator<Neighbourhood>
    {
        public NeighbourhoodValidation()
        {
            RuleFor(x => x.NeighbourhoodName).NotEmpty().WithMessage("Boş bırakılamaz");
            RuleFor(x => x.DistrictId).NotEmpty().WithMessage("Semt alanı bırakılamaz");

        }
    }
}
