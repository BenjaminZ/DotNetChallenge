using System;
using DotNetChallenge.Web.Models;
using DotNetChallenge.Web.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

#pragma warning disable 1591

namespace DotNetChallenge.Web.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class ConversionController : ControllerBase
    {
        private readonly IConverter _converter;

        public ConversionController(IConverter converter)
        {
            _converter = converter;
        }

        /// <summary>
        ///     Convert the input.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        /// <response code="200">If success</response>
        /// <response code="400">If the input is not valid.</response>
        /// <response code="500">If there is internal server error</response>
        [HttpGet]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public ActionResult<ConversionRespond> Get([FromQuery] ConversionRequest request)
        {
            try
            {
                var output = _converter.AmountToString(request.Amount);
                return Ok(new ConversionRespond
                {
                    Name = request.Name,
                    AmountString = output
                });
            }
            catch (Exception e)
            {
                // TODO log here
                // log...
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}