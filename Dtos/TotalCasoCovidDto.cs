using System;
using System.ComponentModel.DataAnnotations;

namespace ApiCovid.Dtos
{
    public class TotalCasoCovidDto
    {
        [Required(ErrorMessage = "O campo Location é obrigatorio")]
        public string Location { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        [Required(ErrorMessage = "O campo Date é obrigatorio")]
        public DateTime Date { get; set; }
        [Required(ErrorMessage = "O campo Variant é obrigatorio")]
        public string Variant { get; set; }
        [Required(ErrorMessage = "O campo TotalCasos é obrigatorio")]
        public int TotalCasos { get; set; }
    }
}
