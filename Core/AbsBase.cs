using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    public abstract class AbsBase
    {
        public string ID { get; set; }
        public DateTimeOffset TimeStamp { get; set; }

        public AbsBase()
        {
            ID = Guid.NewGuid().ToString();
            TimeStamp = DateTime.Now;
        }
    }
}
