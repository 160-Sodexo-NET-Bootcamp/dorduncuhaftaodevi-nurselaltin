using Entity.Abstract;
using System;

namespace Entity.Concrete
{
    public class User: IEntity
    {
        public int ID { get; set; }
        public string FullName { get; set; }
        public string UserName { get; set; }
        public bool Newsletter { get; set; }
        public string Password { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool isActive { get; set; }
    }
}
