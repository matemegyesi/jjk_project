using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace jjkLib
{
    public interface IJujutsu
    {
        bool CanUseDomainExpansion { get; }
        string? DomainName { get; }
        string CursedTechnique { get; }
        int CursedEnergyAmount { get; }
    }
}
