using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Farmalitycs.Domain.Entities;
using System.Collections.Generic;

namespace Farmalitycs.Domain.Interfaces
{
    public interface IMedicineRepository
    {
        void Add(Medicine medicine);
        void Update(Medicine medicine);
        Medicine GetById(int id);
        List<Medicine> GetAll();
    }
}
