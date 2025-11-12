using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Farmalitycs.Domain.Entities;
using Farmalitycs.Domain.Interfaces;

namespace Farmalitycs.Domain.Services
{
    public class PatientService
    {
        private readonly IPatientRepository _repository;

        public PatientService(IPatientRepository repository)
        {
            _repository = repository;
        }

        public void Register(Patient patient)
        {
            _repository.Add(patient);
        }
    }
}

