using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Norda.DAL.Entities
{
    public enum EOrderStatus
    {
        Hazırlanıyor = 1,
        KargoyaVerildi = 2,
        TeslimEdildi = 3,
        İptalEdildi = 4
    }
}
