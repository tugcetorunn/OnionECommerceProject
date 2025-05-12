using OnionProject.Application.Layer.Models.DTOs.Kategoriler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionProject.Application.Layer.Services.Kategoriler
{
    public interface IKategoriService
    {
        Task<IEnumerable<KategoriListeleDTO>> KategorileriListeleAsync();
    }
}
