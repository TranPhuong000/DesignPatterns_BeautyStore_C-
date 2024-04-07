using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeautyStore.Interfaces
{
    public interface Iterator<list>
    {
        list First();
        list Next();
        bool IsDone { get; }
        list CurrentIT { get; }
    }
}
