using System;
using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;

namespace BusinessLayer.Concrete
{
    public class NeighbourhoodManager : NeighbourhoodService
    {
        INeighbourhoodRepository _neigh;

        public NeighbourhoodManager(INeighbourhoodRepository neigh)
        {
            _neigh = neigh;
        }
        public void Add(Neighbourhood p)
        {
            p.Status = true;
            _neigh.Add(p);
        }

        public void Delete(Neighbourhood p)
        {
            var neigh = _neigh.GetById(p.NeighbourhoodId);
            neigh.Status = false;
            _neigh.Update(neigh);
        }

        public Neighbourhood GetById(int id)
        {
            return _neigh.GetById(id);
        }

        public List<Neighbourhood> List()
        {
            return _neigh.List();
        }

        public List<Neighbourhood> List(Expression<Func<Neighbourhood, bool>> filter)
        {
            return _neigh.List(filter);
        }

        public void Update(Neighbourhood p)
        {
            var neigh = _neigh.GetById(p.NeighbourhoodId);
            neigh.NeighbourhoodName = p.NeighbourhoodName;
            neigh.DistrictId = p.DistrictId;
            _neigh.Update(neigh);
        }
    }
}
