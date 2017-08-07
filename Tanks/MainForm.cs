using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using View.Properties;

namespace View
{
    public partial class MainForm : Form
    {
        public event Action<Model.Direction> OnKeyControlDown;
        public event Action OnNewGameKeyPressed;

        public PictureBox Map
        {
            get
            {
                return pictureBoxGame;
            }
            set
            {
                pictureBoxGame = value;
            }
        }

        public MainForm()
        {
            InitializeComponent();
        }

        public void Start()
        {
            Application.Run(this);
        }

        public void PositionChanged()
        {
            
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            buttonNewGame.Visible = false;
        }

        private void MainForm_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Up:
                    OnKeyControlDown?.Invoke(Model.Direction.NORTH);
                    break;
                case Keys.Down:
                    OnKeyControlDown?.Invoke(Model.Direction.SOUTH);
                    break;
                case Keys.Left:
                    OnKeyControlDown?.Invoke(Model.Direction.WEST);
                    break;
                case Keys.Right:
                    OnKeyControlDown?.Invoke(Model.Direction.EAST);
                    break;
            }
        }

        public void NewGameKeyShow()
        {
            buttonNewGame.Visible = true;
        }

        private void buttonNewGame_Click(object sender, EventArgs e)
        {
            buttonNewGame.Visible = false;
            OnNewGameKeyPressed?.Invoke();
        }
    }
}
