using Model;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using View.Properties;

namespace View
{
    public class ViewGame
    {
        public ViewKolobok viewKolobok;
        List<ViewTank> viewTanksList = new List<ViewTank>();
        List<ViewApple> viewApplesList = new List<ViewApple>();
        List<ViewWall> viewWallList = new List<ViewWall>();

        private Bitmap _bitmap;
        private PictureBox gameMap;
        private List<GameObject> gameObjList;

        internal static int GameObjSize;

        public event Action OnGameOverScreenShowed;

        public ViewGame(PictureBox map, List<GameObject> gameObjList, int gameObjSize)
        {
            GameObjSize = gameObjSize;
            _bitmap = new Bitmap(map.Width, map.Height);
            this.gameObjList = gameObjList;
            foreach (var obj in gameObjList)
            {
                if (obj is Kolobok)
                {
                    viewKolobok = new ViewKolobok(obj);
                }
                else if(obj is Tank)
                {
                    viewTanksList.Add(new ViewTank(obj));
                }
                else if(obj is Apple)
                {
                    viewApplesList.Add(new ViewApple(obj));
                }
                else if(obj is Wall)
                {
                    viewWallList.Add(new ViewWall(obj));
                }
            }
            gameMap = map;
        }

        private void ClearMap()
        {
            Graphics gr = Graphics.FromImage(_bitmap);
            gr.Clear(gameMap.BackColor);
        }

        public void Refresh()
        {
            lock (_bitmap)
            {
                ClearMap();
                viewKolobok.Draw(_bitmap);
                foreach (var tank in viewTanksList)
                {
                    tank.Draw(_bitmap);
                }
                foreach (var apple in viewApplesList)
                {
                    apple.Draw(_bitmap);
                }
                foreach (var wall in viewWallList)
                {
                    wall.Draw(_bitmap);
                }
                gameMap.Image = _bitmap;
            }
        }

        public void GameOverScreen()
        {
            Graphics graphic = Graphics.FromImage(_bitmap);
            SolidBrush Brush = new SolidBrush(Color.FromArgb(155, 0, 0, 0));
            graphic.FillRectangle(Brush, 0, 0, _bitmap.Width, _bitmap.Height);
            graphic.DrawImage(Resources.GAME_OVER, 0, 0, _bitmap.Width, _bitmap.Height);
            gameMap.Image = _bitmap;
            OnGameOverScreenShowed?.Invoke();
        }
    }
}
