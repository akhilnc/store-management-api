using FluentValidation;
using StoreManagement.Data.DTOs.Masters;
using StoreManagement.Data.Generics.General;
using StoreManagement.Data.Resources.Labels;
using StoreManagement.Data.Resources.Validations;
using StoreManagement.Service.Masters.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StoreManagement.API.Validators
{
    public class UserValidator : AbstractValidator<UserDTO>
    {
        private readonly IUserService _service;
        public UserValidator(IUserService service)
        {
            _service = service;

            RuleFor(m => m.UserName)
                .NotEmpty().WithMessage(CommonValidationMessages.USER_NAME_REQUIRED)
                .MustAsync(async (entity, value, c) => await CheckDuplication(new DuplicateValidation
                {
                    Value = entity.UserName,
                    Label = "USER_NAME",
                    ColumnName = "user_name",
                    Identifier = entity.UId
                }))
                .WithMessage(CommonValidationMessages.CUSTOM_VALUE_DUPLICATION.Replace("{{Label}}", CommonLabels.ResourceManager.GetString("USER_NAME")));

            RuleFor(m => m.FullName)
                .NotEmpty().WithMessage(CommonValidationMessages.FULL_NAME_REQUIRED)
                .MustAsync(async (entity, value, c) => await CheckDuplication(new DuplicateValidation
                {
                    Value = entity.FullName,
                    Label = "FULL_NAME",
                    ColumnName = "full_name",
                    Identifier = entity.UId
                }))
                .WithMessage(CommonValidationMessages.CUSTOM_VALUE_DUPLICATION.Replace("{{Label}}", CommonLabels.ResourceManager.GetString("FULL_NAME"))); ;
        }

        public async Task<bool> CheckDuplication(DuplicateValidation input)
        {
            var result = await _service.CheckDuplication(input);
            return result.Success;
        }
    }
}
