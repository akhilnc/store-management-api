using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using StoreManagement.Data.Generics.General;
using StoreManagement.Data.Generics;
using System.Threading.Tasks;
using billing.Data;
using StoreManagement.Service.Masters.Customer;
using StoreManagement.Data.DTOs.Masters;
using billing.API.Validators;
using StoreManagement.Data.DTOs.DropDown;

namespace StoreManagement.API.Controllers.Masters
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _service;
        private readonly ILogger<CustomerController> _logger;

        #region Constructor

        public CustomerController(ICustomerService service, ILogger<CustomerController> logger)
        {
            _service = service;
            _logger = logger;
        }

        #endregion


        #region Public Methods
        /// <summary>
        /// Gets all.
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetAll")]
        [ProducesResponseType(typeof(CustomerDTO), 200)]
        public async Task<IActionResult> GetAll()
        {
            _logger.LogTrace(ApplicationConstants.EnterLogAction, nameof(GetAll), nameof(CustomerController));
            return Ok(await _service.GetAll());
        }

        /// <summary>
        /// Gets the by identifier.
        /// </summary>
        /// <param name="uId">The u identifier.</param>
        /// <returns></returns>
        [HttpGet("GetById")]
        [ProducesResponseType(typeof(CustomerDTO), 200)]
        public async Task<IActionResult> GetById(string uId)
        {
            _logger.LogTrace(ApplicationConstants.EnterLogAction, nameof(GetById), nameof(CustomerController));
            return Ok(await _service.GetById(uId));
        }

        /// <summary>
        /// Saves the specified input.
        /// </summary>
        /// <param name="input">The input.</param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(typeof(Envelope), 200)]
        public async Task<IActionResult> Save([FromBody] CustomerDTO input)
        {
            var validator = new CustomerValidator(_service);
            var validationResult = await validator.ValidateAsync(input);

            if (!validationResult.IsValid)
                return Ok(new Envelope(false, validationResult.Errors.FirstOrDefault().ErrorMessage));
            _logger.LogTrace(ApplicationConstants.EnterLogAction, nameof(Save), nameof(CustomerController));
            return Ok(await _service.Save(input));
        }

        /// <summary>
        /// Updates the specified input.
        /// </summary>
        /// <param name="input">The input.</param>
        /// <returns></returns>
        [HttpPut]
        [ProducesResponseType(typeof(Envelope), 200)]
        public async Task<IActionResult> Update([FromBody] CustomerDTO input)
        {
            _logger.LogTrace(ApplicationConstants.EnterLogAction, nameof(Update), nameof(CustomerController));
            return Ok(await _service.Update(input));
        }

        /// <summary>
        /// Deletes the specified u identifier.
        /// </summary>
        /// <param name="uId">The u identifier.</param>
        /// <returns></returns>
        [HttpDelete]
        [ProducesResponseType(typeof(Envelope), 200)]
        public async Task<IActionResult> Delete(string uId)
        {
            _logger.LogTrace(ApplicationConstants.EnterLogAction, nameof(Delete), nameof(CustomerController));
            if (_service.IsCoustomerExits(uId))
            {
                return Ok(new Envelope(false, ApplicationConstants.CostomerIsalreadyInuse));
            }
            return Ok(await _service.Delete(uId));
        }
        /// <summary>
        /// Gets customer dropdown.
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetCustomerDropdown")]
        [ProducesResponseType(typeof(CustomerDropdownDTO), 200)]
        public async Task<IActionResult> GetCustomerDropdown()
        {
            _logger.LogTrace(ApplicationConstants.EnterLogAction, nameof(GetCustomerDropdown), nameof(CustomerController));
            return Ok(await _service.GetCustomerDropdown());
        }

        #region Validation

        /// <summary>
        /// Checks the duplication.
        /// </summary>
        /// <param name="input">The input.</param>
        /// <returns></returns>
        [HttpGet("CheckDuplication")]
        public async Task<IActionResult> CheckDuplication([FromQuery] DuplicateValidation input)
        {
            _logger.LogTrace(ApplicationConstants.EnterLogAction, nameof(CheckDuplication), nameof(CustomerController));
            return Ok(await _service.CheckDuplication(input));
        }

        #endregion

        #endregion
    }
}
