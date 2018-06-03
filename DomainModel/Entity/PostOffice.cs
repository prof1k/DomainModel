using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DomainModel.Entity
{
    public class PostOffice
    {
        [Key]
        [Required(ErrorMessage = "Поле \"Отделение почтовой связи\" не должно быть пустым")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Длина строки должна быть от 3 до 50 символов")]
        [Display(Name = "Отделение почтовой связи")]
        public string postOffice { get; set; }
        [Required(ErrorMessage = "Поле \"Индекс\" не должно быть пустым")]
        [Range(634000, 636999, ErrorMessage = "Должна быть от 634000 до 636999")]
        [Display(Name = "Индекс")]
        public int postalCode { get; set; }
        [Required(ErrorMessage = "Поле \"Почтамт\" не должно быть пустым")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Длина строки должна быть от 3 до 50 символов")]
        [Display(Name = "Почтамт")]
        public string idpost { get; set; }
        [ForeignKey("idpost")]
        public Post Post { get; set; }
    }
}
