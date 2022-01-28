using DataAcces.Concrete;
using DataAcces.Concrete.Context;
using DataAccess.Abstarct;
using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DataAccess.Concrete.EntityFramework
{
    public class UserRepository : EfRepostioryBase<User, ProjectContext>, IUserRepository
    {
        public void  UpdateMultiple()
        {
            //Get Dates
            var now = DateTime.Now;
            DateTime startDate = new DateTime(now.Year, now.Month, now.Day, 8, 0, 0);
            DateTime endDate = new DateTime(now.Year, now.Month, now.Day, 18, 0, 0);

            //Get users
            var users = base.GetAll(x => x.CreatedDate >= startDate && x.CreatedDate <= DateTime.Now).ToList();

            foreach (var item in users)
            {
                item.isActive = (item.isActive == true) ? false : true;
                base.Update(item, true);
            }
        }
    }
}
