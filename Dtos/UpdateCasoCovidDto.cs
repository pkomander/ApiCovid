using System;
using System.ComponentModel.DataAnnotations;

namespace ApiCovid.Dtos
{
    public class UpdateCasoCovidDto
    {
        [Required(ErrorMessage = "O campo Location é obrigatorio")]
        public string Location { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        [Required(ErrorMessage = "O campo Date é obrigatorio")]
        public DateTime Date { get; set; }
        [Required(ErrorMessage = "O campo Variant é obrigatorio")]
        public string Variant { get; set; }
        [Required(ErrorMessage = "O campo Num_Sequences é obrigatorio")]
        public int Num_Sequences { get; set; }
        [Required(ErrorMessage = "O campo Perc_Sequences é obrigatorio")]
        public double Perc_Sequences { get; set; }
        [Required(ErrorMessage = "O campo Num_Sequesces_total é obrigatorio")]
        public int Num_Sequesces_total { get; set; }
    }
}
