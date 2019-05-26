using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Serialization;
using FormTask.web.Models.DataAccessPostgreSqlProvider;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FormTask.web.Controllers
{
    public class UploadController : Controller
    {
        public static string ToStringServices(List<string> services)
        {

            string stroka = "";
            foreach (var e in services)
            {
                stroka = stroka + e;
                stroka += ", ";
            }

            return stroka;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult DoUpload(IFormFile file)
        {
            using (var stream = file.OpenReadStream())
            {
                var xs = new XmlSerializer(typeof(Listrooms));
                var room = (Listrooms)xs.Deserialize(stream);


                using (var db = new HotelAppDbContext())
                {
                    var dbs = new DbListrooms();


                    dbs.Rooms = new List<DbRooms>();
                    foreach (var r in room.Rooms)
                    {
                        dbs.Rooms.Add(new DbRooms()
                        {

                            ResidencyTo = r.ResidencyTo,
                            ResidencyFrom = r.ResidencyFrom,
                            NumberOfPersons = r.NumberOfPersons,
                            NumberOfBeds = r.NumberOfBeds,
                            Services = r.Services,

                        } );
                    }
                    
                   

                    db.Listrooms.Add(dbs);
                    db.SaveChanges();
                }


                return View(room);
            }
        }

        public ActionResult List()
        {
            List<DbListrooms> list;
            using (var db = new HotelAppDbContext())
            {
                list = db.Listrooms.Include(s => s.Rooms).ToList();
            }

            return View(list);
        }
    }
}