using OnionProject.Application.Layer.Models.DTOs.Login;
using OnionProject.Core.Layer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace OnionProject.Application.Layer.Services.Login
{
    public interface ILoginService
    {
        Task<LoginResultDTO> LoginAsync(LoginDTO login); // role id döndüreceğiz -> admin mi değil mi olarak döndürmeye karar verdik.
        Task<bool> RegisterAsync(RegisterDTO register);
        // Task<bool> Logout(); // ortama bağlı old için burada yapmıyoruz (cookie ile çalışıyor çünkü)
        Task<Uye> UyeGetirAsync(ClaimsPrincipal claims);
        Task<Uye> UyeGetirAsync(int id);

    }
}
