using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlappyBird
{
    public class Player
    {
        public PictureBox pb;
        public bool falling = true;

        public Form1 instance;
        
        public Player(Form1 i)
        {

            instance = i;
            
            falling = true;
            pb = new PictureBox()
            {
                Width = 50,
                Height = 50,
                Location = new Point(0, 0),
                BackgroundImage = Properties.Resources.stepis_3,
                BackgroundImageLayout = ImageLayout.Stretch,
                BackColor = Color.Transparent
            };
            if (instance.InvokeRequired)
            {
                instance.Invoke(() => instance.Controls.Add(pb));
            }
            else
            {
                instance.Controls.Add(pb);
            }
        }

        public void setY(int y)
        {
            if (pb.InvokeRequired)
            {
                pb.Invoke(() => pb.Location = new Point(pb.Location.X, y));
            }
            else
            {
                pb.Location = new Point(pb.Location.X, y);
            }

        }

        public void Jump()
        {
            new Thread(() =>
            {
                for (int i = 0; i < 20; i++)
                {
                    setY(pb.Location.Y - 3);
                    falling = false;
                    Console.WriteLine(pb.Location.Y);
                    Thread.Sleep(5);
                }
                falling = true;
            }).Start();
        }
    }
}
