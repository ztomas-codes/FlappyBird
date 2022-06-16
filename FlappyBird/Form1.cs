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
            player = new Player();
            panel = panel1;


            Start();

        }


        public static void Start()
        {


            Console.WriteLine("started");

            if (panel.InvokeRequired)
                panel.Invoke(() => panel.Visible = false);
            else panel.Visible = false;

            player.setY(20);

            if (update != null) update.Interrupt();
            update = new Thread(x => Updates());
            update.Start();
        }


        public static void Stop()
        {
            turnedon = false;
            if (panel.InvokeRequired)
                panel.Invoke(() => panel.Visible = true);
            else panel.Visible = true;

        }
        
        public static void Updates()
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
                }

                if (player.falling) player.setY(player.pb.Location.Y + 8);

                if (i == 150)
                {
                    new Obstacle();
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
            if (e.KeyChar == 'w')
            {
                player.Jump();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Start();
        }

    }
}