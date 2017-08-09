using Model;
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
using Presenter;

namespace View
{
    public partial class MainForm : Form
    {
        public event Action<Model.Direction> OnKeyControlDown;
        public event Action OnNewGameKeyPressed;
        public event Action OnPlayerShoot;

        ViewGame viewGame;
        PackmanController controller;

        BindingList<GameObject> ViewObjectsList;
        Timer updateListTimer;

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

            ViewObjectsList = new BindingList<GameObject>();
            updateListTimer = new Timer();
            updateListTimer.Interval = 1000;
            updateListTimer.Tick += UpdateViewObjectsList;
            updateListTimer.Start();

            controller = new PackmanController();
            Map.Height = PackmanController.MAP_HEIGHT;
            Map.Width = PackmanController.MAP_WIDTH;
            //game = controller.Game;
            viewGame = new ViewGame(Map, controller.GameObjList, PackmanController.GAMEOBJ_SIZE);
            dataGridView1.DataSource = ViewObjectsList;
            controller.OnRefresh += viewGame.Refresh;
            OnKeyControlDown += ((Kolobok)viewGame.viewKolobok.Model).SetDirection;
            OnPlayerShoot += ((Kolobok)viewGame.viewKolobok.Model).Shoot;
            //((Kolobok)viewGame.viewKolobok.Model).OnShooting += ShootView;
            foreach (var obj in controller.GameObjList)
            {
                if (obj is GameFiringObject)
                {
                    ((GameFiringObject)obj).OnShooting += ShootView;
                }
            }
            controller.OnGameOver += viewGame.GameOverScreen;
            viewGame.OnGameOverScreenShowed += NewGameKeyShow;
            OnNewGameKeyPressed += controller.NewGame;
            ((Kolobok)viewGame.viewKolobok.Model).OnScoreChanged += ScoreChanged;
            //Application.Idle += Tick;
            //game.StartGame();
        }

        /*public void Start(Game game)
        {
            game.StartGame();
        }*/

        public void UpdateViewObjectsList(object sender, EventArgs e)
        {
            ViewObjectsList.Clear();
            foreach(var obj in controller.GameObjList)
            {
                ViewObjectsList.Add(obj);
            }
        }

        public void ScoreChanged()
        {
            labelScore.Text = "Score: " + ((Kolobok)viewGame.viewKolobok.Model).Score;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            //buttonNewGame.Visible = false;
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
                case Keys.Space:
                    OnPlayerShoot?.Invoke();
                    break;
            }
        }

        public void ShootView(Shot shot)
        {
            ViewShot viewShot = new ViewShot(shot);
            viewGame.AddShot(viewShot);
        }

        public void NewGameKeyShow()
        {
            buttonNewGame.Visible = true;
        }

        private void buttonNewGame_Click(object sender, EventArgs e)
        {
            buttonNewGame.Visible = false;
            this.Hide();
            this.Show();
            //Application.Idle += Tick;
            OnNewGameKeyPressed?.Invoke();
        }
    }
}
