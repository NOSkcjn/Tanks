using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using View.Properties;

namespace View
{
    public class ViewWall : ViewGameObject
    {
        public ViewWall(GameObject model) : base(model, Resources.wall)
        {
        }
    }
}
