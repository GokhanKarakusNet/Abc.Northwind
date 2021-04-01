using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Abc.Northwind.Entities.Concrete;

namespace Abc.Northwind.MvcWebUI.Services
{
   public interface ICartSessionService
    {
        Cart GetCart();
        void SetCart(Cart cart);
    }
}
