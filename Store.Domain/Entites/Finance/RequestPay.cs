using Store.Domain.Entites.Commons;
using Store.Domain.Entites.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Domain.Entites.Finance
{
    public  class RequestPay:BaseEntity
    {
        public Guid Guid { get; set; }
        public virtual User User { get; set; }
        public long UseriD { get; set; }
        public int Amount { get; set; }
        public bool  IsPay { get; set; }
        public DateTime? PayDate { get; set; }
        public string Autority { get; set; }
        public long RefId { get; set; } = 0;
    }
}
