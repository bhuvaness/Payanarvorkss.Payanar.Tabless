using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp1.Utilitiess
{
    public static class Utility
    {
        public static string FirstParentId { get { return "00000000-0000-0000-0000-000000000000"; } }
        public static string NewUniqueId
        {
            get { return Guid.NewGuid().ToString(); }
        }
    }
}
