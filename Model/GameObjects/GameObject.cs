using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.ComponentModel;

namespace Model
{
    public abstract class GameObject
    {
        public int ID;

        private int curID = 1;

        public int X
        {
            get;
            set;
        }

        public int Y
        {
            get;
            set;
        }

        protected Random random = new Random();

        public string Name
        {
            get
            {
                return ToString();
            }
        }

        public GameObject()
        {
            ID = curID++;
        }

        public bool CheckObjectCollides(GameObject obj)
        {
            if (CheckObjectCollides(obj, Game.GameObjSize))
                return true;
            else
                return false;
        }

        public bool CheckObjectCollides(GameObject obj, int size)
        {
            if ((this.Y > obj.Y - size && this.Y < obj.Y + size) &&
                (this.X > obj.X - size && this.X < obj.X + size))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void SetRandomPos(BindingList<GameObject> allObjects)
        {
            bool hurt = false;
            while (true)
            {
                X = random.Next(Game.MAP_WIDTH - Game.GameObjSize);
                Y = random.Next(Game.MAP_HEIGHT - Game.GameObjSize);
                foreach (var obj in allObjects)
                {
                    if (CheckObjectCollides(obj, 100) && !(obj.Equals(this)))
                    {
                        hurt = true;
                        break;
                    }
                    else hurt = false;
                }
                if (!hurt)
                {
                    break;
                }
            }
        }
    }
}
