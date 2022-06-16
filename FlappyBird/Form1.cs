namespace FlappyBird
{
    public partial class Form1 : Form
    {
        public static Form instance;

        public static Thread update;
        public Form1()
        {
            instance = this;
            InitializeComponent();
            Obstacle ob = new Obstacle();
            Player p = new Player();
            

            new Thread(x => Update()).Start();
        }
        
        public static void Update()
        {
            int i = 0;
            while (true)
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

                if (i == 150)
                {
                    new Obstacle();
                    i = 0;
                }

                i++;

                Thread.Sleep(60);
            }
        }

        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == ' ')
            {
                
            }
        }
    }
}