using BeautyStore.Interfaces;
using BeautyStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BeautyStore.DesignPattern;


namespace BeautyStore.DesignPattern
{
    public class AccountValidatorProxy : IAccountValidator
    {
        private BeautyStoreEntities1 _db;

        public AccountValidatorProxy(BeautyStoreEntities1 db)
        {
            _db = db;
        }
       public object ValidateAccountLogin(string email, string password)
       {
            var adminAccount = _db.AdminAccounts.FirstOrDefault(k => k.Email == email && k.Password == password);
            if (adminAccount != null)
            {
                return adminAccount;
            }
            var customerAccount = _db.Customers.FirstOrDefault(k => k.UserEmail == email && k.UserPassword == password);
            return customerAccount;
       }

        public object ValidateAccountSignup(string email)
        {
            var adminAccount = _db.AdminAccounts.FirstOrDefault(k => k.Email == email);
            if (adminAccount != null)
            {
                return adminAccount;
            }
            var customerAccount = _db.Customers.FirstOrDefault(k => k.UserEmail == email);
            return customerAccount;
        }

    }
}