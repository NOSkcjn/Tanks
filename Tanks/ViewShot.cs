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
    public class ViewShot : ViewGameMovableObject
    {
        public ViewShot(GameObject model) : base(model, Resources.bullet)
        {
            PicWidth = PicHeight = 20;
        }
    }
}
