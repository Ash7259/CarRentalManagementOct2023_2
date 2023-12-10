using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CarRentalManagementOct2023_2.Server.Data;
using CarRentalManagementOct2023_2.Shared.Domain;
using CarRentalManagementOct2023_2.Server.IRepository;
using CarRentalManagementOct2023_2.Server.IRepository;

namespace CarRentalManagement.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class modelsController : ControllerBase
    {
        //Refactored
        //private readonly ApplicationDbContext _context;
        private readonly IUnitOfWork _unitOfWork;

        //Refactored
        //punlicmodelsController(ApplicationDbContext context)
        public modelsController(IUnitOfWork unitOfWork)
        {
            //Refactored
            //_context = context;
            _unitOfWork = unitOfWork;
        }

        // GET: api/models
        [HttpGet]
        //Refactored
        //public async Task<ActionResult<IEnumerable<model>>> Getmodels()
        public async Task<IActionResult> Getmodels()
        {
            //Refactored
            //return await _context.models.ToListAsync();
            var models = await _unitOfWork.Models.GetAll();
            return Ok(models);
        }

        // GET: api/models/5
        [HttpGet("{id}")]
        //Refactored
        //public async Task<ActionResult<model>> Getmodel(int id)
        public async Task<ActionResult<Model>> Getmodel(int id)
        {
            //Refactored
            //var model = await _context.models.FindAsync(id);
            var model = await _unitOfWork.Models.Get(q => q.Id == id);

            if (model == null)
            {
                return NotFound();
            }

            //Refactored
            return Ok(model);
        }

        // PUT: api/models/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> Putmodel(int id, Model model)
        {
            if (id != model.Id)
            {
                return BadRequest();
            }

            //Refactored
            //_context.Entry(model).State = EntityState.Modified;
            _unitOfWork.Models.Update(model);

            try
            {
                //Refactored
                //await _context.SaveChangesAsync();
                await _unitOfWork.Save(HttpContext);
            }
            catch (DbUpdateConcurrencyException)
            {
                //Refactored
                //if (!modelExists(id))
                if (!await ModelExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/models
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Model>> Postmodel(Model model)
        {
            //Refactored
            //_context.models.Add(model);
            //await _context.SaveChangesAsync();
            await _unitOfWork.Models.Insert(model);
            await _unitOfWork.Save(HttpContext);

            return CreatedAtAction("Getmodel", new { id = model.Id }, model);
        }

        // DELETE: api/models/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Deletemodel(int id)
        {
            //Refactored
            //var model = await _context.models.FindAsync(id);
            var model = await _unitOfWork.Models.Get(q => q.Id == id);
            if (model == null)
            {
                return NotFound();
            }

            //Refactored
            //_context.models.Remove(model);
            //await _context.SaveChangesAsync();
            await _unitOfWork.Models.Delete(id);
            await _unitOfWork.Save(HttpContext);

            return NoContent();
        }

        //Refactored
        //private bool modelExists(int id)
        private async Task<bool> ModelExists(int id)
        {
            //Refactored
            //return _context.models.Any(e => e.Id == id);
            var model = _unitOfWork.Models.Get(q => q.Id == id);
            return model != null;
        }
    }
}
