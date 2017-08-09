using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.ComponentModel;

namespace Model
{
    public class Game
    {
        List<Tank> tanksList = new List<Tank>();
        List<Apple> applesList = new List<Apple>();
        List<Wall> wallsList = new List<Wall>();
        public List<Shot> shotsList = new List<Shot>();

        public BindingList<GameObject> gameObjList = new BindingList<GameObject>();

        public delegate void Action();

        public event Action OnGameUpdate;
        public event Action OnGameOver;

        Kolobok kolobok;

        public static int MAP_HEIGHT;
        public static int MAP_WIDTH;

        internal static int GameObjSize;

        private object objThread = new object();

        public Game(int width, int height, int gameObjSize)
        {
            MAP_HEIGHT = height;
            MAP_WIDTH = width;
            GameObjSize = gameObjSize;

            //создаем колобка
            kolobok = new Kolobok() { Direct = Direction.WEST, NewDirect = Direction.WEST, X = 200 };
            gameObjList.Add(kolobok);

            //создаем танки
            tanksList.Add(new Tank() /*{ X = 55, Y = 29, Direct = Direction.NORTH }*/);
            tanksList.Add(new Tank() /*{ X = 88, Y = 44, Direct = Direction.NORTH, NewDirect = Direction.SOUTH }*/);
            foreach (var tank in tanksList)
            {
                gameObjList.Add(tank);
            }

            //создаем яблоки
            applesList.Add(new Apple() { X = 100, Y = 100 });
            applesList.Add(new Apple() { X = 200, Y = 120 });
            foreach (var apple in applesList)
            {
                gameObjList.Add(apple);
            }

            //создаем стены
            wallsList.Add(new Wall() { X = 150, Y = 230 });
            wallsList.Add(new Wall() { X = 150, Y = 260 });
            foreach (var wall in wallsList)
            {
                gameObjList.Add(wall);
            }
            Shot.OnShotDelete += DeleteShot;
            //Update();
        }

        /*public void StartGame()
        {
            long timeRate = 50;
            long timeNext = DateTime.Now.Millisecond;
            while (true)
            {
                long timeNow = DateTime.Now.Millisecond;
                if (timeNow >= timeNext) break;
                timeNext = timeNow + timeRate;
            }
            Update();
        }*/

        //long timeNext = DateTime.Now.Ticks;

        public void Update()
        {
            //long timeRate = TimeSpan.TicksPerMillisecond;

            if (!kolobok.dead)
            {
                //await Task.Delay(5);
                //long timeNow = DateTime.Now.Ticks;
                //if (timeNow < timeNext) return;

                //timeNext = timeNow + timeRate;
                kolobok.Move();
                Random rand = new Random();
                foreach (var tank in tanksList)
                {
                    tank.Updates++;
                    tank.Move();
                    if (tank.Updates > 300 * (rand.Next(1, 5)))
                    {
                        if (tank.CheckObjectCollides(kolobok, 200))
                        {
                            tank.Shoot();
                        }
                        else
                        {
                            tank.SetRandomDirection();
                        }
                        tank.Updates = 0;
                    }
                }
                foreach (var shot in shotsList)
                {
                    shot.Move();
                }
                OnGameUpdate?.Invoke();
                CheckCollides();
            }
        }

        public void GameOver()
        {
            kolobok.dead = true;
            for (int i = 0; i < shotsList.Count; i++)
            {
                gameObjList.Remove(shotsList[i]);
            }
            shotsList.Clear();
            OnGameOver?.Invoke();
        }

        public void CheckCollides()
        {
            for (int i = 0; i < gameObjList.Count; i++)
            {
                if (gameObjList[i] is Tank)
                {
                    if (gameObjList[i].CheckObjectCollides(kolobok))
                    {
                        GameOver();
                    }
                    else
                    {
                        foreach (var tank in tanksList)
                        {
                            if (gameObjList[i].CheckObjectCollides(tank) && tank.ClashCheck((Tank)gameObjList[i]))
                            {
                                tank.TurnAround();
                                ((Tank)gameObjList[i]).TurnAround();
                                break;
                            }
                        }
                    }
                }
                else if (gameObjList[i] is Apple)
                {
                    if (gameObjList[i].CheckObjectCollides(kolobok))
                    {
                        kolobok.Score++;
                        gameObjList[i].SetRandomPos(gameObjList);
                    }
                }
                else if (gameObjList[i] is Wall)
                {
                    if (gameObjList[i].CheckObjectCollides(kolobok))
                    {
                        kolobok.TurnAround();
                    }
                    else
                    {
                        foreach (var tank in tanksList)
                        {
                            if (gameObjList[i].CheckObjectCollides(tank))
                            {
                                tank.TurnAround();
                                break;
                            }
                        }
                    }
                }
                else if (gameObjList[i] is Shot)
                {
                    foreach (var objDestroyer in gameObjList)
                    {
                        if (gameObjList[i].CheckObjectCollides(objDestroyer, 25) &&
                            !(objDestroyer is Shot) && !(objDestroyer is Apple))
                        {
                            DeleteShot((Shot)gameObjList[i]);
                            //shotsList.Remove((Shot)gameObjList[i]);
                            //gameObjList[i] = null;
                            if (objDestroyer is Kolobok)
                            {
                                GameOver();
                            }
                            else if (objDestroyer is Tank)
                            {
                                objDestroyer.SetRandomPos(gameObjList);
                                ((Tank)objDestroyer).SetRandomDirection();
                                kolobok.Score++;
                            }
                            break;
                        }
                    }
                }
            }
        }

        public void DeleteShot(Shot shot)
        {
            gameObjList.Remove(shot);
        }

        public void NewGame()
        {
            kolobok.dead = false;
            kolobok.Score = 0;
            kolobok.X = 0;
            kolobok.Y = 0;
            foreach (var tank in tanksList)
            {
                tank.SetRandomPos(gameObjList);
                tank.SetRandomDirection();
            }
            //Update();
        }
    }
}
