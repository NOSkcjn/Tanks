using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using System.Drawing;
using System.Windows.Forms;
using View.Properties;

namespace View
{
    public class ViewGameObject: View<GameObject>
    {
        protected PictureBox picture = new PictureBox();

        public Image Image;

        public GameObject Model;

        public int PicHeight = ViewGame.GameObjSize;
        public int PicWidth = ViewGame.GameObjSize;

        public Point Pos
        {
            get
            {
                return picture.Location;
            }

            set
            {
                picture.Location = value;
            }
        }

        public ViewGameObject(GameObject model, Image img)
        {
            /*picture = new PictureBox();
            Resources.tank.SetResolution(5, 5);
            picture.Image = Resources.player;
            picture.Location = new Point(25, 39);
            picture.SizeMode = PictureBoxSizeMode.Zoom;
            picture.Size = new Size(55, 55);*/
            Image = img;
            this.Model = model;
        }

        public void Draw(Bitmap bitmap)
        {
            Graphics graphic = Graphics.FromImage(bitmap);
            if(!(Model is GameMovableObject))
                graphic.DrawImage(Image, Model.X, Model.Y, PicWidth, PicHeight);
            else
            {
                GameMovableObject obj = (GameMovableObject)Model;
                if (obj.NewDirect != obj.Direct)
                {
                    //двигался вверх или вниз и развернулся
                    if ((obj.NewDirect == Direction.NORTH && obj.Direct == Direction.SOUTH) ||
                        (obj.NewDirect == Direction.SOUTH && obj.Direct == Direction.NORTH))
                    {
                        Image.RotateFlip(RotateFlipType.Rotate180FlipX);
                    }
                    //двигался влево или вправо и развернулся
                    else if ((obj.NewDirect == Direction.EAST && obj.Direct == Direction.WEST) ||
                        (obj.NewDirect == Direction.WEST && obj.Direct == Direction.EAST))
                    {
                        Image.RotateFlip(RotateFlipType.Rotate180FlipY);
                    }
                    //двигался вправо и начал двигаться вверх
                    else if (obj.NewDirect == Direction.NORTH 
                        && (obj.Direct == Direction.EAST))
                    {
                        Image.RotateFlip(RotateFlipType.Rotate270FlipNone);
                    }
                    //двигался влево и начал двигаться вверх
                    else if (obj.NewDirect == Direction.NORTH
                        && (obj.Direct == Direction.WEST))
                    {
                        Image.RotateFlip(RotateFlipType.Rotate90FlipNone);
                    }
                    //двигался вправо и начал двигаться вниз
                    else if (obj.NewDirect == Direction.SOUTH
                        && (obj.Direct == Direction.EAST))
                    {
                        Image.RotateFlip(RotateFlipType.Rotate90FlipNone);
                    }
                    //двигался влево и начал двигаться вниз
                    else if (obj.NewDirect == Direction.SOUTH
                        && (obj.Direct == Direction.WEST))
                    {
                        Image.RotateFlip(RotateFlipType.Rotate270FlipNone);
                    }
                    //двигался вверх и начал двигаться влево
                    else if (obj.NewDirect == Direction.WEST
                        && (obj.Direct == Direction.NORTH))
                    {
                        Image.RotateFlip(RotateFlipType.Rotate270FlipNone);
                    }
                    //двигался вверх и начал двигаться вправо
                    else if (obj.NewDirect == Direction.EAST
                        && (obj.Direct == Direction.NORTH))
                    {
                        Image.RotateFlip(RotateFlipType.Rotate90FlipNone);
                    }
                    //двигался вниз и начал двигаться влево
                    else if (obj.NewDirect == Direction.WEST
                        && (obj.Direct == Direction.SOUTH))
                    {
                        Image.RotateFlip(RotateFlipType.Rotate90FlipNone);
                    }
                    //двигался вниз и начал двигаться вправо
                    else if (obj.NewDirect == Direction.EAST
                        && (obj.Direct == Direction.SOUTH))
                    {
                        Image.RotateFlip(RotateFlipType.Rotate270FlipNone);
                    }
                    obj.Direct = obj.NewDirect;
                }
                graphic.DrawImage(Image, Model.X, Model.Y, PicWidth, PicHeight);
            }
        }
    }
}
