
            
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime;
using System.Linq.Expressions;
using System.Threading.Tasks;
using desafio.app.context;
using desafio.app.domain;
using desafio.app.model;
using desafio.app.repository;
using Microsoft.Data.Entity;
using Microsoft.Data.Entity.Infrastructure;

namespace desafio.app.service
{
    public class AccountsService
    {
        private const string notAuthorizedError = "Não autorizado";
        private const string invalidSessionError = "Sessão inválida";
        
        internal IProfileRepository profileRepository;
        internal IUsersRepository usersRepository;
        
        public AccountsService(IProfileRepository profileRepository, IUsersRepository usersRepository) {
            this.profileRepository = profileRepository;
            this.usersRepository = usersRepository;
        }
        
        protected User user;
        protected Profile profile;
        internal UsersFactory factory;
        
        protected RegisteredUserModel GetRegisteredUserModel(){
            return new RegisteredUserModel(){
                nome = profile.Name,
                email = user.Email,
                senha = user.Password,
                telefones = GetTelphoneModelCollection(),
                data_criacao = user.Created,
                data_atualizacao = user.Updated,
                ultimo_login = user.LastLogon,
                id = user.Id,
                token = user.Token
            };
        }
        
        protected IEnumerable<TelphoneModel> GetTelphoneModelCollection(){
            if(profile==null || profile.Telphones == null)
                return new List<TelphoneModel>();
            
            var telphones = new List<TelphoneModel>();
            
            foreach(var tel in profile.Telphones){
               var telphoneModel = new TelphoneModel(){
                  ddd = tel.Prefix.ToString(),
                  numero = tel.Number  
                };
                
               telphones.Add(telphoneModel);
            }
            
            return telphones;
        }
        
        protected void GenerateUserToken(){
            
            var token = JwtUtility.Encode(user.Id, UnixDateUtility.ConvertToUnixTimestamp(user.GetExpiration()), UnixDateUtility.ConvertToUnixTimestamp(user.LastLogon));
            user.SetToken(token);
        }
        
        public void Authorize(string token){
                user = usersRepository.GetByToken(token);
                
                if(user==null)
                    throw new NotAuthorizedException(notAuthorizedError);

                Guid userId = GetUserIdByToken(token);
                var tokenUser = usersRepository.GetById(userId);
                
                if(tokenUser.Token.Equals(token)){
                    var minutes = DateTime.Now.Subtract(user.LastLogon).Minutes;
                    
                    if(!(minutes < 30))
                        throw new SessionExpiredException(invalidSessionError);
                }else
                    throw new NotAuthorizedException(notAuthorizedError);
        }
        
        protected Guid GetUserIdByToken(string token){
            try{
                var jsonToken = JwtUtility.Decode(token);
                var tokenInfo = JsonUtility.Deserialize<Dictionary<string, object>>(jsonToken);
                Guid userId;
                Guid.TryParse(tokenInfo["userId"].ToString(), out userId);
                return userId;
            }catch {
                throw new SessionExpiredException(invalidSessionError);
            }
             
        }
    }
}