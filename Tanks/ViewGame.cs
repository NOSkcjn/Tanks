using Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
        List<ViewShot> viewShotsList = new List<ViewShot>();

        private Bitmap _bitmap;
        private Graphics graphic;
        private PictureBox gameMap;
        private List<GameObject> gameObjList;

        internal static int GameObjSize;

        public event Action OnGameOverScreenShowed;

        public ViewGame(PictureBox map, List<GameObject> gameObjList, int gameObjSize)
        {
            GameObjSize = gameObjSize;
            _bitmap = new Bitmap(map.Width, map.Height);
            graphic = Graphics.FromImage(_bitmap);
            this.gameObjList = gameObjList;
            foreach (var obj in gameObjList)
            {
                if (obj is Kolobok)
                {
                    viewKolobok = new ViewKolobok(obj);
                }
                else if (obj is Tank)
                {
                    viewTanksList.Add(new ViewTank(obj));
                }
                else if (obj is Apple)
                {
                    viewApplesList.Add(new ViewApple(obj));
                }
                else if (obj is Wall)
                {
                    viewWallList.Add(new ViewWall(obj));
                }
            }
            gameMap = map;
        }

        public void SetMap()
        { 
}

        private void ClearMap()
        {
            graphic.Clear(gameMap.BackColor);
        }

        public void Refresh()
        {
            ClearMap();
            viewKolobok.Draw(this);
            foreach (var tank in viewTanksList)
            {
                tank.Draw(this);
            }
            foreach (var apple in viewApplesList)
            {
                apple.Draw(this);
            }
            foreach (var wall in viewWallList)
            {
                wall.Draw(this);
            }
            for(int i=0; i < viewShotsList.Count; i++)
            {
                bool exist = false;
                foreach(var obj in gameObjList)
                {
                    if (obj == viewShotsList[i].Model)
                    {
                        viewShotsList[i].Draw(this);
                        exist = true;
                        break;
                    }
                }
                if(!exist) viewShotsList.Remove(viewShotsList[i]);
            }
            gameMap.Image = _bitmap;
        }

        public void AddShot(ViewShot shot)
        {
            viewShotsList.Add(shot);
        }

        public void SetDraw(Image image, int x, int y, int width, int height)
        {
            graphic.DrawImage(image, x, y, width, height);
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
