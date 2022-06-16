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
        public Player()
        {
            pb = new PictureBox()
            {
                Width = 50,
                Height = 50,
                Location = new Point(0, 0),
                BackColor = Color.Yellow
            };
            if (Form1.instance.InvokeRequired)
            {
                Form1.instance.Invoke(() => Form1.instance.Controls.Add(pb));
            }
            else
            {
                Form1.instance.Controls.Add(pb);
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
                for (int i = 0; i < 10; i++)
                {
                    setY(pb.Location.Y - 6);
                    falling = false;
                    Thread.Sleep(10);
                }
                falling = true;
            }).Start();
        }
    }
}
