using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechCom.App.Models;

namespace TechCom.App.Repository
{
 public interface IMail
    {
        void SendConfirmationOrder(OrderDetail order);
        void SendConfirmationRealizeOrder(OrderDetail order);
    }
}
