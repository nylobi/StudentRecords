using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CDStore
{
    class CD
    {
        public int CDid { get; set; }

        public string Title { get; set; }

        public string RecordCompany { get; set; }

        public DateTime Published { get; set; }

        public string[] song { get; set; }
    }
}
