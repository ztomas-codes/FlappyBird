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

        public Obstacle()
        {

            list.Add(this);

            double percent = (new Random().Next(4, 9) * 10) / (double)100;


            pbs.Add(new PictureBox()
            {
                Width = 100,
                Height = (int)(Form1.instance.Height * (percent - 0.3)),
                Location = new Point(0, 0),
                BackColor = Color.Green
            });

            pbs.Add(new PictureBox()
            {
                Width = 100,
                Height = (int)(Form1.instance.Height * (1 - percent)),
                Location = new Point(0, Form1.instance.Height - (int)(Form1.instance.Height * (1 - percent))),
                BackColor = Color.Green
            });


            pbs.ForEach(x =>
            {
                if (Form1.instance.InvokeRequired)
                {
                    Form1.instance.Invoke(() => Form1.instance.Controls.Add(x));
                }
                else
                {
                    Form1.instance.Controls.Add(x);
                }

            });

            setX(Form1.instance.Width);
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
            if (Form1.instance.InvokeRequired)
            {
                Form1.instance.Invoke(() =>
                {
                    pbs.ForEach(x =>
                    {
                        Form1.instance.Controls.Remove(x);
                        list.Remove(this);
                    });
                });
            }
            else
            {
                pbs.ForEach(x =>
                {
                    Form1.instance.Controls.Remove(x);
                    list.Remove(this);
                });
            }
        }
        

    }
}
