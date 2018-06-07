using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class RoomDB { 

        //room by id room
    public static Room getRoomByIdRoom(int id)
    {
        using (var context = new ValaisBookingEntities())
        {
            return context.Room.Include("Picture").Where(r => r.IdRoom == id).Single();

        }
    }

    //get rooms by id hotel
    public static List<Room> getRoomByIDHotel(int id)
    {
        using (var context = new ValaisBookingEntities())
        {
            return context.Room.Include("Picture").Include("Hotel").Where(r => r.Hotel.IdHotel == id).ToList();

        }
    }



    public static List<Room> getRoomsByBasicSearch(string city, DateTime dateCheckIn, DateTime dateCheckOut)
    {
        using (var context = new ValaisBookingEntities())
        {

            List<Room> listRoomInCity = context.Room.Include("Picture").Include("Hotel").Where(ro => ro.Hotel.Location == city).ToList();

            List<Booking> listReservationInDate = context.Booking.Where(res => dateCheckIn >= res.CheckIn && dateCheckIn <= res.CheckOut || dateCheckOut >= res.CheckIn && dateCheckOut <= res.CheckOut || dateCheckIn <= res.CheckIn && dateCheckOut >= res.CheckOut).ToList();

            List<Room> finalListRoom = (from room in listRoomInCity
                                         where !(from res in listReservationInDate
                                                  select res.IdRoom).Contains(room.IdRoom)
                                         select room).ToList();
                return finalListRoom;
        }
    }


    public static List<Room> getRoomsByAvancedSearch(string city, DateTime dateCheckIn, DateTime dateCheckOut, Boolean HasParking, Boolean HasWifi, int catMax, int catMin, Boolean HasTV, Boolean HasHairdryer, decimal maxPrice, decimal minPrice)
    {
        using (var context = new ValaisBookingEntities())
        {

            List<Room> avalaibleRooms = getRoomsByBasicSearch(city, dateCheckIn, dateCheckOut);


            List<Room> onlyPreference = (List<Room>)from r in avalaibleRooms
                                                    where r.HasTV = HasTV
                                                    where r.HasHairDryer = HasHairdryer
                                                    where r.Price >= minPrice
                                                    where r.Price <= maxPrice
                                                    where r.Hotel.Category >= catMin
                                                    where r.Hotel.Category <= catMax
                                                    where r.Hotel.HasParking = HasParking
                                                    where r.Hotel.HasWifi = HasWifi
                                                    select r;



            return onlyPreference;
        }
    }



    //PICTURE .................................................................................................

    //get pictures by id room
    public static List<Picture> getPicturesByIdRoom(int idRoom)
    {
        using (var context = new ValaisBookingEntities())
        {
            return context.Picture.Where(p => p.Room.IdRoom == idRoom).ToList();
        }

    }




    }
}
