using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CC.Models
{
    public class User
    {
        public int Id { get; set; }

        public int UserTickets { get; set; }

        [Required(ErrorMessage = "Это поле обязательно для заполнения")]
        [Display(Name = "Имя")]
        [DataType(DataType.Text)]
        [StringLength(25, ErrorMessage = "Максмальная длина - {0} букв, минимальная длина - {2}", MinimumLength = 2)]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Это поле обязательно для заполнения")]
        [Display(Name = "Фамилия")]
        [DataType(DataType.Text)]
        [StringLength(25, ErrorMessage = "Максмальная длина - {0} букв, минимальная длина - {2}", MinimumLength = 2)]
        public string UserSurname { get; set; }

        [Required(ErrorMessage = "Это поле обязательно для заполнения")]
        [Display(Name = "Пароль")]
        [DataType(DataType.Password)]
        [StringLength(25, ErrorMessage = "Максимальная длина - {0} символов, минимальная длина - {2} символов", MinimumLength = 5)]
        public string UserPassword { get; set; }

        [Compare("UserPassword", ErrorMessage = "Подтвердите Ваш пароль")]
        [DataType(DataType.Password)]
        [Display(Name = "Подтверждение пароля")]
        public string ConfirmPassword { get; set; }

        [Required(ErrorMessage = "Это поле обязательно для заполнения")]
        [Display(Name = "Защитный код", Description = "Придумайте любое число, позже он вам понадобится для оформления заказов")]
        [RegularExpression(@"[0-9]{2,6}")]
        public string UserSecurityCode { get; set; }
    }
}