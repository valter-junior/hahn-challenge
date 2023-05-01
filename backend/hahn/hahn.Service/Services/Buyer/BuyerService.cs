using hahn.Domain.Entities.BuyerAggregate;
using hahn.Infrastructure.Helpers;
using hahn.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static hahn.Service.Models.BuyerModels;

namespace hahn.Service.Services

{
    public class BuyerService : IBuyerService
    {
        private readonly IBuyerRepository _repository;


        public BuyerService(IBuyerRepository buyerRepository)
        {
            _repository = buyerRepository;

        }

        public async Task<ResponseModel<Buyer>> AddAsync(AddBuyer model)
        {
            try
            {
                var result = await _repository.AddAsync(model);

                return ResponseBuilder.OkResponse(result);
            }
            catch (Exception e)
            {
                return ResponseBuilder.ErrorResponse().WithMessage(e.Message);
            }
        }
    }
}
