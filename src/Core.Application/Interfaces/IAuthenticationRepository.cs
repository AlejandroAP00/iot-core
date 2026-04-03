using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Application.Interfaces
{
    internal interface IAuthenticationRepository
    {

        bool doesPhoneNumberExist(String phoneNumber);
        bool doesEmailExist(String email);



    }
}
