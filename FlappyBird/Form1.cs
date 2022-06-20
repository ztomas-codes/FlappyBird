namespace FlappyBird
{
    public partial class Form1 : Form
    {
        public static Form instance;

        public static Player player;

        public static Thread update;

        public static Panel panel;

        public static bool turnedon;
        public Form1()
        {
            instance = this;
            InitializeComponent();
            player = new Player(this);
            panel = panel1;

            pictureBox2.Parent = pictureBox1;


            Start();

        }

        public void AddScore()
        {
            if (label1.InvokeRequired)
                label1.Invoke(() => label1.Text = (int.Parse(label1.Text) + 1).ToString());
            else
                label1.Text = (int.Parse(label1.Text) + 1).ToString();
        }


        public void Start()
        {

            turnedon = true;
            if (panel.InvokeRequired)
                panel.Invoke(() => panel.Visible = false);
            else panel.Visible = false;

            player.setY(20);
            new Obstacle(this);
            update = new Thread(() => Updates());
            update.Start();
        }


        public void Stop()
        {
            turnedon = false;
            if (panel.InvokeRequired)
                panel.Invoke(() => panel.Visible = true);
            else panel.Visible = true;

        }

        public void NewGame()
        {
            Obstacle.list.Clear();
            turnedon = false;
            FirstWindow.NewGame();
            
            this.Close();
            this.Dispose();
        }

        public void Updates()
        {
            turnedon = true;
            int i = 0;

            while (turnedon)
            {
                Obstacle.list.ToList().ForEach(x =>
                {

                    x.setX(x.pbs[0].Location.X - 2);

                });

                if (Obstacle.list.Count != 0)
                {
                    if (Obstacle.list[0].pbs[0].Location.X < -100)
                    {
                        Obstacle.list[0].Delete();

                    }
                    if (Obstacle.list[0].pbs[0].Location.X < -50 & Obstacle.list[0].Collected == false)
                    {
                        Obstacle.list[0].Collected = true;
                        AddScore();
                    }
                }
            


                if (player.falling) player.setY(player.pb.Location.Y + 6);

                if (i == 150)
                {
                    new Obstacle(this);
                    i = 0;
                }

                i++;

                if (player.pb.Location.Y > Form1.instance.Height - 100) {
                    turnedon = false;
                }

                Obstacle.list.ToList().ForEach(x =>
                {


                    x.pbs.ToList().ForEach(x =>
                    {

                        if (x.Bounds.IntersectsWith(player.pb.Bounds))
                        {
                            turnedon = false;
                        }

                    });

                });

                Thread.Sleep(20);
            }
            Stop();
        }

        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 'w' && turnedon)
            {
                player.Jump();
            }
        }


        private void pictureBox2_Click(object sender, EventArgs e)
        {
            NewGame();

        }
    }
}