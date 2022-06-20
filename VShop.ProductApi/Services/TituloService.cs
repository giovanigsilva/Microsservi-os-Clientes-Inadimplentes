using AutoMapper;
using System.Collections.Generic;
using VShop.ProductApi.DTOs;
using VShop.ProductApi.Models;
using VShop.ProductApi.Repositories;

namespace VShop.ProductApi.Services
{
    public class TituloService : ITituloService
    {
        private readonly ITituloRepositorio _titulorepositorio;
        private readonly IMapper _mapper;

        public TituloService(ITituloRepositorio titulorepositorio, IMapper mapper)
        {
            _titulorepositorio = titulorepositorio;
            _mapper = mapper;
        }

        public async Task AddTitulo(TituloDTO tituloDto)
        {
            var tituloEntity = _mapper.Map<Titulo>(tituloDto);
            await _titulorepositorio.Create(tituloEntity);
            tituloDto.TituloId = tituloEntity.TituloId;
        }

        public async Task<TituloDTO> GetTituloByID(int id)
        {
            var tituloEntity = await _titulorepositorio.GetById(id);
            return _mapper.Map<TituloDTO>(tituloEntity);
        }

        public async Task<IEnumerable<TituloDTO>> GetTitulos()
        {
            var tituloEntity = await _titulorepositorio.GetAll();
            return _mapper.Map<IEnumerable<TituloDTO>>(tituloEntity);
        }

        public async Task<IEnumerable<TituloDTO>> GetTitulosClientes()
        {
            var tituloEntity = await _titulorepositorio.GetTitulosClientes();
            return _mapper.Map<IEnumerable<TituloDTO>>(tituloEntity);
        }

        public async Task RemoveTitulo(int id)
        {
            var tituloEntity = _titulorepositorio.GetById(id).Result;
            await _titulorepositorio.Delete(tituloEntity.TituloId);
        }

        public async Task UpdateTitulo(TituloDTO tituloDto)
        {

            var tituloEntity = _mapper.Map<Titulo>(tituloDto);
            await _titulorepositorio.Update(tituloEntity);
        }

      
    }
}
