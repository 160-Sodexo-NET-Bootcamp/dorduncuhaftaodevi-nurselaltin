using DataAcces.Concrete;
using DataAcces.Concrete.Context;
using DataAccess.Abstarct;
using Entity.Concrete;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class SystemInfoRepository : EfRepostioryBase<SystemInfo, ProjectContext>, ISystemInfoRepository
    {
        public Task ReportProject()
        {
            //Get User repository 
            var userRepository = new UserRepository();

            //Get Dates
            var now = DateTime.Now;
            DateTime startDate = new DateTime(now.Year, now.Month, now.Day, 8, 0, 0);
            DateTime endDate = new DateTime(now.Year, now.Month, now.Day, 18, 0, 0);

            //Get data of users table
            SystemInfo info = new SystemInfo();
            info.SystemName = "Hangfire.Project";
            info.TableName = "Users";
            info.TodayRegisters = userRepository.GetAll(x => x.CreatedDate >= startDate && x.CreatedDate <= DateTime.Now).Count();
            info.ActiveCount = userRepository.GetAll(x => x.isActive == true).Count();
            info.PassiveCount = userRepository.GetAll(x => x.isActive == false).Count();
            info.NewsletterCount = userRepository.GetAll(x => x.Newsletter == true).Count();
            info.Date = DateTime.Now;
            return base.Add(info);
        }
    }
}
