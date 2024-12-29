using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace General
{
    public enum VariableCycleType: UInt32
    {
        OnChange = 0,
        _250ms =1,
        _500ms =2,    
        _1s =3,
        _2s= 4,
        _5s = 5,
        _10s = 6,
        _1min= 7,
        _5min= 8,
        _10min= 9,
        _1h= 10,
        UserCycle1=11,
        UserCycle2=12,
        UserCycle3=13,
        UserCycle4=14,
        UserCycle5=15,
    }
}
