using DataAcces.Abstarct;
using Entity.Concrete;
using System.Threading.Tasks;

namespace DataAccess.Abstarct
{
    public interface ISystemInfoRepository : IRepositoryBase<SystemInfo>
    {
        Task ReportProject();
    }
}
