using _0._0.DataTransferLayer.Objects;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Text.RegularExpressions;

namespace _3._0.BusinessLayer.Business.User
{
    public partial class BusinessUser
    {

        public void isNullDto(object data)
        {
            if (data != null && !data.Equals(default(object)))
            {
                _response.setOk(data, "La consulta fue exitosa");
                return;
            }
                _response.setFail("No se encontraron datos");
            
        }

        public Boolean validateLogin(DtoLoginUser credentials)
        {
            if (credentials.mail != default || credentials.password != default)
            {
                return true ;
            }
            return false;

        }

        public Boolean validateCreateUser(DtoCreateUser user)
        {
            if (user.dni.Length == 8 && user.firstName != default && user.surName != default)
            {
                return true;
            }
            return false;
        }

        public Boolean validateUpdateUser(DtoUser user)
        {
            if (user.dni.Length == 8 && user.firstName != default && user.surName != default)
            {
                return true;
            }
            return false;
        }

        public Boolean existsMail(string mail)
        {
            if (_repoUser.existsUser(mail))
            {
                return true;
            }
            return false;
        }
        public Boolean existsUserByDni(string mail)
        {
            if (_repoUser.existsUserByDni(mail)) { 
          
                return true;
            }
            return false;
        }

        public Boolean validateMail(string mail)
        {
            string pattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";

            if (Regex.IsMatch(mail, pattern))
            {
                return true; 
            }
            else
            {
                return false; 
            }
        }


        public void generarToken(DtoUser data)
        {
            if (data != null)
            {

                string key = "ahsaxjsaxhsaxjwqqxmkaxkamxka1=";

                var tokenHandler = new JwtSecurityTokenHandler();
                var byteKey = Encoding.UTF8.GetBytes(key);
                var tokenDes = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new Claim[]
                    {
                        new Claim(ClaimTypes.Name, data.idUser),
                    }),

                    Expires = DateTime.UtcNow.AddDays(1),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(byteKey), SecurityAlgorithms.HmacSha256Signature)
                };

                var token = tokenHandler.CreateToken(tokenDes);

                _response.setOk(tokenHandler.WriteToken(token), "Inicio de sesion Correcta");
                return;
            }

            _response.setFail("Error al iniciar sesion");
        }
    }
}