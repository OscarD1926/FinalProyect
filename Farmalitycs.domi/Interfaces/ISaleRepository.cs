using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Farmalitycs.Domain.Entities;
using System.Collections.Generic;

namespace Farmalitycs.Domain.Interfaces
{
    public interface ISaleRepository
    {
        void Add(Sale sale);
        Sale GetById(int id);
        List<Sale> GetAll();
    }
}

