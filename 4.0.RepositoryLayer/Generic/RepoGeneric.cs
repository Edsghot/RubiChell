using _0._0.DataTransferLayer.Objects;

namespace _4._0.RepositoryLayer.Generic
{
    public interface RepoGeneric<Dto>
    {
        public Dto getByPk(string pk);
        public Boolean update(Dto dto);
    }
}