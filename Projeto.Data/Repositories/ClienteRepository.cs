using System;
using System.Collections.Generic;
using System.Text;
using Projeto.Data.Entities; //entidades
using Projeto.Data.Contracts; //interfaces
using System.Data.SqlClient; //conexão com o banco de dados
using Dapper; //executar as rotinas SQL (queries)
using System.Linq;

namespace Projeto.Data.Repositories
{
    public class ClienteRepository : IClienteRepository
    {
        //atributo para armazenar a string de conexão
        //readonly -> atributo só pode ser inicializado pelo construtor da classe
        private readonly string connectionString;

        //Método construtor capaz de receber como parametro uma string de conexão
        public ClienteRepository(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public void Inserir(Cliente obj)
        {
            var query = "insert into Cliente(Nome, Email, DataCriacao) values(@Nome, @Email, @DataCriacao)";

            //conectando no banco de dados
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Execute(query, obj);
            }
        }

        public void Atualizar(Cliente obj)
        {
            var query = "update Cliente set Nome = @Nome, Email = @Email where IdCliente = @IdCliente";

            //conectando no banco de dados
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Execute(query, obj);
            }
        }

        public void Excluir(Cliente obj)
        {
            var query = "delete from Cliente where IdCliente = @IdCliente";

            //conectando no banco de dados
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Execute(query, obj);
            }
        }

        public List<Cliente> Consultar()
        {
            var query = "select * from Cliente";

            //conectando no banco de dados
            using (var connection = new SqlConnection(connectionString))
            {
                return connection.Query<Cliente>(query).ToList();
            }
        }

        public List<Cliente> Consultar(string nome)
        {
            var query = "select * from Cliente where Nome like @Nome";

            /*
             * select * from Cliente where Nome like 'Ana%'  -> começando com
             * select * from Cliente where Nome like '%Ana'  -> terminando com
             * select * from Cliente where Nome like '%Ana%' -> contendo
             */

            //conectando no banco de dados
            using (var connection = new SqlConnection(connectionString))
            {
                return connection.Query<Cliente>(query, new { Nome = $"%{nome}%" }).ToList();
            }
        }

        public Cliente ObterPorId(int id)
        {
            var query = "select * from Cliente where IdCliente = @IdCliente";

            //conectando no banco de dados
            using (var connection = new SqlConnection(connectionString))
            {
                return connection.Query<Cliente>(query, new { IdCliente = id }).FirstOrDefault();

                /*
                 * FirstOrDefault() -> retorna o primeiro registro obtido na execução da query
                 * ou retorna null se nenhum registro for obtido
                 */
            }
        }
    }
}
