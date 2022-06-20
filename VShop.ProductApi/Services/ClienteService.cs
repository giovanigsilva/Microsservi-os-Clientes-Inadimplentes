using AutoMapper;
using VShop.ProductApi.DTOs;
using VShop.ProductApi.Models;
using VShop.ProductApi.Repositories;

namespace VShop.ProductApi.Services;

public class ClienteService : IClienteService
{
    private readonly IMapper _mapper;
    private IClienteRepositorio _clienteRepositorio;

    public ClienteService(IMapper mapper, IClienteRepositorio clienteRepositorio)
    {
        _mapper = mapper;
        _clienteRepositorio = clienteRepositorio;
    }

    public async Task AddCliente(ClienteDTO clienteDto)
    {
        var clienteEntity = _mapper.Map<Cliente>(clienteDto);
        await _clienteRepositorio.Create(clienteEntity);
        clienteDto.Id = clienteEntity.Id;
    }

    public async Task<ClienteDTO> GetClienteByID(int id)
    {
        var clienteEntity = await _clienteRepositorio.GetById(id);
        return _mapper.Map<ClienteDTO>(clienteEntity);
    }

     public async Task<IEnumerable<ClienteDTO>> GetClientes()
    {
        var clientesEntity = await _clienteRepositorio.GetAllCliente();
        return _mapper.Map<IEnumerable<ClienteDTO>>(clientesEntity);
    }

    public async Task<IEnumerable<ClienteDTO>> GetClientesOrderByDesde()
    {
        var clientesEntity = await _clienteRepositorio.GetAllClienteOrderByDesde();
        return _mapper.Map<IEnumerable<ClienteDTO>>(clientesEntity);
    }

    public async Task<IEnumerable<ClienteDTO>> GetClientesOrderByName()
    {
        var clientesEntity = await _clienteRepositorio.GetAllClienteOrderByName();
        return _mapper.Map<IEnumerable<ClienteDTO>>(clientesEntity);
    }

    public async Task<IEnumerable<ClienteDTO>> GetClientesOrderByTitulo()
    {
        var clientesEntity = await _clienteRepositorio.GetAllClienteOrderByTitulo();
        return _mapper.Map<IEnumerable<ClienteDTO>>(clientesEntity);
    }

    public async Task<IEnumerable<ClienteDTO>> GetClientesOrderByValor()
    {
        var clientesEntity = await _clienteRepositorio.GetAllClienteOrderByValor();
        return _mapper.Map<IEnumerable<ClienteDTO>>(clientesEntity);
    }

    public async Task RemoveCliente(int id)
    {
        var clienteEntity = _clienteRepositorio.GetById(id).Result;
        await _clienteRepositorio.Delete(clienteEntity.TituloId);
    }

    public async Task UpdateCliente(ClienteDTO clienteDto)
    {
        var clienteEntity = _mapper.Map<Cliente>(clienteDto);
        await _clienteRepositorio.Update(clienteEntity);
    }
}
