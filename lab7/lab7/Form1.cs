using System.Windows.Forms.VisualStyles;

namespace lab7
{
    public partial class Form1 : Form
    {
        bool Functioning = false;
        Graphics graph;
        public Form1()
        {
            InitializeComponent();
            graph = CreateGraphics();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            button1_Click(sender, e);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Functioning = true;
            graph = CreateGraphics();
            graph.Clear(BackColor);
            float Scale(float lower, float upper, float a)
            {
                /*
                 *Explanation:
                 *  In order to make the graph scale up depending on the size of the form,
                 *  I had to solve these problems:
                 *      1- Turn the resuts a into a coeficient.
                 *      2- Then multiply it with the either the width or height of the form.
                 *  In order to solve them I:
                 *      1- Introduced variables lower and upper, to turn variable {a} into a coeficient,
                 *      using a formula, featured in a return statement.
                 *      2- Then I multiply with the width/height in the DrawLine function to get a result, scaled depending on the size of the form.
                 */
                return (a - lower) / (upper - lower);
            }
            float Function(float t)
            {
                return t * t;//(t - (float)Math.Log(2 * t)) / (3 * t + 1);
            }
            Color color = Color.FromArgb(0, 0, 0);
            float width = 4;
            Pen pen = new(color, width);
            float t, y, t1, y1, loweredget, upperedget, loweredgey, upperedgey, deltat;
            loweredget = 2.1F;
            upperedget = 10F;
            deltat = 0.7F;
            loweredgey = Function(loweredget);
            upperedgey = Function(upperedget);
            t = loweredget;
            y = Function(t);
            for (t1 = t + deltat; t1 < upperedget; t1 += deltat)
            {
                y1 = Function(t1);
                graph.DrawLine(pen, this.Width * Scale(loweredget, upperedget, t), this.Height * Scale(loweredgey, upperedgey, y)
                    , this.Width * Scale(loweredget, upperedget, t1), this.Height * Scale(loweredgey, upperedgey, y1));
                t = t1;
                y = y1;
            }
            pen.Width = 1;
            for (int i = (int)Math.Ceiling(loweredget); i < upperedget; i++)
            {
                graph.DrawLine(pen, this.Width * Scale(loweredget, upperedget, i), 0
                    , this.Width * Scale(loweredget, upperedget, i), this.Height);
                Brush textBrush = new SolidBrush(Color.Black);
                Font drawFont = new Font("Arial", 12);
                graph.DrawString(i.ToString(), drawFont, textBrush, this.Width * Scale(loweredget, upperedget, i), 5F);
            }
            for (int i = (int)Math.Ceiling(loweredgey); i < upperedgey; i++)
            {
                graph.DrawLine(pen, 0, this.Height * Scale(loweredgey, upperedgey, i)
                    , this.Width, this.Height * Scale(loweredgey, upperedgey, i));
                Brush textBrush = new SolidBrush(Color.Black);
                Font drawFont = new Font("Arial", 12);
                graph.DrawString(i.ToString(), drawFont, textBrush, 5F, this.Width * Scale(loweredgey, upperedgey, i));
            }
            /*
             *Graph of how it should approximately look:
             *       1________2, where:
             *       |        |      The graph itself shows the form
             *       |        |      1-point , that corresponds to coordinates (lower,Function(lower))
             *       |        |      2-point , that corresponds to (upper,Function(lower))
             *       |        |      3- to (lower,Function(upper))
             *       |________|      4- to (upper , Function(upper))
             *       3         4
             */
        }
    }
}