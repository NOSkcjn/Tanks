using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
//using View;
using System.Drawing;
using System.Windows.Forms;
using System.ComponentModel;

namespace Presenter
{
    public class PackmanController
    {
        public static int MAP_WIDTH;
        public static int MAP_HEIGHT;

        public const int GAMEOBJ_SIZE = 35;

        public Game Game;

        public event Action OnRefresh;
        public event Action OnGameOver;

        public List<GameObject> GameObjList;

        public Timer GameUpdateTimer;

        public PackmanController(int mapWidth, int mapHeight, int tanks, int apples, int interval)
        {
            GameUpdateTimer = new Timer();
            GameUpdateTimer.Interval = interval;
            Game.MAP_WIDTH = MAP_WIDTH = mapWidth;
            Game.MAP_HEIGHT = MAP_HEIGHT = mapHeight;
            Game = new Game(GAMEOBJ_SIZE, tanks, apples, interval);
            //mainForm.Start();
            //game.StartGame();
            this.GameObjList = Game.GameObjList;
        }
        

        public void Tick(object sender, EventArgs e)
        {
            Game.Update();
        }

        private void Subscribe()
        {
            Game.OnGameUpdate += Refresh;
            Game.OnGameOver += GameOver;
            Shot.OnShoot += Shoot;
            GameUpdateTimer.Tick += Tick;
        }

        private void UnSubscribe()
        {
            Game.OnGameUpdate -= Refresh;
            Game.OnGameOver -= GameOver;
            Shot.OnShoot -= Shoot;
            GameUpdateTimer.Tick -= Tick;
        }

        private void Shoot(Shot shot)
        {
            Game.shotsList.Add(shot);
            Game.GameObjList.Add(shot);
        }

        private void Refresh()
        {
            OnRefresh?.Invoke();
        }

        private void GameOver()
        {
            GameUpdateTimer.Stop();
            UnSubscribe();
            OnGameOver?.Invoke();
        }

        public void NewGame()
        {
            Subscribe();
            GameUpdateTimer.Start();
            Game.NewGame();
        }
    }
}
