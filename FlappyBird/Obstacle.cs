using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlappyBird
{
    public class Obstacle
    {
        public static List<Obstacle> list = new List<Obstacle>();

        public int middlepoint;

        public List<PictureBox> pbs = new List<PictureBox>();

        public bool Collected = false;

        public Form1 instance;

        public Obstacle(Form1 i)
        {
            instance = i;

            list.Add(this);

            double percent = (new Random().Next(4, 9) * 10) / (double)100;


            pbs.Add(new PictureBox()
            {
                Width = 100,
                Height = (int)(instance.Height * (percent - 0.3)),
                Location = new Point(0, 0),
                BackColor = Color.DeepPink
            });

            pbs.Add(new PictureBox()
            {
                Width = 100,
                Height = (int)(instance.Height * (1 - percent)),
                Location = new Point(0, instance.Height - (int)(instance.Height * (1 - percent))),
                BackColor = Color.DeepPink









            });


            pbs.ForEach(x =>
            {
                if (instance.InvokeRequired)
                {
                    instance.Invoke(() => instance.Controls.Add(x));
                }
                else
                {
                    instance.Controls.Add(x);
                }

            });

            setX(instance.Width);
        }

        public void setX(int x) 
        {
            pbs.ForEach(pb =>
            {
                if(pb.InvokeRequired) 
                { 
                    pb.Invoke(() => pb.Location = new Point(x, pb.Location.Y));
                }
                else
                {
                    pb.Location = new Point(x, pb.Location.Y);
                }
            });
        }

        public void Delete()
        {
            if (instance.InvokeRequired)
            {
                instance.Invoke(() =>
                {
                    pbs.ForEach(x =>
                    {
                        instance.Controls.Remove(x);
                        list.Remove(this);
                    });
                });
            }
            else
            {
                pbs.ForEach(x =>
                {
                    instance.Controls.Remove(x);
                    list.Remove(this);
                });
            }
        }
        

    }
}
