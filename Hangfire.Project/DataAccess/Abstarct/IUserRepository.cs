using DataAcces.Abstarct;
using Entity.Concrete;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataAccess.Abstarct
{
    public interface IUserRepository: IRepositoryBase<User>
    {
        void UpdateMultiple();   
    }
}
