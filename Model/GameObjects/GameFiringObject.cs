using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public abstract class GameFiringObject: GameMovableObject
    {
        public event Action<Shot> OnShooting;
        public void Shoot()
        {
            Shot shot = new Shot();
            shot.X = this.X;
            shot.Y = this.Y;
            int distance = Game.GameObjSize;
            switch (Direct)
            {
                case Direction.EAST:
                    shot.X += distance;
                    break;
                case Direction.WEST:
                    shot.X -= distance;
                    break;
                case Direction.SOUTH:
                    shot.Y += distance;
                    break;
                case Direction.NORTH:
                    shot.Y -= distance;
                    break;
            }
            shot.Direct = shot.NewDirect = this.Direct;
            OnShooting?.Invoke(shot);
        }
    }
}
