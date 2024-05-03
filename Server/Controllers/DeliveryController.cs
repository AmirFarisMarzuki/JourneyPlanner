using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using JourneyPlanner.Shared.Models;
using System;
using static System.Net.WebRequestMethods;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;

namespace PlanYourJourney.API
{
    [ApiController]
    [Route("api/DeliveryController")]
    public class DeliveryController : Controller
    {
        private readonly PlanYourJourneyContext _context;

        public DeliveryController(PlanYourJourneyContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        [Route("GetDelivery")]
        public IEnumerable<Delivery> Get()
        {
            return _context.Deliveries.ToList();
        }

        [HttpPost]
        [Route("CreateDelivery")]
        public async Task<IActionResult> CreateDelivery(Delivery model)
        {
           
            //Have 3 step
            //1. Get Location Latitude and Longitude

            if (ModelState.IsValid)
            {   _context.Deliveries.Add(model);
                await _context.SaveChangesAsync();
                return Ok();
            }

            return BadRequest(ModelState);
        }

        [HttpPut]
        [Route("UpdateDelivery")]
        public async Task<IActionResult> UpdateDelivery(Delivery model)
        {
            if (ModelState.IsValid)
            {
                var ExistingModel = await _context.Deliveries.FirstOrDefaultAsync(m => m.Id == model.Id);
                if (ExistingModel != null)
                {
                    ExistingModel.DeliveryDate = model.DeliveryDate;
                    ExistingModel.DeliveryTime = model.DeliveryTime;
                    ExistingModel.IsCompleted = model.IsCompleted;
                    ExistingModel.IsCancelled = model.IsCancelled;

                    await _context.SaveChangesAsync();
                }
                else
                {
                    return NotFound();
                }
            }
            else
            {
                return BadRequest(ModelState);
            }
            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteDelivery(int Id)
        {
            var model = await _context.Deliveries.FirstOrDefaultAsync(m => m.Id == Id);

            if (model != null)
            {
                _context.Deliveries.Remove(model);
                await _context.SaveChangesAsync();
                return Ok();
            }
            else
            {
                return NotFound();
            }
        }


    }
}
