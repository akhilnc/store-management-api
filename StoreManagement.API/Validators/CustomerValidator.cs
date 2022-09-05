
using FluentValidation;
using StoreManagement.Data.DTOs.Masters;
using StoreManagement.Data.Generics.General;
using StoreManagement.Data.Resources.Labels;
using StoreManagement.Data.Resources.Validations;
using StoreManagement.Service.Masters.Customer;
using System.Threading.Tasks;

namespace billing.API.Validators
{
    public class CustomerValidator : AbstractValidator<CustomerDTO>
    {
        private readonly ICustomerService _service;
        public CustomerValidator(ICustomerService service)
        {
            _service = service;

            RuleFor(m => m.Name)
                .NotEmpty().WithMessage(CommonValidationMessages.NAME_REQUIRED)
                .MustAsync(async (entity, value, c) => await CheckDuplication(new DuplicateValidation
                {
                    Value = entity.Name,
                    Label = "NAME",
                    ColumnName = "name",
                    Identifier = entity.UId
                }))
                .WithMessage(CommonValidationMessages.CUSTOM_VALUE_DUPLICATION.Replace("{{Label}}", CommonLabels.ResourceManager.GetString("NAME")));

            RuleFor(m => m.PhoneNumber)
              .NotEmpty().WithMessage(CommonValidationMessages.PHONE_NUMBER_REQUIRED)
              .MustAsync(async (entity, value, c) => await CheckDuplication(new DuplicateValidation
              {
                  Value = entity.PhoneNumber.ToString(),
                  Label = "PHONE_NUMBER",
                  ColumnName = "phone_number",
                  Identifier = entity.UId
              }))
              .WithMessage(CommonValidationMessages.CUSTOM_VALUE_DUPLICATION.Replace("{{Label}}", CommonLabels.ResourceManager.GetString("PHONE_NUMBER")));

        }

        public async Task<bool> CheckDuplication(DuplicateValidation input)
        {
            var result = await _service.CheckDuplication(input);
            return result.Success;
        }
    }
}
