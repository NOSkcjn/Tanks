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
        public const int MAP_WIDTH = 500;
        public const int MAP_HEIGHT = 300;

        public const int GAMEOBJ_SIZE = 35;

        public Game Game;

        public event Action OnRefresh;
        public event Action OnGameOver;

        public BindingList<GameObject> GameObjList;

        public Timer GameUpdateTimer;

        public PackmanController(int interval = 3)
        {
            GameUpdateTimer = new Timer();
            GameUpdateTimer.Interval = interval;
            Game = new Game(MAP_WIDTH, MAP_HEIGHT, GAMEOBJ_SIZE);
            //mainForm.Start();
            //game.StartGame();
            this.GameObjList = Game.gameObjList;
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
            Game.gameObjList.Add(shot);
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
