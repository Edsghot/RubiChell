using _0._0.DataTransferLayer.Objects;

namespace _4._0.RepositoryLayer.Generic
{
    public interface RepoGeneric<Dto>
    {
        public Boolean insert(DtoUser dto);
        public Boolean update(Dto dto);
        public Boolean delete(string id);
        public Dto getByPk(string pk);
    }
}