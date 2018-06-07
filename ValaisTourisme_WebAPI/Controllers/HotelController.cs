using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using DAL;

namespace ValaisTourisme_WebAPI.Controllers
{
    [RoutePrefix("api/hotel")]
    public class HotelController : ApiController
    {


        // GET: api/Hotel
        [ResponseType(typeof(Hotel))]
        [Route("all")]
            [HttpGet]
            public IHttpActionResult GetAll() 
            {
                List<Hotel> hotels = DAL.HotelDB.getAllHotel();
            if (hotels == null)
            {
                return NotFound();
            }

            return Ok(hotels);

            }


        // GET: api/Hotel
        [ResponseType(typeof(Hotel))]
        [Route("{id:int}")]
        [HttpGet]
        public IHttpActionResult GetbyId(int id)
        {
            Hotel hotel = DAL.HotelDB.GetHotelById(id);
            if (hotel == null)
            {
                return NotFound();
            }

            return Ok(hotel);

        }


    }
    }
