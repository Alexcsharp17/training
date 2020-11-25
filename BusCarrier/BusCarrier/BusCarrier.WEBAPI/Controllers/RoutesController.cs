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
    [Route("api/[controller]")]
    [ApiController]
    [AllowAnonymous]
    public class RoutesController : Controller
    {
        private readonly IRouteService routeService;
        public RoutesController(IRouteService routeService)
        {
            this.routeService = routeService;
        }
        [HttpGet]
        public async Task<IActionResult> GetRoute([FromQuery] int id)
        {
            try
            {
                return Ok(await routeService.GetRouteAsync(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet]
        public async Task<IActionResult> GetRoutes()
        {
            try
            {
                return Ok(await routeService.GetRoutesAsync());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddRoute([FromBody] Route route)
        {
            try
            {
                await routeService.CreateRouteAsync(route);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public async Task<IActionResult> UpdateRoute([FromBody] Route route)
        {
            try
            {
                await routeService.UpdateRouteAsync(route);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteRoute([FromQuery] int id)
        {
            try
            {
                await routeService.DeleteRouteAsync(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet]
        public async Task<IActionResult> GetRouteTemplate([FromQuery] int id)
        {
            try
            {
                return Ok(await routeService.GetRouteTemplateAsync(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet]
        public async Task<IActionResult> GetRouteTemplates()
        {
            try
            {
                return Ok(await routeService.GetRouteTemplatesAsync());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddRouteTemplate([FromBody] RouteTemplate routeTemplate)
        {
            try
            {
                await routeService.CreateRouteTemplateAsync(routeTemplate);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public async Task<IActionResult> UpdateRouteTemplate([FromBody] RouteTemplate routeTemplate)
        {
            try
            {
                await routeService.UpdateRouteTemplateAsync(routeTemplate);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteRouteTemplate([FromQuery] int id)
        {
            try
            {
                await routeService.DeleteRouteTemplateAsync(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
