namespace FlappyBird
{
    public partial class Form1 : Form
    {
        public static Form instance;

        public static Player player;

        public static Thread update;

        public static bool turnedon;
        public Form1()
        {
            instance = this;
            InitializeComponent();
            player = new Player();
            
            update = new Thread(x => Update());
            update.Start();

            Start();

        }


        public static void Start()
        {
            turnedon = true;
            Obstacle ob = new Obstacle();
            ob.setX(500);

            if (Form1.instance.InvokeRequired)
                Form1.instance.Invoke(() => Form1.instance.Visible = true);
            else Form1.instance.Visible = true;

        }


        public static void Stop()
        {
            new EndWindow().Show();

            turnedon = false;

            Obstacle.list.ToList().ForEach(x =>
            {
                x.Delete();
            });

            if (Form1.instance.InvokeRequired)
                Form1.instance.Invoke(() => Form1.instance.Visible = false);
            else Form1.instance.Visible = false;


        }
        
        public static void Update()
        {
            int i = 0;
            while (turnedon)
            {
                
                Obstacle.list.ToList().ForEach(x => {

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

                if (player.pb.Location.Y > Form1.instance.Height - 100) { Stop(); }

                Thread.Sleep(20);
            }
        }

        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == ' ')
            {
                player.Jump();
                Console.WriteLine("jump");
            }
        }
    }
}