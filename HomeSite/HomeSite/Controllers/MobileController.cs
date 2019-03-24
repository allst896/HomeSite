using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using HomeSite.Models;

namespace HomeSite.Controllers
{
    public class MobileController : ApiController
    {
        private HomeSiteDb db = new HomeSiteDb();
        private IHomeSiteDb _db;

        public MobileController()
        {
            _db = new HomeSiteDb();
        }

        public MobileController(IHomeSiteDb idb)
        {
            _db = idb;
        }

        [HttpGet]
        public IQueryable<Cow> GetCows()
        {
            return db.Cows;
        }

        [HttpGet]
        public async Task<IHttpActionResult> GetCurrentCows()
        {
            var cows = await db.Cows
                .Where(r => r.Status == "Farm")
                .Select(r =>
                new CowDTO()
                {
                    Name = r.Name,
                    DOB = r.DOB,
                    tagNumber = r.tagNumber,
                    Sex = r.Sex,
                    Owner = r.Owner,
                    Sire = r.Sire,
                    Dam = r.Dam,
                    Description = r.Description
                }).ToListAsync();

            if (cows == null) { return NotFound(); }
            return Ok(cows);
        }

        [HttpGet]
        [Route("api/Mobile/GetCowsCalves/{tagNumber}")]
        public async Task<IHttpActionResult> GetCowsCalves(int tagnumber)
        {
            var cowname = (from c in db.Cows
                           where c.tagNumber == tagnumber
                           select c).FirstOrDefault<Cow>();

            var calves = await db.Cows
                .Where(r => r.Dam == tagnumber)
                .Select(r =>
                new CalfListViewModel()
                {
                    ParentName = cowname.Name.ToString(),
                    Name = r.Name,
                    DOB = r.DOB,
                    tagNumber = r.tagNumber,
                    Sex = r.Sex,
                    Status = r.Status,
                    Owner = r.Owner,
                    Sire = r.Sire,
                    Dam = r.Dam,
                    Description = r.Description
                }).ToListAsync();

            if (calves == null) { return NotFound(); }
            return Ok(calves);
        }

        // GET api/<controller>
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<controller>/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<controller>
        public void Post([FromBody]string value)
        {
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}