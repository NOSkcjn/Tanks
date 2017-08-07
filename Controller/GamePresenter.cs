using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using View;
using System.Drawing;

namespace Presenter
{
    public class GamePresenter
    {
        public const int MAP_WIDTH = 500;
        public const int MAP_HEIGHT = 300;

        public const int GAMEOBJ_SIZE = 35;

        Game game = new Game(MAP_WIDTH, MAP_HEIGHT, GAMEOBJ_SIZE);

        ViewGame viewGame;
        MainForm mainForm;

        public GamePresenter()
        {
            mainForm = new MainForm();
            mainForm.Map.Height = MAP_HEIGHT;
            mainForm.Map.Width = MAP_WIDTH;
            viewGame = new ViewGame(mainForm.Map, game.gameObjList, GAMEOBJ_SIZE);
            game.OnPosChanged += Refresh;
            mainForm.OnKeyControlDown += ((Kolobok)viewGame.viewKolobok.Model).SetDirection;
            game.OnGameOver += viewGame.GameOverScreen;
            viewGame.OnGameOverScreenShowed += mainForm.NewGameKeyShow;
            mainForm.OnNewGameKeyPressed += game.NewGame;
            mainForm.Start();
        }

        private void Refresh()
        {
            viewGame.Refresh();
        }
    }
}
