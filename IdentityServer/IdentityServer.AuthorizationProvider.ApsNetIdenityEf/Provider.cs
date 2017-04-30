﻿using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityServer.AuthorizationProvider.ApsNetIdenityEf
{
    public class Provider : IRegistrationProvider
    {
        private UsersRepository _usersRepository;
        private ILogger _log;
        public void Initialize(IDictionary<string, string> parameters, ILogger log)
        {
            _log = log;
            _usersRepository = new UsersRepository(parameters["connectionString"]);
        }

        public async Task<Result> Authorize(string user, string password)
        {
            var result = await _usersRepository.FindUser(user, password);
            if (result == null)
                return new Result()
                {
                    Message = "Authorization error",
                    Success = false
                };

            return new Result()
            {
                Message = "Success",
                Success = true,
                Roles = result.Roles.Select(_ => new Role()
                    {
                        Id = _.RoleId,
                        Name = _.RoleId,
                    })
            };
        }

        public async Task<Result> Register(string user, string password)
        {
            var result = await _usersRepository.RegisterUser(user, password);
            if (!result.Succeeded)
                return new Result()
                {
                    Message = string.Join(";", result.Errors),
                    Success = false
                };

            return new Result()
            {
                Message = "Registration success",
                Success = true,
            };
        }

        public void Dispose()
        {
            _usersRepository?.Dispose();
        }
    }
}
