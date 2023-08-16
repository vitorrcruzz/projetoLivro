using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace projectLivro.Models
{
    public class modelLivro
    {
        [Key]
        [DisplayName("Id")]
        public int id_Livro { get; set; }

        [DisplayName("Título")]
        [Required(ErrorMessage = "O campo Título é obrigatório.")]
        [StringLength(80, ErrorMessage = "O Título deve conter apenas 80 caracteres.")]
        public string nm_Livro { get; set; }

        [DisplayName("Data Início")]
        [Required(ErrorMessage = "O campo Data é obrigatório.")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd//MM/yyyy}")]
        public DateTime data_Inicio { get; set; }

        [DisplayName("Data Término")]
        [Required(ErrorMessage = "O campo Data é obrigatório.")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd//MM/yyyy}")]
        public DateTime data_Termino { get; set; }

        [DisplayName("Nota")]
        [Required(ErrorMessage = "O campo nota é obrigatório.")]
        [StringLength(5, ErrorMessage = "A nota deve conter apenas 5 caracteres.")]
        public string nota_Livro { get; set; }
    }
}