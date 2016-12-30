using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client1.Command
{
    public interface ICommandActive
    {
        bool IsActive { get; set; }

        event EventHandler IsActiveChanged;
    }
}
