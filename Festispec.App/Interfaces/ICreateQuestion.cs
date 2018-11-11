using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Festispec.App.Interfaces
{
    interface ICreateQuestion
    {
        TabControl MainTabControl { get; set; }
        TabItem DefaultQuestion { get; set; }
    }
}
