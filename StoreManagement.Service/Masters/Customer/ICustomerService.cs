using StoreManagement.Data.Generics.General;
using StoreManagement.Data.Generics;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using StoreManagement.Data.DTOs.Masters;
using StoreManagement.Data.DTOs.DropDown;

namespace StoreManagement.Service.Masters.Customer
{
    public  interface ICustomerService
    {

        Task<IEnumerable<CustomerDTO>> GetAll();
        Task<CustomerDTO> GetById(string uId);
        Task<CustomerDTO> GetByIdCustom(int id);
        Task<Envelope<int>> Save(CustomerDTO input);
        Task<Envelope<int>> Update(CustomerDTO input);
        Task<Envelope> Delete(string uId);
        Task<Envelope> CheckDuplication(DuplicateValidation input);
        Task<IEnumerable<CustomerDropdownDTO>> GetCustomerDropdown();
        bool IsCoustomerExits(string uId);

    }
}
