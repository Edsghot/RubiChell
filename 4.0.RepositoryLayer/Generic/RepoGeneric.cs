using _0._0.DataTransferLayer.Objects;

namespace _4._0.RepositoryLayer.Generic
{
    public interface RepoGeneric<Dto>
    {
        public int insert(DtoUser dto);
        public int update(Dto dto);
        public int delete(string id);
        public Dto getByPk(string pk);
    }
}