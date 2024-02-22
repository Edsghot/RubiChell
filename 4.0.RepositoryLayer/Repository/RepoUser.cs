using _0._0.DataTransferLayer.Objects;
using _4._0.RepositoryLayer.Generic;

namespace _4._0.RepositoryLayer.Repository
{
    public interface RepoUser : RepoGeneric<DtoUser>
    {
        public List<DtoUser> getAll();
        DtoUser login(string mail, string password);
        public Boolean insert(DtoUser dto);
        public Boolean delete(string id);
    }
}