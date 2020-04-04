using System;
using System.Collections.Generic;
using System.Text;

namespace Projeto.Data.Contracts
{
    //<T> tipo de dado genérico
    public interface IBaseRepository<T>
        where T : class //regra para que <T> só possa ser utilizado como classe
    {
        //métodos abstratos
        void Inserir(T obj);
        void Atualizar(T obj);
        void Excluir(T obj);
        List<T> Consultar();
        T ObterPorId(int id);
    }
}
