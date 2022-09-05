using FluentValidation;
using StoreManagement.API.Validators;
using StoreManagement.Data.DTOs.Masters;
using StoreManagement.Data.Generics;
using StoreManagement.Data.Generics.General;
using StoreManagement.Service.Masters.User;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StoreManagement.API.Controllers.Masters
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _service;

        /// <summary>
        /// Initializes a new instance of the <see cref="UserController"/> class.
        /// </summary>
        /// <param name="service">The service.</param>
        public UserController(IUserService service)
        {
            _service = service;
        }

        /// <summary>
        /// Gets all.
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _service.GetAll());
        }

        /// <summary>
        /// Gets the by identifier.
        /// </summary>
        /// <param name="uId">The u identifier.</param>
        /// <returns></returns>
        [HttpGet("GetById")]
        public async Task<IActionResult> GetById(string uId)
        {
            return Ok(await _service.GetById(uId));
        }

        /// <summary>
        /// Saves the specified input.
        /// </summary>
        /// <param name="input">The input.</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Save([FromBody] UserDTO input)
        {
            var validator = new UserValidator(_service);
            var validationResult = await validator.ValidateAsync(input);

            if (!validationResult.IsValid)
                return Ok(new Envelope(false, validationResult.Errors.FirstOrDefault().ErrorMessage));

            return Ok(await _service.Save(input));
        }

        /// <summary>
        /// Updates the specified input.
        /// </summary>
        /// <param name="input">The input.</param>
        /// <returns></returns>
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UserDTO input)
        {
            return Ok(await _service.Update(input));
        }

        /// <summary>
        /// Deletes the specified u identifier.
        /// </summary>
        /// <param name="uId">The u identifier.</param>
        /// <returns></returns>
        [HttpDelete]
        public async Task<IActionResult> Delete(string uId)
        {
            return Ok(await _service.Delete(uId));
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
            return Ok(await _service.CheckDuplication(input));
        }

        #endregion
    }
}
