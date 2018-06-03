using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DomainModel.Entity
{
    public class Users
    {
        [Key]
        public int id { get; set; }
        [Required(ErrorMessage = "Поле \"Логин\" не должно быть пустым")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Длина строки должна быть от 3 до 50 символов")]
        [Display(Name = "Логин")]
        public string login { get; set; }
        [Required(ErrorMessage = "Поле \"Пароль\" не должно быть пустым")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Длина строки должна быть от 3 до 50 символов")]
        [Display(Name = "Пароль")]
        public string password { get; set; }
    }
}
