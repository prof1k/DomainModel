using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace DomainModel.Entity
{
    public class Post
    {
        [Key]
        [Required(ErrorMessage = "Поле \"Почтамт\" не должно быть пустым")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Длина строки должна быть от 3 до 50 символов")]
        [Display(Name = "Почтамт")]
        public string post { get; set; }
    }
}
