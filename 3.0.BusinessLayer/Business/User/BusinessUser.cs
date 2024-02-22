using _0._0.DataTransferLayer.Objects;
using _0._0.DataTransferLayer.Request;

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
        public int insert(RequestUser request)
        {
            var dto = new DtoUser
            {
                idUser = Guid.NewGuid().ToString(),
                dni = request.dni,
                mail = request.mail,
                password = request.password,
                firstName = request.firstName,
                surName = request.surName,
                birthDate = request.birthDate,
                gender = request.gender,
                registerDate = DateTime.Now,
            };


            return _repoUser.insert(dto);
        }
    }
}