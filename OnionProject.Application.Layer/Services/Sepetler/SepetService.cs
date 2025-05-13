using AutoMapper;
using Microsoft.EntityFrameworkCore;
using OnionProject.Application.Layer.Models.DTOs.Sepetler;
using OnionProject.Application.Layer.Models.ViewModels.Sepetler;
using OnionProject.Core.Layer.Entities;
using OnionProject.Core.Layer.Repositories.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionProject.Application.Layer.Services.Sepetler
{
    public class SepetService : ISepetService
    {
        private readonly ISepetRepository sepetRepository;
        private readonly IMapper mapper;
        public SepetService(ISepetRepository _sepetRepository, IMapper _mapper)
        {
            sepetRepository = _sepetRepository;
            mapper = _mapper;
        }
        public async Task<IEnumerable<SepettekiUrunVM>> KullanicininSepettekiUrunleriniGetirAsync(int id)
        {
            // sepet için soft delete yapılmayacağını düşündük. sepetteki silme işlemi delete olmalı.
            var sepettekiUrunler = await sepetRepository.FiltreleVeListeleAsync(x => new SepettekiUrunVM
            {
                SepetId = x.SepetId,
                UyeId = x.UyeId,
                UrunId = x.UrunId,
                UrunAdi = x.Urun.UrunAdi,
                Adet = x.Adet,
                Fiyat = x.Urun.Fiyat,
            }, x => x.UyeId == id, null, x => x.Include(x => x.Urun));

            return sepettekiUrunler;
        }

        public async Task SepeteEkleAsync(SepeteEkleDTO sepet)
        {
            var sepettekiUrun = (await sepetRepository.FiltreleVeListeleAsync(x => x, x => x.UrunId == sepet.UrunId && x.UyeId == sepet.UyeId, null, null)).SingleOrDefault();

            Sepet yeniSepet = new();

            if (sepettekiUrun == null)
            {
                // insert
                mapper.Map(sepet, yeniSepet);
                await sepetRepository.EkleAsync(yeniSepet);
            }
            else
            {
                // update
                sepettekiUrun.Adet += sepet.Adet;
                // sepettekiUrun.Adet = sepet.Adet; // önyüzde adet seçilecek... o yüzden += kullanmadık.
                // mapper.Map(sepet, yeniSepet);
                await sepetRepository.GuncelleAsync(sepettekiUrun);
            }


        }
    }
}
