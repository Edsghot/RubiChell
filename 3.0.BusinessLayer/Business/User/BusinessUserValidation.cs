using _0._0.DataTransferLayer.Objects;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

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