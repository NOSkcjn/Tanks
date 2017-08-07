using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Model
{
    public class Game
    {
        List<Tank> tanksList = new List<Tank>();
        List<Apple> applesList = new List<Apple>();
        List<Wall> wallsList = new List<Wall>();

        public List<GameObject> gameObjList = new List<GameObject>();

        public delegate void Action();

        public event Action OnPosChanged;
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
            tanksList.Add(new Tank() { X = 55, Y = 29, Direct = Direction.NORTH });
            tanksList.Add(new Tank() { X = 88, Y = 44, Direct = Direction.NORTH, NewDirect = Direction.SOUTH });
            gameObjList.AddRange(tanksList);

            //создаем яблоки
            applesList.Add(new Apple() { X = 100, Y = 100 });
            applesList.Add(new Apple() { X = 200, Y = 120 });
            gameObjList.AddRange(applesList);

            //создаем стены
            wallsList.Add(new Wall() { X = 150, Y = 230 });
            wallsList.Add(new Wall() { X = 150, Y = 260 });
            gameObjList.AddRange(wallsList);

            Update();
        }

        private async void Update()
        {
            while (!kolobok.dead)
            {
                await Task.Delay(5);
                lock (objThread)
                {
                    kolobok.Move();
                    foreach (var obj in tanksList)
                    {
                        obj.Move();
                    }
                    OnPosChanged?.Invoke();
                    CheckCollides();
                }
            }
        }

        public void GameOver()
        {
            kolobok.dead = true;
            OnGameOver?.Invoke();
        }

        public void CheckCollides()
        {
            foreach(var obj in gameObjList)
            {
                if (obj is Tank)
                {
                    if (obj.CheckObjectCollides(kolobok))
                    {
                        GameOver();
                    }
                }
                else if (obj is Apple)
                {
                    if (obj.CheckObjectCollides(kolobok))
                    {
                        kolobok.score++;
                        obj.SetRandomPos();
                    }
                }
                else if (obj is Wall)
                {
                    if (obj.CheckObjectCollides(kolobok))
                    {
                        kolobok.TurnAround();
                    }
                    else
                    {
                        foreach(var tank in tanksList)
                        {
                            if(obj.CheckObjectCollides(tank))
                            {
                                tank.TurnAround();
                                break;
                            }
                        }
                    }
                }
            }
        }

        public void NewGame()
        {
            kolobok.dead = false;
            kolobok.score = 0;
            kolobok.X = 0;
            kolobok.Y = 0;
            Update();
        }
    }
}
