using System;
using System.ComponentModel.DataAnnotations;

namespace Tarefas.Models
{
    public class TarefaItem
    {
        [Key]
        public int Id { get; set; }

        [Display(Name="Tarefa Completa")]
        public bool EstaCompleta { get; set; }

        [Required(ErrorMessage="O Nome da tarefa é obrigatório",AllowEmptyStrings=false)]
        [Display(Name="Nome da Tarefa")]
        [StringLength(200)]
        public string Nome { get; set; }
        
        [Required(ErrorMessage="A Data é obrigatória")]
        [Display(Name="Data da Conclusão")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTimeOffset? DataConclusao { get; set; }
    }
}