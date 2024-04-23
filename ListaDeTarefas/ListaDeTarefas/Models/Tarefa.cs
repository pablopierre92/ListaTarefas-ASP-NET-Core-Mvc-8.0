using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace ListaDeTarefas.Models
{
	public class Tarefa
	{
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Preencha a descrição!")]
        public string Descricao { get; set; }

		[Required(ErrorMessage = "Preencha a data de vencimento!")]
		public DateTime? DataDeVencimento { get; set; } //? significa que pode ser nulo

		[Required(ErrorMessage = "Selecione uma categoria!")]
		public string CategoriaId { get; set; } // cada tarefa possui um categoria e uma categoria varias tarefas

		[ValidateNever]
        public Categoria Categoria { get; set; }

		[Required(ErrorMessage = "Selecione um status!")]
		public string StatusId { get; set; } //cada tarefa possui um Status Id
		
		[ValidateNever]
		public Status Status { get; set; }

        public bool Atrasado => StatusId == "aberto" && DataDeVencimento < DateTime.Today;  // atrasado

    }
}
