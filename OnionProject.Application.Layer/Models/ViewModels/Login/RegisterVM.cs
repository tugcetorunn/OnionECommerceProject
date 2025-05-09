using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionProject.Application.Layer.Models.ViewModels.Login
{
    public class RegisterVM
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Adres { get; set; }
        public string Password { get; set; }
        [Compare("Password", ErrorMessage = "Şifreler uyuşmuyor.")]
        public string ConfirmPassword { get; set; } // neden hem dto hem vm yaptık, neden vm i burada kullandık. çünkü bu gördüğümüz vm örn bir masaüstü uygulamasında da webte de aynıdır. ui da kullanacağımız vm ler örn iformfile gibi ui a ait özellikler kullanılacağı zaman gereklidir.
    }
}
