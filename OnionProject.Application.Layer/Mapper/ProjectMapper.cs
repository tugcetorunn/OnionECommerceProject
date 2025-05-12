using AutoMapper;
using OnionProject.Application.Layer.Models.DTOs.Kategoriler;
using OnionProject.Application.Layer.Models.DTOs.Login;
using OnionProject.Application.Layer.Models.DTOs.Urunler;
using OnionProject.Application.Layer.Models.ViewModels.Login;
using OnionProject.Application.Layer.Models.ViewModels.Urunler;
using OnionProject.Core.Layer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionProject.Application.Layer.Mapper
{
    public class ProjectMapper : Profile
    {
        public ProjectMapper()
        {
            CreateMap<RegisterVM, Uye>().ReverseMap();
            CreateMap<RegisterDTO, Uye>().ReverseMap();
            CreateMap<RegisterDTO, RegisterVM>().ReverseMap();

            CreateMap<UrunAdminDetayVM, Urun>().ReverseMap().ForMember(dest => dest.Kategori, opt => opt.MapFrom(src => src.Kategori.KategoriAdi));
            CreateMap<UrunUyeDetayVM, Urun>().ReverseMap().ForMember(dest => dest.Kategori, opt => opt.MapFrom(src => src.Kategori.KategoriAdi));
            CreateMap<UrunEkleDTO, Urun>().ReverseMap();
            CreateMap<UrunGuncelleDTO, Urun>().ReverseMap();
            CreateMap<UrunListeleDTO, Urun>().ReverseMap().ForMember(dest => dest.Kategori, opt => opt.MapFrom(src => src.Kategori.KategoriAdi));
            // CreateMap<UrunEkleDTO, UrunEkleVM>().ReverseMap();

            CreateMap<KategoriListeleDTO, Kategori>().ReverseMap();
        }
    }
}
