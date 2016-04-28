using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime;
using System.Linq.Expressions;
using System.Threading.Tasks;
using desafio.app.context;
using desafio.app.domain;
using desafio.app.model;
using desafio.app;
using desafio.app.repository;
using Microsoft.Data.Entity;
using Microsoft.Data.Entity.Infrastructure;

namespace desafio.app.service
{
    public class GetUserService : AccountsService, IGetUserService
    {
        private const string notAuthorizedError = "Não autorizado";
        
        public RegisteredUserModel Get(string token){
            try
            {   
                Assertion.IsFalse(string.IsNullOrEmpty(token), "Informe um token válido");
                
                Initialize();
                
                user = usersRepository.GetByToken(token);
                
                if(user==null)
                    throw new InvalidUserException(notAuthorizedError);
                
                // Caso o token exista, buscar o usuário pelo id passado através da query string e comparar se o token do usuário encontrado é igual ao token passado no header.
                // Caso não seja o mesmo token, retornar erro com status apropriado e mensagem "Não autorizado"
                // Caso seja o mesmo token, verificar se o último login foi a MENOS que 30 minutos atrás.
                // Caso não seja a MENOS que 30 minutos atrás, retornar erro com status apropriado com mensagem "Sessão inválida".
                
                profile = profileRepository.GetByUserId(user.Id);
                        
                return GetRegisteredUserModel();
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                Dispose();
            }
        }
    }
}