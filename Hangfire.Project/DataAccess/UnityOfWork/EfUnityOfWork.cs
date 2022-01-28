using DataAcces.Concrete.Context;
using DataAccess.Abstarct;
using DataAccess.Concrete.EntityFramework;

namespace DataAccess.UnityOfWork
{
    public class EfUnityOfWork : IUnityOfWork
    {
        public EfUnityOfWork()
        {
            
            UserRepository = new UserRepository();
            SystemInfoRepository = new SystemInfoRepository();
        }
        public IUserRepository UserRepository { get; set; }
        public ISystemInfoRepository SystemInfoRepository { get; set; }
    }
}
