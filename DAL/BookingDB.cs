using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class BookingDB
    {

        public static void book(DateTime checkin, DateTime checkout, String firstname, String lastname, decimal price, DateTime date, Room room)
        {
            using (var context = new ValaisBookingEntities())
            {
                
                Booking book = new Booking();
                book.CheckIn = checkin;
                book.CheckOut = checkout;
                book.Firstname = firstname;
                book.Lastname = lastname;
                book.Price = price;
                book.Date = date;
                book.IdRoom = room.IdRoom;
                context.Booking.Add(book);
                context.SaveChanges();
            }
        }


        //get booking by id name
        public static List<Booking> getBooking(String firsname, String lastname)
        {
            using (var context = new ValaisBookingEntities())
            {
                return context.Booking.Include("Room").Where(b => b.Firstname == firsname && b.Lastname == lastname).ToList();
            }
        }

        public static void cancelBook(int idBook)
        {
            using (var context = new ValaisBookingEntities())
            {
                Booking book = (Booking)context.Booking.Where(b => b.IdBooking == idBook).Single();
                context.Booking.Remove(book);
                context.SaveChanges();
            }
        }

    }
}
