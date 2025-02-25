using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentMgmtProject.Services.ProgramService.Model;
using StudentMgmtProject.Services.ProgramService;

namespace StudentMgmtProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProgramController : ControllerBase
    {
        private readonly IProgramService _programService;

        public ProgramController(IProgramService programService)
        {
            _programService = programService;
        }

     
        [HttpGet]
        public ActionResult<List<ProgramVM>> GetAllPrograms()
        {
            var programs = _programService.GetAllPrograms();
            return Ok(programs);
        }

        [HttpGet("{id}")]
        public ActionResult<ProgramDetailViewModel> GetProgramById(int id)
        {
            var program = _programService.GetProgramById(id);
            if (program == null)
            {
                return NotFound(new { message = "Program not found" });
            }
            return Ok(program);
        }

        [HttpPost]
        public ActionResult<ProgramVM> AddProgram([FromBody] ProgramVM model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var newProgram = _programService.AddProgram(model);
            return CreatedAtAction(nameof(GetProgramById), new { id = newProgram.ProgramId }, newProgram);
        }

        [HttpPut("{id}")]
        public ActionResult<ProgramVM> UpdateProgram(int id, [FromBody] ProgramVM model)
        {
            if (id != model.ProgramId)
            {
                return BadRequest(new { message = "Program ID mismatch" });
            }

            var updatedProgram = _programService.UpdateProgram(model);
            if (updatedProgram == null)
            {
                return NotFound(new { message = "Program not found" });
            }

            return Ok(updatedProgram);
        }

        
        [HttpDelete("{id}")]
        public IActionResult DeleteProgram(int id)
        {
            var success = _programService.DeleteProgram(id);
            if (!success)
            {
                return NotFound(new { message = "Program not found" });
            }

            return NoContent(); 
        }
    }
}