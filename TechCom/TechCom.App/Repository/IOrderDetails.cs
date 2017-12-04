using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechCom.App.Models;

namespace TechCom.App.Repository
{
   public interface IOrderDetails
    {
       DbSet< OrderDetail> Orders { get; }
    }
}
