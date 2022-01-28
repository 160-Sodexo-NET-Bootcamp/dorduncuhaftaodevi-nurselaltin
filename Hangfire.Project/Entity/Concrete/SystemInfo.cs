using Entity.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Concrete
{
    /// <summary>
    /// This datas will use for inform to system admin about Hangfire.Project.
    /// </summary>
    public class SystemInfo : IEntity
    {
        public int ID { get; set; }
        public string SystemName { get; set; }
        public string TableName { get; set; }
        public int SubscriberTotal { get; set; } // Subscribers in system
        public int NewsletterCount { get; set; } // Count of newsletter subscribers in system
        public int TodayRegisters { get; set; }
        public int ActiveCount { get; set; } //ısActive cloumn in User table
        public int PassiveCount { get; set; }
        public DateTime Date { get; set; }
    }
}
