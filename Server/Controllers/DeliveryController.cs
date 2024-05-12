using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using JourneyPlanner.Shared.Models;
using System;
using static System.Net.WebRequestMethods;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using JourneyPlanner.Server.Interfaces;
using System.Net.Http.Json;
using System.Net.Http;
using System.Collections.Generic;

namespace PlanYourJourney.API
{
    [ApiController]
    [Route("api/[Controller]")]
    public class DeliveryController : Controller
    {
        private readonly IDelivery _IDelivery;

        public DeliveryController(IDelivery iDelivery)
        {
            _IDelivery = iDelivery;
        }

        //Get all user
        [HttpGet]
        public async Task<List<Delivery>> Get()
        {
            return await Task.FromResult(_IDelivery.GetDeliveryDetails());
        }

        [HttpGet("{Id}")]
        public IActionResult Get(int Id)
        {
            Delivery delivery = _IDelivery.GetDeliveryData(Id);
            if (delivery != null)
            {
                return Ok(delivery);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPost]
        public async Task Post(Delivery delivery)
        {  
            _IDelivery.AddDelivery(delivery);
        }

        [HttpPut]
        public void Put(Delivery delivery)
        {
            _IDelivery.UpdateDelivery(delivery);
        }

        [HttpDelete("{Id}")]
        public IActionResult Delete(int Id)
        {
            _IDelivery.DeleteDeliveryData(Id);
            return Ok();
        }
    }
}
