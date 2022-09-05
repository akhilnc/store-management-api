using StoreManagement.Data.DTOs.Masters;
using StoreManagement.Data.Generics;
using StoreManagement.Data.Generics.General;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace StoreManagement.Service.Masters.User
{
    public interface IUserService
    {
        Task<IEnumerable<UserDTO>> GetAll();
        Task<UserDTO> GetById(string uId);
        Task<Envelope> Save(UserDTO input);
        Task<Envelope> Update(UserDTO input);
        Task<Envelope> Delete(string uId);
        Task<Envelope> CheckDuplication(DuplicateValidation input);
    }
}
