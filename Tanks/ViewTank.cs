using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using View.Properties;
using System.Drawing;

namespace View
{
    public class ViewTank: ViewGameMovableObject
    {
        public ViewTank(GameObject model): base(model, Resources.tank)
        {
            PicWidth = ViewGame.GameObjSize-5;
            PicHeight = ViewGame.GameObjSize+5;
        }
    }
}
