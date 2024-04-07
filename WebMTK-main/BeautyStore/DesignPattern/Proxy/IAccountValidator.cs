using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeautyStore.Interfaces
{
    public interface IAccountValidator
    {
        object ValidateAccountLogin(string email, string password);
        object ValidateAccountSignup(string email);
    }
}
