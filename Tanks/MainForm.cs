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

        List<GameObject> ViewObjectsList;
        Timer updateListTimer;

        bool initialValuesEntered = false;

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
            //Application.Idle += Tick;
            //game.StartGame();
        }

        /*public void Start(Game game)
        {
            game.StartGame();
        }*/

        public void UpdateViewObjectsList(object sender, EventArgs e)
        {
            dataGridViewGameObjects.DataSource = null;
            ViewObjectsList.Clear();
            foreach (var obj in controller.GameObjList)
            {
                ViewObjectsList.Add(obj);
            }
            dataGridViewGameObjects.DataSource = ViewObjectsList;
            //dataGridView1.Refresh();
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

        private void ControlsShowHide(bool show)
        {
            labelWidth.Visible = show;
            numericUpDownWidth.Visible = show;

            labelHeight.Visible = show;
            numericUpDownHeight.Visible = show;

            labelTanks.Visible = show;
            numericUpDownTanks.Visible = show;

            labelApples.Visible = show;
            numericUpDownApples.Visible = show;

            labelSpeed.Visible = show;
            numericUpDownDelay.Visible = show;
        }

        private void EnterInitialValues()
        {
            ViewObjectsList = new List<GameObject>();
            updateListTimer = new Timer();
            updateListTimer.Interval = 5000;
            updateListTimer.Tick += UpdateViewObjectsList;
            updateListTimer.Start();

            Map.Width = (int)numericUpDownWidth.Value;
            Map.Height = (int)numericUpDownHeight.Value;
            //controller.SetMapSize(Map.Width, Map.Height);
            //viewGame.SetMap(Map);

            controller = new PackmanController(Map.Width, Map.Height,
                (int)numericUpDownTanks.Value, (int)numericUpDownApples.Value, (int)numericUpDownDelay.Value);

            viewGame = new ViewGame(Map, controller.GameObjList, PackmanController.GAMEOBJ_SIZE);
            dataGridViewGameObjects.DataSource = ViewObjectsList;
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
        }

        private void buttonNewGame_Click(object sender, EventArgs e)
        {
            buttonNewGame.Visible = false;
            if (!initialValuesEntered)
            {
                EnterInitialValues();
                ControlsShowHide(false);
                initialValuesEntered = true;
            }
            this.Hide();
            this.Show();
            //Application.Idle += Tick;
            OnNewGameKeyPressed?.Invoke();
        }
    }
}
