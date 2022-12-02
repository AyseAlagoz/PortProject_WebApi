using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PortProject.Data;
using PortProject.Models;

namespace PortProject.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PortController : Controller
    {
        private readonly PortDbContext dbContext;
        public PortController(PortDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet] 
        public async Task<IActionResult> getPorts()
        {
            return Ok(await dbContext.portModels.ToListAsync());
        }

        [HttpGet] 
        [Route("{id:guid}")]
        public async Task<IActionResult> getPort([FromRoute] Guid id)
        {
            var port = await dbContext.portModels.FindAsync(id);
            if (port == null)
            {
                return NotFound();
            }
            return Ok(port);
        }

        [HttpPost]
        public async Task<IActionResult> AddPort(AddPortModel addPortModel)
        {
            var port = new PortModel();
            {
                port.id = Guid.NewGuid();
                port.portName = addPortModel.portName;
                port.portCode = addPortModel.portCode;
                port.region = addPortModel.region;
                port.country = addPortModel.country;
                port.city = addPortModel.city;
            }
            await dbContext.portModels.AddAsync(port);
            await dbContext.SaveChangesAsync();

            return Ok(port);

        }

        [HttpPut]
        [Route("{id:guid}")] 
        public async Task<IActionResult> UpdatePort([FromRoute] Guid id, UpdatePortModel updatePortModel)
        {
            var port = await dbContext.portModels.FindAsync(id);
            if (port != null)
            {
                port.portName = updatePortModel.portName;
                port.portCode = updatePortModel.portCode;
                port.region = updatePortModel.region;
                port.country = updatePortModel.country;
                port.city = updatePortModel.city;

                await dbContext.SaveChangesAsync();
                return Ok(port);
            }
            return NotFound();
        }

        [HttpDelete]
        [Route("{id:guid}")]
        public async Task<IActionResult> DeletePort([FromRoute] Guid id)
        {
            var port = await dbContext.portModels.FindAsync(id);
            if (port != null)
            {
                dbContext.Remove(port);
                await dbContext.SaveChangesAsync();
                return Ok(port);
            }
            return NotFound();
        }




    }
}

