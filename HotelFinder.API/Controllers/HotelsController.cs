using HotelFinder.Business.Abstract;
using HotelFinder.Business.Concrete;
using HotelFinder.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace HotelFinder.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HotelsController : ControllerBase
    {
        private IHotelService _hotelService;
        public HotelsController(IHotelService hotelService)
        {
            _hotelService = hotelService;
        }
      
        /// <summary>
        /// Get All Hotels
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var hotels = await _hotelService.GetAllHotels();
                return Ok(hotels);
            }
            catch (Exception)
            {

                throw;
            }
        }
        /// <summary>
        /// Get Hotel by using id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("[action]/{id}")]
        public async Task<IActionResult> GetHotelById(int id)
        {
            var hotel = await _hotelService.GetHotelById(id);
         
            if (hotel!=null)
            {
                
                return Ok(hotel);
            }
            return NotFound();
        }
        [HttpGet]
        [Route("[action]/{name}")]
        public async Task<IActionResult> GetHotelByName(string name)
        {
            var hotel = await _hotelService.GetHotelByName(name);
            if (hotel!=null)
            {
                return Ok(hotel);
            }
            return NotFound();
        }
        /// <summary>
        /// Create Hotel 
        /// </summary>
        /// <param name="hotel"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> CreateHotel([FromBody] Hotels hotel)
        { 
            var createdHotel = await _hotelService.CreateHotel(hotel);
            return CreatedAtAction("GetHotelById", new { id = createdHotel.Id }, createdHotel);
        }
        /// <summary>
        /// Update Hotel
        /// </summary>
        /// <param name="hotel"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("[action]")]
        public async Task<IActionResult> UpdateHotel([FromBody] Hotels hotel)
        {
            if (await _hotelService.GetHotelById(hotel.Id)!=null)
            {
                var updatedHotel = await _hotelService.UpdateHotel(hotel);
                return Ok(hotel);
            }
            return NotFound();
        }
        /// <summary>
        /// Delete Hotel
        /// </summary>
        /// <param name="id"></param>
        [HttpDelete]
        [Route("[action]/{id}")]
        public async Task<IActionResult> DeleteHotel(int id)
        {
            if (await _hotelService.GetHotelById(id) != null)
            {
                await _hotelService.DeleteHotel(id);
                return Ok();
            }
            return NotFound();
            
        }
    }
}
