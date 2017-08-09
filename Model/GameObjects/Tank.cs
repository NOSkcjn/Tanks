using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Tank : GameFiringObject
    {
        public int Updates;

        public Tank(): base()
        {
            Direct = Direction.NORTH;
        }

        public override string ToString()
        {
            return "Tank";
        }
    }
}
