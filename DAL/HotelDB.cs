using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class HotelDB
    {
        //get all hotel
        public static List<Hotel> getAllHotel()
        {
            using (var context = new ValaisBookingEntities())
            {
                return context.Hotel.Include("Room").ToList<Hotel>();
            }
        }


        //get hotel by id
        public static Hotel GetHotelById(int idHotel)
        {
            using (var context = new ValaisBookingEntities())
            {
                return context.Hotel.Where(h => h.IdHotel == idHotel).Single();

            }
        }

        //get hotel by location 
        public static List<Hotel> getHotelByLocation(string city)
        {
            using (var context = new ValaisBookingEntities())
            {
                return context.Hotel.Where(h => h.Location == city).ToList();
            }
        }


    }
}
