using HotelFinder.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelFinder.Business.Abstract
{
   public interface IHotelService
    {
        Task<List<Hotels>> GetAllHotels();
        Task<Hotels> GetHotelById(int id);
        Task<Hotels> GetHotelByName(string name);
        Task<Hotels> CreateHotel(Hotels hotel);
        Task<Hotels> UpdateHotel(Hotels hotel);
        Task DeleteHotel(int id);
    }
}
