using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechCom.Model.Domain.Domain;

namespace TechCom.Model.Domain.Interface
{
   public interface IOrderDetails
    {
       DbSet< OrderDetail> Orders { get; }
        OrderDetail NewOrderDetail(ApplicationUser user);
    }
}
