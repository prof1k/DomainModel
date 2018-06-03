using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DomainModel.Entity
{
    public class ICC
    {
        [Key]
        public int idObject { get; set; }
        [Required(ErrorMessage = "Поле \"Вид услуги\" не должно быть пустым")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Длина строки должна быть от 3 до 50 символов")]
        [Display(Name = "Вид услуги")]
        public string idtypeOfService { get; set; }
        [ForeignKey("idtypeOfService")]
        public TypeOfService TypeOfService { get; set; }
        [Required(ErrorMessage = "Поле \"Интернет скорость\"должно быть больше единицы")]
        [Range(1, 100000, ErrorMessage = "Количество может быть от 1 до 100000")]
        [Display(Name = "Интернет скорость")]
        public int internetSpeed { get; set; }
        [Required(ErrorMessage = "Поле \"Последняя миля\" не должно быть пустым")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Длина строки должна быть от 3 до 50 символов")]
        [Display(Name = "Последняя миля")]        
        public string idlastMileType { get; set; }
        [ForeignKey("idlastMileType")]
        [Display(Name = "Последняя миля объект")]
        public LastMileType LastMileType { get; set; }
        [Required(ErrorMessage = "Поле \"Отделение почтовой связи\" не должно быть пустым")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Длина строки должна быть от 3 до 50 символов")]
        [Display(Name = "Отделение почтовой связи")]
        public string idpostOffice { get; set; }
        [ForeignKey("idpostOffice")]
        public PostOffice PostOffice { get; set; }
    }
}
