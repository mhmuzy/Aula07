using System;
using System.Collections.Generic;
using System.Text;
using Projeto.Data.Entities; //importando

namespace Projeto.Data.Contracts
{
    public interface IClienteRepository : IBaseRepository<Cliente>
    {
        List<Cliente> Consultar(string nome);
    }
}
