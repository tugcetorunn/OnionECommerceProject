using OnionProject.Application.Layer.Models.DTOs.Sepetler;
using OnionProject.Application.Layer.Models.ViewModels.Sepetler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionProject.Application.Layer.Services.Sepetler
{
    public interface ISepetService
    {
        Task SepeteEkleAsync(SepeteEkleDTO sepet);
        Task<IEnumerable<SepettekiUrunVM>> KullanicininSepettekiUrunleriniGetirAsync(int id); // uyeId
    }
}
