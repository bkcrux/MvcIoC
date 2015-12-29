using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvcIoC.Models
{
    public interface IProteinTrackerService
    {
        int Total { get; set; }
        int Goal { get; set; }

        void AddProtein(int amount);
    }
}
