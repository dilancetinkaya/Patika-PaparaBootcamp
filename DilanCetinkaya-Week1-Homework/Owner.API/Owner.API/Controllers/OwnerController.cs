using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Owner.API.Data;
using Owner.API.Model;
using System.Linq;

namespace Owner.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OwnerController : ControllerBase
    {
        [Route("All")]
        [HttpGet]
        public IActionResult GetAllOwner()
        {
            var owners = new OwnerData().GetAllOwner();
            return Ok(owners);
        }

        [Route("Create")]
        [HttpPost]
        public IActionResult AddOwner(OwnerModel owner)
        {
            if (owner.Description.Contains("hack"))
                return BadRequest("no contain \"hack\"");

            var owners = new OwnerData().GetAllOwner();
            owners.Add(owner);
            return Ok(owners);

        }
        [Route("Update")]
        [HttpPut]
        public IActionResult UpdateOwner(int id, OwnerModel owner)
        {
            if (id != owner.Id)
                return BadRequest("Id not match ");

            var owners = new OwnerData().GetAllOwner();
            var updateOwner = owners.FirstOrDefault(x => x.Id == id);
            if(updateOwner == null)
                return BadRequest("Id not found");

            updateOwner.Name = owner.Name;
            updateOwner.Surname = owner.Surname;
            updateOwner.Type = owner.Type;
            updateOwner.Date = owner.Date;
            updateOwner.Description = owner.Description;
            return Ok(updateOwner);

        }
        [Route("Delete")]
        [HttpDelete]
        public IActionResult DeleteOwner(int id)
        {
            var owners = new OwnerData().GetAllOwner();
            var owner= owners.FirstOrDefault(x => x.Id == id);
            if(owner==null)
                return NotFound("Record is not found");

            owners.Remove(owner);
            return Ok(owners);
        }
    }
}
