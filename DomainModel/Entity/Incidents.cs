using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DomainModel.Entity
{
    public class Incidents
    {
        [Key]
        public int idIncident { get; set; }
        [Display(Name = "Id канала связи")]
        public int idObject { get; set; }
        [ForeignKey("idObject")]
        public ICC ICC { get; set; }
        [Required(AllowEmptyStrings = false,ErrorMessage ="Дата открытия инцидента не должна быть пустой")]
        //[RegularExpression(@"(0[1-9]|[12][0-9]|3[01])[- /.](0[1-9]|1[012])[- /.](19|20)\d\d", ErrorMessage = "Дата должна быть в формате DD/MM/YYYY")]
        [DataType(DataType.Date, ErrorMessage = "Дата открытия инцидета не является датой")]
        [Display(Name = "Дата открытия инцидента")]        
        public DateTime incidentOpening { get; set; }
        //[RegularExpression(@"(0[1-9]|[12][0-9]|3[01])[- /.](0[1-9]|1[012])[- /.](19|20)\d\d",ErrorMessage ="Дата должна быть в формате DD/MM/YYYY")]        
        [DataType(DataType.Date,ErrorMessage ="Дата закрытия инцидета не является датой")]
        [Display(Name = "Дата закрытия инцидента")]
        [DisplayFormat(ConvertEmptyStringToNull =true,NullDisplayText ="[Инцидент не закрыт]")]
        //[Required(AllowEmptyStrings = true, ErrorMessage = "Ошибка в поле Дата закрытия инцидента")]
        public DateTime? IncidentClose { get; set; }
        [Display(Name = "Инцидент в Ай-теко")]
        public string incidentNumberIteko { get; set; }
        [Required(ErrorMessage = "Поле \"Номер инцидента в Ростелеком\" не должно быть пустым")]
        [Range(0,999999, ErrorMessage = "Должна быть от 0 до 999999")]
        [Display(Name = "Инцидент в Ростелеком")]
        public int incidentNumberRT { get; set; }
        [Required(ErrorMessage = "Поле \"Описание\" не должно быть пустым")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Длина строки должна быть от 3 до 50 символов")]
        [Display(Name = "Описание")]
        public string description { get; set; }
       
        public DateTime timestamp { get; set; }
    }
}
