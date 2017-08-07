using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using View.Properties;
using System.Drawing;
using Model;

namespace View
{
    public class ViewKolobok: ViewGameMovableObject
    {
        public ViewKolobok(GameObject model): base(model, Resources.player)
        {
        
        }

        /*public ViewKolobok(PictureBox map): base()
        {
            map.Controls.Add(picture);
        }*/
    }
}
