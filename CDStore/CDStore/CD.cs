using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CDStore
{
    public class CD
    {
        public int CDid { get; set; }

        public string Title { get; set; }

        public string RecordCompany { get; set; }

        public DateTime Published { get; set; }

        public virtual List<Song> Songs { get; set; }

        public CD()
        {
            Songs = new List<Song>();
        }
    }
}
