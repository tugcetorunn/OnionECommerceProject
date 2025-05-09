using AutoMapper;
using OnionProject.Application.Layer.Models.DTOs.Login;
using OnionProject.Application.Layer.Models.ViewModels.Login;
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
        }
    }
}
