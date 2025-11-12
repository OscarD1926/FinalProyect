using Farmalitycs.Domain.Entities;
using Farmalitycs.Domain.Interfaces;

namespace Farmalitycs.Domain.Services
{
    public class PrescriptionService
    {
        private readonly IPrescriptionRepository _repository;

        public PrescriptionService(IPrescriptionRepository repository)
        {
            _repository = repository;
        }

        public void AddPrescription(Prescription prescription)
        {
            _repository.Add(prescription);
        }
    }
}
