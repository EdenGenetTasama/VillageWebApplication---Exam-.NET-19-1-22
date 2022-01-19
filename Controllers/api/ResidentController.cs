using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using VillageWebApplication___Exam.NET.Models;

namespace VillageWebApplication___Exam.NET.Controllers.api
{
    public class ResidentController : ApiController
    {
        ResitentContext dbVillage = new ResitentContext();
        // GET: api/Resident
        public IHttpActionResult Get()
        {
            try
            {
                List<Resident> listOfResident = dbVillage.Residents.ToList();
                return Ok(new { listOfResident });
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

        // GET: api/Resident/5
        public async Task<IHttpActionResult> Get(int id)
        {
            try
            {
                Resident residentById = await dbVillage.Residents.FindAsync(id);
                if (residentById != null)
                {
                    return Ok(residentById);
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

        // POST: api/Resident
        public async Task<IHttpActionResult> Post([FromBody] Resident residentToAdd)
        {
            try
            {
                if (residentToAdd != null)
                {
                    dbVillage.Residents.Add(residentToAdd);
                    await dbVillage.SaveChangesAsync();
                    return Ok($"{residentToAdd.FirstName} Added");
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

        // PUT: api/Resident/5
        public async Task<IHttpActionResult> Put(int id, [FromBody] Resident residentNewInfo)
        {
            try
            {
                Resident residentToUpdate = await dbVillage.Residents.FindAsync(id);
                if (residentToUpdate != null)
                {
                    residentToUpdate.FirstName = residentNewInfo.FirstName;
                    residentToUpdate.FatherName = residentNewInfo.FatherName;
                    residentToUpdate.Gender = residentNewInfo.Gender;
                    residentToUpdate.IsBornInVillage = residentNewInfo.IsBornInVillage;
                    residentToUpdate.DateBirth = residentNewInfo.DateBirth;
                    await dbVillage.SaveChangesAsync();
                    return Ok($"{residentToUpdate.FirstName} Has Updated");
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

        // DELETE: api/Resident/5
        public async Task<IHttpActionResult> Delete(int id)
        {
            try
            {
                Resident residentToDelete = await dbVillage.Residents.FindAsync(id);
                if (residentToDelete != null)
                {
                    dbVillage.Residents.Remove(residentToDelete);
                    await dbVillage.SaveChangesAsync();
                    return Ok("DELETE");
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
