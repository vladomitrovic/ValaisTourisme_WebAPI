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
                book.Room = room;
                context.Booking.Add(book);
                context.SaveChanges();
            }
        }

    }
}
