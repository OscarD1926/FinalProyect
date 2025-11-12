using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Farmalitycs.Domain.Entities;
using Farmalitycs.Domain.Interfaces;
using System;

namespace Farmalitycs.Domain.Services
{
    public class MedicineService
    {
        private readonly IMedicineRepository _repository;

        public MedicineService(IMedicineRepository repository)
        {
            _repository = repository;
        }

        public bool IsExpired(Medicine medicine)
        {
            return medicine.ExpirationDate < DateTime.Now;
        }
    }
}

