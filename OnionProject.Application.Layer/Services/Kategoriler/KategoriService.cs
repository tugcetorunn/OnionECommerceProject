using AutoMapper;
using OnionProject.Application.Layer.Models.DTOs.Kategoriler;
using OnionProject.Core.Layer.Repositories.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionProject.Application.Layer.Services.Kategoriler
{
    public class KategoriService : IKategoriService
    {
        private readonly IKategoriRepository kategoriRepository;
        private readonly IMapper mapper;
        public KategoriService(IKategoriRepository _kategoriRepository, IMapper _mapper)
        {
            kategoriRepository = _kategoriRepository;
            mapper = _mapper;
        }
        public async Task<IEnumerable<KategoriListeleDTO>> KategorileriListeleAsync()
        {
            var kategoriler = await kategoriRepository.ListeleAsync();
            return mapper.Map<IEnumerable<KategoriListeleDTO>>(kategoriler);
        }
    }
}
