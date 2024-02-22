using _0._0.DataTransferLayer.Objects;
using _0._0.DataTransferLayer.Request;
using _1._0.HelpersLayer.Helper;
using Azure.Core;

namespace _3._0.BusinessLayer.Business.User
{
    public partial class BusinessUser
    {
        public Guid guid;
        public DtoUser getByPk(string pk) 
        {
            return _repoUser.getByPk(pk);
        }

        public List<DtoUser> getAll() 
        {
            return _repoUser.getAll();
        }
        public Boolean insert(RequestUser request)
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


            return _repoUser.insert(dto);
        }

        public string update(DtoUser dto)
        {
            dto.password = HelperHash.HashPassword(dto.password);

            var res = _repoUser.update(dto);

            if (res)
            {
                return "Se actualizo correctamente";
            }
            return "Hubo un error al actualizar";
        }

        public Boolean delete(string id)
        {

            return _repoUser.delete(id);
        }

        public DtoUser Login(RequestLoginUser request)
        {
            var password = HelperHash.HashPassword(request.password);
            return _repoUser.login(request.mail, password);
        }

    }
}