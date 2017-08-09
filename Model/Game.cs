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

        public List<GameObject> GameObjList = new List<GameObject>();

        public delegate void Action();

        public event Action OnGameUpdate;
        public event Action OnGameOver;

        Kolobok kolobok;

        public static int MAP_HEIGHT;
        public static int MAP_WIDTH;

        internal static int GameObjSize;
        private int delayTime;

        Random random = new Random();

        public Game(int gameObjSize, int tanks, int apples, int interval)
        {
            /*MAP_HEIGHT = height;
            MAP_WIDTH = width;*/
            GameObjSize = gameObjSize;
            delayTime = interval;

            //создаем колобка
            kolobok = new Kolobok() { Direct = Direction.WEST, NewDirect = Direction.WEST, X = 200 };
            GameObjList.Add(kolobok);

            //создаем танки
            for (int i = 0; i < tanks; i++)
            {
                tanksList.Add(new Tank());
            }
            GameObjList.AddRange(tanksList);

            //создаем яблоки
            for (int i = 0; i < apples; i++)
            {
                applesList.Add(new Apple());
            }
            GameObjList.AddRange(applesList);

            //создаем стены
            wallsList.Add(new Wall() { X = 158, Y = 50 });
            wallsList.Add(new Wall() { X = 124, Y = 50 });
            wallsList.Add(new Wall() { X = 90, Y = 50 });
            wallsList.Add(new Wall() { X = 90, Y = 80 });
            wallsList.Add(new Wall() { X = 90, Y = 110 });
            wallsList.Add(new Wall() { X = 90, Y = 140 });
            wallsList.Add(new Wall() { X = 90, Y = 170 });
            wallsList.Add(new Wall() { X = 90, Y = 200 });
            wallsList.Add(new Wall() { X = 290, Y = 60 });
            wallsList.Add(new Wall() { X = 324, Y = 60 });
            wallsList.Add(new Wall() { X = 358, Y = 60 });
            wallsList.Add(new Wall() { X = 324, Y = 90 });
            GameObjList.AddRange(wallsList);

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

                foreach (var tank in tanksList)
                {
                    tank.Updates++;
                    tank.Move();
                    if (tank.Updates > delayTime * 100 * (random.Next(1, 5)))
                    {
                        if (random.Next(1, 3) == 2)
                        {
                            if (tank.CheckObjectCollides(kolobok, 200))
                            {
                                tank.Shoot();
                            }
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
                GameObjList.Remove(shotsList[i]);
            }
            shotsList.Clear();
            OnGameOver?.Invoke();
        }

        public void CheckCollides()
        {
            for (int i = 0; i < GameObjList.Count; i++)
            {
                if (GameObjList[i] is Tank)
                {
                    if (GameObjList[i].CheckObjectCollides(kolobok))
                    {
                        GameOver();
                    }
                    else
                    {
                        foreach (var tank in tanksList)
                        {
                            if (GameObjList[i].CheckObjectCollides(tank) && tank.ClashCheck((Tank)GameObjList[i]))
                            {
                                tank.TurnAround();
                                ((Tank)GameObjList[i]).TurnAround();
                                break;
                            }
                        }
                    }
                }
                else if (GameObjList[i] is Apple)
                {
                    if (GameObjList[i].CheckObjectCollides(kolobok))
                    {
                        kolobok.Score++;
                        GameObjList[i].SetRandomPos(GameObjList);
                    }
                }
                else if (GameObjList[i] is Wall)
                {
                    if (GameObjList[i].CheckObjectCollides(kolobok))
                    {
                        kolobok.TurnAround();
                    }
                    else
                    {
                        foreach (var tank in tanksList)
                        {
                            if (GameObjList[i].CheckObjectCollides(tank))
                            {
                                tank.TurnAround();
                                break;
                            }
                        }
                    }
                }
                else if (GameObjList[i] is Shot)
                {
                    foreach (var objDestroyer in GameObjList)
                    {
                        if (GameObjList[i].CheckObjectCollides(objDestroyer, 25) &&
                            !(objDestroyer is Shot) && !(objDestroyer is Apple))
                        {
                            DeleteShot((Shot)GameObjList[i]);
                            //shotsList.Remove((Shot)gameObjList[i]);
                            //gameObjList[i] = null;
                            if (objDestroyer is Kolobok)
                            {
                                GameOver();
                            }
                            else if (objDestroyer is Tank)
                            {
                                objDestroyer.SetRandomPos(GameObjList);
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
            GameObjList.Remove(shot);
        }

        public void NewGame()
        {
            kolobok.dead = false;
            kolobok.Score = 0;
            kolobok.X = 0;
            kolobok.Y = 0;
            foreach (var tank in tanksList)
            {
                tank.SetRandomPos(GameObjList);
                tank.SetRandomDirection();
            }
            foreach (var apple in applesList)
            {
                apple.SetRandomPos(GameObjList);
            }
            //Update();
        }
    }
}
