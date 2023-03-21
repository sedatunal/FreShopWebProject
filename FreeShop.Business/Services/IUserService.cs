using FreeShop.Business.Types;
using FreeShop.Data.Dto;
using FreeShop.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FreeShop.Business.Services
{
    public interface IUserService
    {
        ServiceMessage AddUser(UserEntity user);

        UserEntity Login(string email, string password);

        UserEntity GetUserById(int id);

        void UpdateUser(UserDto user);
    }
}
