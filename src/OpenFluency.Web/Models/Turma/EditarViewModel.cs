using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace OpenFluency.Web.Models.Turma
{
    public class EditarViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "O campo Ano é obrigatório.")]
        public required int Ano { get; set; }

        [Required(ErrorMessage = "O campo Semestre é obrigatório.")]
        public required int Semestre { get; set; }

        [Required(ErrorMessage = "O campo Professor é obrigatório.")]
        public required int ProfessorId { get; set; }

        [Required(ErrorMessage = "O campo Nível é obrigatório.")]
        public required string Nivel { get; set; }

        [Required(ErrorMessage = "O campo Período é obrigatório.")]
        public required string Periodo { get; set; }

        public List<SelectListItem>? Semestres { get; set; }
        public List<SelectListItem>? Professores { get; set; }
    }
}
