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
            return context.Room.Include("Picture").Include("Hotel").Where(r => r.IdRoom == id).Single();

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

                finalListRoom = settingPrice(dateCheckIn, dateCheckOut, finalListRoom);   

            return finalListRoom;
        }
    }


    private static List<Room> settingPrice (DateTime cin, DateTime cout, List<Room> rooms)
    {
            
                foreach(Room  r in rooms)
                {
                    if(hotel70Busy(r.IdHotel, cin, cout))
                        r.Price = (decimal)((int)r.Price * 1.2) ;
                }



            return rooms;
    }

    private static bool hotel70Busy(int idHotel, DateTime cin, DateTime cout)
    {
            using (var context = new ValaisBookingEntities())
            {
                float nbRooms = context.Room.Where(r => r.IdHotel == idHotel).ToList().Count();
                List<Room> listReservationInDate = context.Booking.Where(res => cin >= res.CheckIn && cin <= res.CheckOut || cout >= res.CheckIn && cout <= res.CheckOut || cin <= res.CheckIn && cout >= res.CheckOut).Select(r => r.Room).ToList();

                float busyRooms = listReservationInDate.Where(r => r.IdHotel == idHotel).ToList().Count();

                if ((busyRooms / nbRooms) >= 0.7)
                {
                    return true;
                }
                return false;
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
