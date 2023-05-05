using hahn.Domain.Entities;
using hahn.Domain.Enums;
using hahn.Infrastructure.Helpers;
using hahn.Infrastructure.Repositories;
using Microsoft.AspNetCore.Identity;

namespace hahn.Service.Services
{
    public class ManagerService : IManagerService
    {
        private readonly IManagerRepository _repository;


        public ManagerService(IManagerRepository managerRepository)
        {
            _repository = managerRepository;

        }
        public async Task<ResponseModel<IdentityResult>> AddAsync()
        {
            try
            {

                var manager = new Manager
                {
                    Name = "Hahn",
                    Email = "test@hahn.io",
                    UserName = "test@hahn.io",
                    UserType = eUserType.Manager,
                    Password = "123456",
                    Created = DateTime.Now,
                };


                var emailInUse = await _repository.VerifyIfEmailIsUnique(manager.Email);
                if (emailInUse)
                    return ResponseBuilder.ConflictResponse().WithMessage("Email already exist.");



                var result = await _repository.AddManagerAsync(manager, manager.Password);

                return ResponseBuilder.OkResponse(result);
            }
            catch (Exception e)
            {
                return ResponseBuilder.ErrorResponse().WithMessage(e.Message);
            }
        }

    }
}
