using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using VillageWebApplication___Exam.NET.Models;

namespace VillageWebApplication___Exam.NET.Controllers.api
{
    public class SeniorsController : ApiController
    {

        SeniorDataContext dbOldPeople = new SeniorDataContext();
        // GET: api/Seniors
        public IHttpActionResult Get()
        {
            try
            {
                List<Senior> seniorsList = dbOldPeople.Seniors.ToList();
                return Ok(new { seniorsList });
            }
            catch (SqlException ex)
            {
                return BadRequest(ex.Message);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET: api/Seniors/5
        public IHttpActionResult Get(int id)
        {
            try
            {
                Senior seniorById = dbOldPeople.Seniors.First(people => people.Id == id);
                if (seniorById != null)
                {
                    return Ok(seniorById);
                }
                return NotFound();
            }
            catch (SqlException ex)
            {
                return BadRequest(ex.Message);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // POST: api/Seniors
        public IHttpActionResult Post([FromBody] Senior seniorToAdd)
        {
            try
            {
                if (seniorToAdd != null)
                {
                    dbOldPeople.Seniors.InsertOnSubmit(seniorToAdd);
                    dbOldPeople.SubmitChanges();
                    return Ok("Added");
                }
                return NotFound();
            }
            catch (SqlException ex)
            {
                return BadRequest(ex.Message);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT: api/Seniors/5
        public IHttpActionResult Put(int id, [FromBody] Senior seniorNewInfo)
        {
            try
            {
                Senior seniorToUpdate = dbOldPeople.Seniors.First(senior => senior.Id==id);
                if (seniorToUpdate != null)
                {
                    seniorToUpdate.FullName= seniorNewInfo.FullName;
                    seniorToUpdate.BirthDay= seniorNewInfo.BirthDay;
                    seniorToUpdate.Seniority= seniorNewInfo.Seniority;
                    dbOldPeople.SubmitChanges();
                    return Ok("Update");
                }
                return NotFound();
            }
            catch (SqlException ex)
            {
                return BadRequest(ex.Message);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // DELETE: api/Seniors/5
        public IHttpActionResult Delete(int id)
        {
            try
            {
                Senior seniorToDelete = dbOldPeople.Seniors.First(peopleToDelete => peopleToDelete.Id==id);
                if (seniorToDelete != null)
                {
                    dbOldPeople.Seniors.DeleteOnSubmit(seniorToDelete);
                    dbOldPeople.SubmitChanges();
                    return Ok("Deleted");
                }
                return NotFound();
            }
            catch (SqlException ex)
            {
                return BadRequest(ex.Message);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
