﻿using InformationKiosk.BE;
using InformationKiosk.DAL.Repositories;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace InformationKiosk.BL
{
    public class AdministratorService
    {
        private Validator validator;
        private AdministratorRepository administratorRepository;
        public AdministratorService()
        {
            validator = new Validator();
            administratorRepository = new AdministratorRepository();
        }

        public async Task<Administrator> AddAdministratorcAsync(Administrator admin, string firstName, string lastName, string email, string password)
        {
            if(GetAdministratorAsync(email, password) != null)
            {
                throw new ArgumentException("administator already exist");
            }
            if (!validator.ValidateEmail(email) || !validator.ValidatePasswordLength(password))
            {
                throw new ArgumentException();
            }
            var newAdmin = new Administrator()
            {
                Id = Guid.NewGuid(),
                FirstName = firstName,
                LastName = lastName,
                Email = email,
                Password = password
            };

            await administratorRepository.AddAdministratorAsync(admin, newAdmin);

            return newAdmin;
        }

        public async Task<Administrator> AddNewAdministratorcAsync(string firstName, string lastName, string email, string password)
        {
            if (!validator.ValidateEmail(email) || !validator.ValidatePasswordLength(password))
            {
                throw new ArgumentException();
            }
            var newAdmin = new Administrator()
            {
                Id = Guid.NewGuid(),
                FirstName = firstName,
                LastName = lastName,
                Email = email,
                Password = password
            };

            await administratorRepository.AddNewAdministratorAsync(newAdmin);

            return newAdmin;
        }

        public async Task<Administrator> GetAdministratorAsync(string userName, string password)
        {
            return await administratorRepository.GetAdministratorAsync(userName, password);
        }
    }
}
