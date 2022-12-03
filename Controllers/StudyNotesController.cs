using DevStudyNotes.API.Entities;
using DevStudyNotes.API.Models;
using DevStudyNotes.API.Persistence;
using Microsoft.AspNetCore.Mvc;
using Serilog;

namespace DevStudyNotes.API.Controllers {
    [ApiController]
    [Route("api/study-notes")]
    public class StudyNotesController: ControllerBase {

        private readonly StudyNoteDbContext _context;
        public StudyNotesController(StudyNoteDbContext context) {
            _context = context;
        }
        
        // api/sudy-notes http get
        [HttpGet]
        public IActionResult GetAll() {
            var studyNotes = _context.StudyNotes.ToList();
            Log.Information("GetAll is called");
            throw new Exception("GetAll is a error");
            return Ok(studyNotes);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id) {
            return Ok();
        }
        /// <summary>
        /// Cadastrar uma nota de estudo
        /// </summary>
        /// <param name="model">Dados de uma nota de estudo</param>
        /// <returns>Objeto recém criado</returns>

        [HttpPost]
        public IActionResult Post(AddStudyNoteInputModel model) {
            var studyNote = new StudyNote(model.Title, model.Description, model.IsPublic);
            return CreatedAtAction("GetById", new { id = studyNote.Id }, model);
        }

        [HttpPost("{id}/reactions")]
        public IActionResult PostReaction(int id,AddReactionStudyNoteInputModel model) {
            return NoContent();
        }
    }
}
