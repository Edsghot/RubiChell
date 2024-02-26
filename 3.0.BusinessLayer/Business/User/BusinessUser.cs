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
            if (!validateMail(request.mail))
            {
                _response.setFail("Ingrese un correo valido");
                return _response;
            }

            if (existsMail(request.mail))
            {
                _response.setFail("Ya existe un usuario creado con ese correo");
                return _response;
            }

            if (existsUserByDni(request.dni))
            {
                _response.setFail("Ya existe un usuario creado con ese dni");
                return _response;
            }

            if (!validateCreateUser(request))
            {
                _response.setFail("Ingrese credenciales correctos");
                return _response;
            }

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
            if (res)
            {
                _response.setOk(res, "Se creo correctamente");
                return _response;
            }

            _response.setFail("Error al crear usuario");
            return _response;
        }

        public DtoResponse update(DtoUser dto)
        {
            if (!validateMail(dto.mail))
            {
                _response.setFail("Ingrese un correo valido");
                return _response;
            }

            if (!validateUpdateUser(dto))
            {
                _response.setFail("Ingrese credenciales correctos");
                return _response;
            }

            dto.password = HelperHash.HashPassword(dto.password);

            var res = _repoUser.update(dto);
            isNullDto(res);
            return _response;
        }

        public DtoResponse delete(string id)
        {

            var res = _repoUser.delete(id);

            if (res)
            {
                _response.setOk(res,"Se Elimino correctamente");
                return _response;
            }

            _response.setFail("No se pudo eliminar");
            return _response;
        }

        public DtoResponse Login(DtoLoginUser request)
        {
            var password = HelperHash.HashPassword(request.password);
            if (!validateLogin(request))
            {
                _response.setFail("Ingrese credenciales correctos");
                return _response;
            }
            var res = _repoUser.login(request.mail, password);

            generarToken(res);

            return _response;
        }

    }
}