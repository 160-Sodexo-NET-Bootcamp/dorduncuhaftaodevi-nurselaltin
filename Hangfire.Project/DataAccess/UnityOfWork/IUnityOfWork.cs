using DataAcces.Abstarct;
using DataAccess.Abstarct;

namespace DataAccess.UnityOfWork
{
    public interface IUnityOfWork
    {
        public IUserRepository UserRepository { get;  set; }
        public ISystemInfoRepository SystemInfoRepository { get; set; }
    }
}
