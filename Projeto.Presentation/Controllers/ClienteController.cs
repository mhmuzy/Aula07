using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Projeto.Presentation.Models; //importando
using Projeto.Data.Entities; //importando
using Projeto.Data.Repositories; //importando

namespace Projeto.Presentation.Controllers
{
    public class ClienteController : Controller
    {
        //método responsável por abrir a página
        public IActionResult Cadastro()
        {
            return View();
        }

        [HttpPost] //método é executado pelo formulário
        public IActionResult Cadastro(CadastrarClienteViewModel model, [FromServices] ClienteRepository repository)
        {
            //verificar se os campos da model passaram nas regras de validação
            //aplicando as validações!
            if (ModelState.IsValid)
            {
                try
                {
                    var cliente = new Cliente();
                    cliente.Nome = model.Nome;
                    cliente.Email = model.Email;
                    cliente.DataCriacao = DateTime.Now;

                    repository.Inserir(cliente);

                    TempData["Mensagem"] = "Cliente cadastrado com sucesso.";
                }
                catch (Exception e)
                {
                    TempData["Mensagem"] = e.Message;
                }
            }

            return View();
        }

        public IActionResult Consulta()
        {
            return View();
        }
    }
}