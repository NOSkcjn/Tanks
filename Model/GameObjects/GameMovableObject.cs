using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public abstract class GameMovableObject : GameObject
    {
        public Direction Direct = Direction.SOUTH;
        public Direction NewDirect;

        internal const int STEP = 1;

        public GameMovableObject()
        {
            NewDirect = Direct;
        }

        public virtual void Move()
        {
            switch (Direct)
            {
                case Direction.NORTH:
                    if (Y > 0)
                    {
                        Y -= STEP;
                    }
                    else
                    {
                        NewDirect = Direction.SOUTH;
                        Y += STEP;
                    }
                    break;
                case Direction.SOUTH:
                    if (Y < Game.MAP_HEIGHT - 25)
                    {
                        Y += STEP;
                    }
                    else
                    {
                        NewDirect = Direction.NORTH;
                        Y -= STEP;
                    }
                    break;
                case Direction.WEST:
                    if (X > 0)
                    {
                        X -= STEP;
                    }
                    else
                    {
                        NewDirect = Direction.EAST;
                        X += STEP;
                    }
                    break;
                case Direction.EAST:
                    if (X < Game.MAP_WIDTH - 25)
                    {
                        X += STEP;
                    }
                    else
                    {
                        NewDirect = Direction.WEST;
                        X -= STEP;
                    }
                    break;
            }
        }

        public void SetDirection(Direction dir)
        {
            NewDirect = dir;
        }

        public void SetRandomDirection()
        {
            NewDirect = (Direction)random.Next(4);
        }

        public void TurnAround()
        {
            const int shiftKoef = 5;
            switch (Direct)
            {
                case Direction.EAST:
                    NewDirect = Direction.WEST;
                    X -= shiftKoef;
                    break;
                case Direction.WEST:
                    NewDirect = Direction.EAST;
                    X += shiftKoef;
                    break;
                case Direction.NORTH:
                    NewDirect = Direction.SOUTH;
                    Y += shiftKoef;
                    break;
                case Direction.SOUTH:
                    NewDirect = Direction.NORTH;
                    Y -= shiftKoef;
                    break;
            }
        }

        public bool ClashCheck(GameMovableObject obj)
        {
            if ((this.Direct == Direction.EAST && obj.Direct == Direction.WEST) ||
                (this.Direct == Direction.NORTH && obj.Direct == Direction.SOUTH))
            {
                return true;
            }
            else if((this.Direct == Direction.EAST || this.Direct == Direction.WEST) &&
                (obj.Direct == Direction.NORTH || obj.Direct == Direction.SOUTH) &&
                (this.Y == obj.Y))
            {
                return true;
            }
            else if ((this.Direct == Direction.NORTH || this.Direct == Direction.SOUTH) &&
                (obj.Direct == Direction.EAST || obj.Direct == Direction.WEST) &&
                (this.X == obj.X))
            {
                return true;
            }
            return false;
        }

    }
}