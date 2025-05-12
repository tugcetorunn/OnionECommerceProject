using AutoMapper;
using OnionProject.Application.Layer.Models.DTOs.Urunler;
using OnionProject.UI.MVCCore.ViewModels.Urunler;

namespace OnionProject.UI.MVCCore.UIMappers
{
    public class UIMapper : Profile
    {
        public UIMapper()
        {
            CreateMap<UrunEkleVM, UrunEkleDTO>();
        }
    }
}
