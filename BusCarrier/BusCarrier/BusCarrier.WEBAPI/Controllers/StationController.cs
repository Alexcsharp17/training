using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusCarrier.BLL.Interfaces;
using BusCarrier.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BusCarrier.WEBAPI.Controllers
{
    
    [ApiController]
    [Route("api/[controller]")]
    [AllowAnonymous]
    public class StationController : Controller
    {
        private IStationService stationService;
        public StationController(IStationService stationService)
        {
            this.stationService = stationService;
        }
        [HttpGet("[action]")]
        public async Task<IActionResult> GetStation([FromQuery]int id)
        {
            try
            {
                return Ok(await stationService.GetStationWithServicesAsync(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("[action]")]
        public async Task<IActionResult> GetStations()
        {
            try
            {
                return Ok(await stationService.GetStationsAsync());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> AddStation([FromBody]Station station)
        {
            try
            {
                await stationService.CreateStationAsync(station);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("[action]")]
        public async Task<IActionResult> UpdateStation([FromBody] Station station)
        {
            try
            {
                await stationService.UpdateStationAsync(station);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete("[action]")]
        public async Task<IActionResult> DeleteStation([FromQuery] int id)
        {
            try
            {
                await stationService.DeleteStationAsync(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetService([FromQuery] int id)
        {
            try
            {
                return Ok(await stationService.GetServiceAsync(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("[action]")]
        public async Task<IActionResult> GetServices()
        {
            try
            {
                return Ok(await stationService.GetServicesAsync());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> AddService([FromBody] Service service)
        {
            try
            {
                await stationService.CreateServiceAsync(service);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("[action]")]
        public async Task<IActionResult> UpdateService([FromBody] Service service)
        {
            try
            {
                await stationService.UpdateServiceAsync(service);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete("[action]")]
        public async Task<IActionResult> DeleteService([FromQuery] int id)
        {
            try
            {
                await stationService.DeleteServiceAsync(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("[action]")]
        public async Task<IActionResult> GetServiceTemplate([FromQuery] int id)
        {
            try
            {
                return Ok(await stationService.GetServiceTemplateAsync(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("[action]")]
        public async Task<IActionResult> GetServiceTemplates()
        {
            try
            {
                return Ok(await stationService.GetServicesTemplatesAsync());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> AddServiceTemplate([FromBody] ServiceTemplate serviceTemplate)
        {
            try
            {
                await stationService.CreateServiceTemplateAsync(serviceTemplate);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("[action]")]
        public async Task<IActionResult> UpdateServiceTemplate([FromBody] ServiceTemplate serviceTemplate)
        {
            try
            {
                await stationService.UpdateServiceTemplateAsync(serviceTemplate);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete("[action]")]
        public async Task<IActionResult> DeleteServiceTemplate([FromQuery] int id)
        {
            try
            {
                await stationService.DeleteServiceTemplateAsync(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}