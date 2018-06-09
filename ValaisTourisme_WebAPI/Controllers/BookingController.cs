using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;

namespace ValaisTourisme_WebAPI.Controllers
{
    [RoutePrefix("api/booking")]
    public class BookingController : ApiController
    {

        public IHttpActionResult PostNewBooking([FromBody]Booking b)
        {
            DAL.BookingDB.book(b.CheckIn, b.CheckOut, b.Firstname, b.Lastname, b.Price, b.Date, b.Room);
            return Ok(b);
        }

        // GET: api/booking
        [ResponseType(typeof(Booking))]
        [Route("{firstname}/{lastname}")]
        [HttpGet]
        public IHttpActionResult GetBooking(String firstname, String lastname)
        {
            List<Booking> bookings = DAL.BookingDB.getBooking(firstname, lastname);
            if (bookings == null)
            {
                return NotFound();
            }

            return Ok(bookings);

        }

    }
}
