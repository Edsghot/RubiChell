using _0._0.DataTransferLayer.Generic;
using _0._0.DataTransferLayer.Objects;
using _1._0.HelpersLayer.Helper;
using Azure.Core;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace _3._0.BusinessLayer.Business.User
{
    
    public partial class BusinessUser
    {
        public DtoResponse getByPk(string pk) 
        {
            var res = _repoUser.getByPk(pk);
            isNullDto(res);
            return _response;
        }

        public DtoResponse getAll()
        {
            var res =  _repoUser.getAll();
            isNullDto(res);
            return _response;
        }
        public DtoResponse insert(DtoCreateUser request)
        {
            var dto = new DtoUser
            {
                idUser = Guid.NewGuid().ToString(),
                dni = request.dni,
                mail = request.mail,
                password = HelperHash.HashPassword(request.password),
                firstName = request.firstName,
                surName = request.surName,
                birthDate = request.birthDate,
                gender = request.gender,
                registerDate = DateTime.Now,
            };


            var res = _repoUser.insert(dto);

            isNullDto(res);
            return _response;
        }

        public DtoResponse update(DtoUser dto)
        {
            dto.password = HelperHash.HashPassword(dto.password);

            var res = _repoUser.update(dto);
            isNullDto(res);
            return _response;
        }

        public DtoResponse delete(string id)
        {

            var res = _repoUser.delete(id);

            isNullDto(res);
            return _response;
        }

        public DtoResponse Login(DtoLoginUser request)
        {
            var password = HelperHash.HashPassword(request.password);
            var res = _repoUser.login(request.mail, password);
            generarToken(res);
            return _response;
        }

    }
}