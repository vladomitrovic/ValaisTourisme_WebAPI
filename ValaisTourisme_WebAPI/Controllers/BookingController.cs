using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ValaisTourisme_WebAPI.Controllers
{
    public class BookingController : ApiController
    {

        public IHttpActionResult PostNewBooking([FromBody]Booking b)
        {
            DAL.BookingDB.book(b.CheckIn, b.CheckOut, b.Firstname, b.Lastname, b.Price, b.Date, b.Room);
            return Ok(b);
        }

    }
}
