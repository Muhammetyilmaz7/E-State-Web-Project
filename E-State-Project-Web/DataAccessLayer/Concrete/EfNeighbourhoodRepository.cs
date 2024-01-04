using System;
using DataAccessLayer.Abstract;
using DataAccessLayer.Data;
using EntityLayer.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrete
{
    public class EfNeighbourhoodRepository : GenericRepository<Neighbourhood, DataContext>, INeighbourhoodRepository
    {
        private DataContext context;
        public EfNeighbourhoodRepository(DataContext context) : base(context)
        {
            this.context = context;
        }

    }
}
