using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Shot: GameMovableObject
    {
        public static event Action<Shot> OnShoot;
        public static event Action<Shot> OnShotDelete;

        public Shot(): base()
        {
            OnShoot?.Invoke(this);
        }

        public override void Move()
        {
            int step = STEP * 2;

            switch (Direct)
            {
                case Direction.NORTH:
                    if (Y > 0)
                    {
                        Y -= step;
                    }
                    else
                    {
                        OnShotDelete?.Invoke(this);
                    }
                    break;
                case Direction.SOUTH:
                    if (Y < Game.MAP_HEIGHT - 25)
                    {
                        Y += step;
                    }
                    else
                    {
                        OnShotDelete?.Invoke(this);
                    }
                    break;
                case Direction.WEST:
                    if (X > 0)
                    {
                        X -= step;
                    }
                    else
                    {
                        OnShotDelete?.Invoke(this);
                    }
                    break;
                case Direction.EAST:
                    if (X < Game.MAP_WIDTH - 25)
                    {
                        X += step;
                    }
                    else
                    {
                        OnShotDelete?.Invoke(this);
                    }
                    break;
            }
        }

        public override string ToString()
        {
            return "Shot";
        }
    }
}
