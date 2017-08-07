using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public abstract class GameMovableObject: GameObject
    {
        public Direction Direct = Direction.SOUTH;
        public Direction NewDirect;

        private const int STEP = 1;

        public GameMovableObject()
        {
            NewDirect = Direct;
        }

        public void Move()
        {
            switch(Direct)
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
                    if (Y < Game.MAP_HEIGHT-25)
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
                    if (X < Game.MAP_WIDTH-25)
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

        public void TurnAround()
        {
            const int shiftKoef = 5;
            switch(Direct)
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
    }
}
