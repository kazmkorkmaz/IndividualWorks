using HotelFinder.Business.Abstract;
using HotelFinder.DataAccess.Abstract;
using HotelFinder.DataAccess.Concrete;
using HotelFinder.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelFinder.Business.Concrete
{
    public class HotelManager : IHotelService
    {
        private IHotelRepository _repository;
        public HotelManager(IHotelRepository repository)
        {
            _repository = repository;
        }
        public async Task<Hotels> CreateHotel(Hotels hotel)
        {
            return await _repository.CreateHotel(hotel);
        }

        public async Task DeleteHotel(int id)
        {
            await _repository.DeleteHotel(id);
        }

        public async Task<List<Hotels>> GetAllHotels()
        {
           return await _repository.GetAllHotels();
        }

        public async Task<Hotels> GetHotelById(int id)
        {
            return await _repository.GetHotelById(id);
        }

        public async Task<Hotels> GetHotelByName(string name)
        {
            return await _repository.GetHotelByName(name);
        }

        public async Task<Hotels> UpdateHotel(Hotels hotel)
        {
            return await _repository.UpdateHotel(hotel);
        }
    }
}
