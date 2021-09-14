using HotelFinder.DataAccess.Abstract;
using HotelFinder.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelFinder.DataAccess.Concrete
{
    public class HotelRepository : IHotelRepository
    {
        public async Task<Hotels> CreateHotel(Hotels hotel)
        {
            using (var hotelDbContext = new HoteldbContext())
            {
                hotelDbContext.Hotels.Add(hotel);
                await hotelDbContext.SaveChangesAsync();
                return hotel;
            }
        }

        public async Task DeleteHotel(int id)
        {
            using (var hotelDbContext = new HoteldbContext())
            {
                var deletedHotel =await GetHotelById(id);
                hotelDbContext.Hotels.Remove(deletedHotel);
                await hotelDbContext.SaveChangesAsync();
            }
        }

        public async Task<List<Hotels>> GetAllHotels()
        {
            using (var hotelDbContext = new HoteldbContext())
            {
                return await hotelDbContext.Hotels.ToListAsync();
            }
        }

        public async Task<Hotels> GetHotelById(int id)
        {
            using (var hotelDbContext = new HoteldbContext())
            {
                return await hotelDbContext.Hotels.FindAsync(id);
            }
        }

        public async Task<Hotels> GetHotelByName(string name)
        {
            using (var hotelDbContext = new HoteldbContext())
            {
                return await hotelDbContext.Hotels.FirstOrDefaultAsync(h=>h.Name.ToLower()==name.ToLower());
            }
        }

        public async Task<Hotels> UpdateHotel(Hotels hotel)
        {
            using (var hotelDbContext = new HoteldbContext())
            {
                hotelDbContext.Hotels.Update(hotel);
                await hotelDbContext.SaveChangesAsync();
                return hotel;
            }
        }
    }
}
