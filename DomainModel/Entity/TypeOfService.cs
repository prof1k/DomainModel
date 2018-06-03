using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace DomainModel.Entity
{
    public class TypeOfService
    {
        [Key]
        [Required(ErrorMessage = "Поле \"Вид услуги\" не должно быть пустым")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Длина строки должна быть от 3 до 50 символов")]
        [Display(Name = "Вид услуги")]
        public string typeOfService { get; set; }
    }
}
