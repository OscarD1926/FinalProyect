using Farmalitycs.Domain.Entities;
using Farmalitycs.Domain.Interfaces;

namespace Farmalitycs.Domain.Services
{
    public class SaleService
    {
        private readonly ISaleRepository _repository;

        public SaleService(ISaleRepository repository)
        {
            _repository = repository;
        }

        public void RegisterSale(Sale sale)
        {
            _repository.Add(sale);
        }
    }
}
