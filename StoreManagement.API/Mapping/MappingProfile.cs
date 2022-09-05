using AutoMapper;
using StoreManagement.Data.DTOs.Masters;
using StoreManagement.Data.Models;

namespace StoreManagement.API.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Entity to DTO
            CreateMap<MstUser, UserDTO>();
            CreateMap<MstUserRole, UserRoleDTO>();

            // DTO to Entity
            CreateMap<UserDTO, MstUser>();
            CreateMap<UserRoleDTO, MstUserRole>();
        }
    }
}