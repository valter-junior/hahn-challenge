using hahn.Domain.Entities;
using hahn.Domain.Entities.BuyerAggregate;
using hahn.Domain.Enums;
using hahn.Infrastructure.Helpers;
using hahn.Infrastructure.Repositories;
using Microsoft.AspNetCore.Identity;
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

        public async Task<ResponseModel<IEnumerable<Buyer>>> GetAllAsync()
        {
            try
            {

                var getBuyers = await _repository.GetAllAsync();

                return ResponseBuilder.OkResponse(getBuyers);
            }
            catch (Exception e)
            {
                return ResponseBuilder.ErrorResponse().WithMessage(e.Message);
            }

        }

        public async Task<ResponseModel<IdentityResult>> AddAsync(AddBuyer model)
        {
            try
            {


                var emailInUse = await _repository.VerifyIfEmailIsUnique(model.Email);
                if (emailInUse)
                    return ResponseBuilder.ConflictResponse().WithMessage("Email already exist.");

                var result = await _repository.AddBuyerAsync(model, model.Password);

                return ResponseBuilder.OkResponse(result);
            }
            catch (Exception e)
            {
                return ResponseBuilder.ErrorResponse().WithMessage(e.Message);
            }
        }

        public async Task<ResponseModel<Buyer>> UpdateAsync(UpdateBuyer model)
        {
            try
            {
                var search = _repository.GetByIdAsync(model.Id);

                if (search.Result == null) return ResponseBuilder.ConflictResponse().WithMessage("Use not exists");

                search.Result.Name = model.Name;
                search.Result.PhoneNumber = model.Phone;


                var result = await _repository.UpdateAsync(search.Result);

                return ResponseBuilder.OkResponse(result);
            }
            catch (Exception e)
            {
                return ResponseBuilder.ErrorResponse().WithMessage(e.Message);
            }
        }

        public async Task<ResponseModel<string>> DeleteAsync(string id)
        {
            try
            {
                var buyer = await _repository.GetByIdAsync(id);

                if (buyer != null)
                {

                    await _repository.DeleteAsync(buyer);

                    return ResponseBuilder.OkResponse("Success");

                }
                else
                {
                    return ResponseBuilder.NotFoundResponse("Buyer does not exist.");
                }

            }
            catch (Exception ex)
            {
                return ResponseBuilder.ErrorResponse().WithMessage(ex.Message);
            }
        }
    }
}
