using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Model
{
    public abstract class GameObject
    {
        public int ID;

        private int curID = 1;

        public int X;
        public int Y;

        public GameObject()
        {
            ID = curID++;
        }

        public bool CheckObjectCollides(GameObject obj)
        {
            if ((this.Y > obj.Y - Game.GameObjSize && this.Y < obj.Y + Game.GameObjSize) &&
                (this.X > obj.X - Game.GameObjSize && this.X < obj.X + Game.GameObjSize))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void SetRandomPos()
        {
            Random rand = new Random();
            X = rand.Next(Game.MAP_WIDTH-Game.GameObjSize);
            Y = rand.Next(Game.MAP_HEIGHT-Game.GameObjSize);
        }
    }
}
