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

    [RoutePrefix("api/room")]
    public class RoomController : ApiController
    {

        // GET: api/room/id
        [ResponseType(typeof(Room))]
        [Route("{id:int}")]
        [HttpGet]
        public IHttpActionResult GetbyId(int id)
        {
            Room room = DAL.RoomDB.getRoomByIdRoom(id);
            if (room == null)
            {
                return NotFound();
            }

            return Ok(room);

        }

      

        // GET: api/room/city
        [ResponseType(typeof(Room))]
        [Route("{city}/{cin:DateTime}/{cout:DateTime}")]
        [HttpGet]
        public IHttpActionResult GetSearch(String city, DateTime cin, DateTime cout)
        {
            List<Room> rooms = DAL.RoomDB.getRoomsByBasicSearch(city, cin , cout);
            if (rooms == null)
            {
                return NotFound();
            }

            return Ok(rooms);

        }

    }
}
