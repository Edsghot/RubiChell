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

        public Boolean update(DtoUser dto)
        {
            dto.password = HelperHash.HashPassword(dto.password);

            return _repoUser.update(dto);
        }

    }
}