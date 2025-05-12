using AutoMapper;
using Microsoft.EntityFrameworkCore;
using OnionProject.Application.Layer.Models.DTOs.Urunler;
using OnionProject.Application.Layer.Models.ViewModels.Urunler;
using OnionProject.Core.Layer.Entities;
using OnionProject.Core.Layer.Enums;
using OnionProject.Core.Layer.Repositories.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionProject.Application.Layer.Services.Urunler
{
    public class UrunService : IUrunService
    {
        private readonly IUrunRepository urunRepository;
        private readonly IMapper mapper;
        public UrunService(IUrunRepository _urunRepository, IMapper _mapper)
        {
            urunRepository = _urunRepository;
            mapper = _mapper;
        }

        public async Task<UrunAdminDetayVM> AdmineUrunBulAsync(int urunId)
        {
            var urun = await urunRepository.UrunBulAsync(urunId);
            return mapper.Map<UrunAdminDetayVM>(urun);
        }

        public async Task<UrunAdminDetayVM> UrunDetayGetirAsync(int urunId)
        {
            var urun = await urunRepository.FiltreleVeListeleAsync(x => new UrunAdminDetayVM
            {
                UrunId = x.UrunId,
                UrunAdi = x.UrunAdi,
                Aciklama = x.Aciklama,
                Fiyat = x.Fiyat,
                StokAdedi = x.StokAdedi,
                KategoriId = x.KategoriId,
                EklenmeTarihi = x.EklenmeTarihi,
                GuncellenmeTarihi = x.GuncellenmeTarihi,
                SilinmeTarihi = x.SilinmeTarihi,
                KayitDurumuEnum = x.KayitDurumu,
                Kategori = x.Kategori.KategoriAdi,
            }, x => x.UrunId == urunId, null, x => x.Include(x => x.Kategori));

            return urun.SingleOrDefault();
        }

        public async Task UrunEkleAsync(UrunEkleDTO urun)
        {
            var urunEntity = mapper.Map<Urun>(urun);
            await urunRepository.EkleAsync(urunEntity);
        }

        public async Task UrunGuncelleAsync(UrunGuncelleDTO urun)
        {
            var urunEntity = mapper.Map<Urun>(urun);
            await urunRepository.GuncelleAsync(urunEntity);
        }

        public async Task<IEnumerable<UrunListeleDTO?>> UrunleriListeleAsync()
        {
            var urunler = await urunRepository.UrunleriListeleAsync();
            if (urunler == null) // repo içinden null dönerse bile önle
                return Enumerable.Empty<UrunListeleDTO>();

            var urunlerDTO = mapper.Map<IEnumerable<UrunListeleDTO>>(urunler);
            
            return urunlerDTO;
        }

        public async Task UrunSilAsync(int urunId)
        {
            await urunRepository.SilAsync(urunId);
        }

        public async Task<UrunUyeDetayVM> UyeyeUrunBulAsync(int urunId)
        {
            var urun = await urunRepository.UrunBulAsync(urunId);
            return mapper.Map<UrunUyeDetayVM>(urun);
        }
    }
}
