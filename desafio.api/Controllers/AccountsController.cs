using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace desafio.api.Controllers
{
    [Route("api/[controller]")]
    public class AccountsController : Controller
    {
        // GET api/profile/5
        [HttpGet("profile/{id}")]
        public object Profile(int id)
        {
            // * Chamadas para este endpoint devem conter um header na requisição de Authentication com o valor "Bearer {token}" onde {token} é o valor do recebido através do SignUp ou Login de um usuário.
            // * Caso o token não exista, retornar erro com status apropriado com a mensagem "Não autorizado".
            // * Caso o token exista, buscar o usuário pelo id passado através da query string e comparar se o token do usuário encontrado é igual ao token passado no header.
            // * Caso não seja o mesmo token, retornar erro com status apropriado e mensagem "Não autorizado"
            // * Caso seja o mesmo token, verificar se o último login foi a MENOS que 30 minutos atrás.
            // * Caso não seja a MENOS que 30 minutos atrás, retornar erro com status apropriado com mensagem "Sessão inválida".
            // * Caso tudo esteja ok, retornar os dados do usuário.
            return new { Message = "Sessão Inválida" };
        }

        // POST api/signup
        [HttpPost]
        public void SignUp([FromBody]string value)
        {
          //  return value;
        }
        
        // POST api/signin
        [HttpPost]
        public void SignIn([FromBody]string value)
        {
            //return value;
        }
    }
}
