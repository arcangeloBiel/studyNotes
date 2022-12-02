using DevStudyNotes.API.Entities;
using DevStudyNotes.API.Models;
using Microsoft.AspNetCore.Mvc;

namespace DevStudyNotes.API.Controllers {
    [ApiController]
    [Route("api/study-notes")]
    public class StudyNotesController: ControllerBase {
        
        [HttpGet]
        public IActionResult GetAll() {
            return Ok();
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
