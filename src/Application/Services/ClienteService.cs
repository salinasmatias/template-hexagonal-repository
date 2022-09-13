using Application.DataAccess;
using Application.Services.Interfaces;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class ClienteService : IClienteService
    {
        private readonly IClienteRepository _repository;
        public static int _counter = 0;

        public ClienteService(IClienteRepository repository)
        {
            _repository = repository;
            _counter++;
        }

        public async Task<Cliente> GetClienteById(int id)
        {
            return await _repository.GetClienteById(id);
        }

        public int instancia()
        {
            return _counter;
        }
    }
}
