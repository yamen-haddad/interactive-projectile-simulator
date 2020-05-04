using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OpenTK;
using OpenTK.Graphics.OpenGL;
using OpenTK.Graphics;
using System.Timers;

namespace MainForm
{
    public partial class Form1 : Form
    {
        //the diameter of the ball
        static double diameter = 4;
        static double centerX = 4,centerY=4;
        //the width and height of the world coordinates in meter(please make the screen square for optimum results(for the velocity vectors only))
        static double width = 100, height = 100;
        //this flag identify if the projectile is fired or not
        static bool launched = false;
        //to store the values of the translation and the parameters of the experiment
        static double theta, v0;
        static double xt=0, yt=0;
        static double timeStep=0.05;//the time step in seconds
        static double t=0.0;//the time variable
        static double x0 = 0, y0 = 0;//the initial coordinates of the projectile
        static double g = 10; //the acceleration of the gravity
        static double maxHeight = 0;
        static double topTime = 0,landingTime=0;
        static double horizontalDistance = 0.0;
        static double delta = 0;
        //the two velocity component (vx is constant and vy0 is the initial vy velocity)
        static double vx, vy,vy0;
        //to make the projectile in the real time we need this timer
        System.Timers.Timer aTimer;
        //the number of circles in the projectile
        int numOfCircles = 26;
        static double smallCircleDiameter = 0.6;
        //the width and height of the spear
        double spearWidth = 0.5, spearHeight = 0.02;
        //the number of lines on each axe
        int axeLines = 10;
        //to hold the id of the plane image
        static int imageId;
        //to hold the coordinates of the image
        static double imagew = 0.2, imageh = 0.2;
        //the two coordinates of the airplane picture
        static Random rand = new Random();
        //this calulation to keep the image inside the coordinates axes
        static double xAxeDistance = ((centerX) / width) * 2;
        static double yAxeDistance = ((centerY) / height) * 2;
        double airplaneX = (rand.NextDouble() * (2 - 2*imagew)) - (1 - xAxeDistance-imagew);
        double airplaneY = (rand.NextDouble() * (2 - 2*imageh)) - (1 - yAxeDistance-imageh);
        //to hold the value of hitiing the plane or nto
        bool hit = false;
        //private void translateCoordinate(double wx,double wy,double out vx,double out vy )
        //{
        //vx=(wx/width)*2-1;
        //vy=(wy/height)*2-1;
        //}

        //this function is used to determine if the ball hit the airoplane or not
        bool twocubeinterscet(double firx, double firy, double firw, double firh, double secx, double secy, double secw, double sech)
        {
            if (verticalalintersect(firy, firh, secy, sech) && horizontalintersect(firx, firw, secx, secw))
            {
                return true;
            }
            return false;
        }
        bool horizontalintersect(double firx, double firw, double secx, double secw)
        {
            if ((firx >= secx && firx <= secx + secw) || (firx + firw >= secx && firx + firw <= secx + secw))
            {
                return true;
            }
            return false;
        }
        bool verticalalintersect(double firy, double firh, double secy, double sech)
        {
            if ((firy <= secy && firy >= secy - sech) || (firy - firh <= secy && firy - firh >= secy - sech))
            {
                return true;
            }
            return false;
        }


        //this function will set the timer according to the timestep variable
        private  void SetTimer()
        {
            // Create a timer with a timestep interval.
            aTimer = new System.Timers.Timer(timeStep * 1000);
            // Hook up the Elapsed event for the timer. 
            aTimer.Elapsed += OnTimedEvent;
            aTimer.AutoReset = true;
            aTimer.Enabled = true;
        }
        //what will happen when the timer finishes counting
        private  void OnTimedEvent(Object source, ElapsedEventArgs e)
        {
            glControl1.Invalidate();
        }
        public Form1()
        {
            InitializeComponent();
        }



        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            degreeLabel.Text = angleTrackBar.Value.ToString() + " Degrees";
        }

        private void velocityTrackBar_Scroll(object sender, EventArgs e)
        {
            msLabel.Text = velocityTrackBar.Value.ToString() + " M/S";
        }

        private void glControl1_Load(object sender, EventArgs e)
        {
            GL.ClearColor(Color.LightGreen);
            GL.Enable(EnableCap.Texture2D);
        }

        private void startButton_Click(object sender, EventArgs e)
        {
            theta = angleTrackBar.Value;
            //theta = double.Parse(angleTextBox.Text);
            //tranfer theta from degree to radian
            theta = Math.PI*theta / 180;
            v0 = velocityTrackBar.Value;
            //v0 = double.Parse(velocityTextBox.Text);
            vx = v0 * Math.Cos(theta);
            vy0 = v0 * Math.Sin(theta);
            delta = v0 * v0 * Math.Sin(theta) * Math.Sin(theta) + 2 * g * y0;
            landingTime =(v0*Math.Sin(theta)+Math.Sqrt(delta))/g;
            topTime = v0 * Math.Sin(theta) / g;
            maxHeight = -((0.5) * (g * Math.Pow(topTime, 2))) + v0 * Math.Sin(theta) * topTime + y0;
            horizontalDistance = v0 * Math.Cos(theta) * landingTime + x0;
            t = 0;//st the time to zero(start of launching)
            totalTimeLabel.Text = "Total Time: " + landingTime;
            maxHeightLabel.Text ="Max Height: " + maxHeight;
            horizontalDistanceLabel.Text = "Horizontal Distance: " +horizontalDistance;
            launched = true;
            hit = false;
            SetTimer();
        }

        private void glControl1_Paint(object sender, PaintEventArgs e)
        {
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);
            GL.LoadIdentity();
            imageId = Utilities.LoadTexture(@"F:\study\4th year\hurry\3rd semester\graphics\practical\third homework\MainForm\MainForm\airplane.PNG");
            //if the projectile is launched then calculate the xt and yt to make the translation(the mouvment)
            if (launched)
            {
                if (t >= landingTime)//if the projectile reach the ground then stop
                {
                    launched = false;
                    aTimer.Enabled = false; //stop the timer to stop calling the invalidate important to improve
                                            //cpu performance if we comment this line we will not notice any difference in the output
                                            //but a huge difference in performance(see the task manager photoes with both cases for more details)
                    if (!hit)//if the ball landed but still didnt hit the airplane then you lose the game
                    {
                        resultLabel.ForeColor = Color.Red;
                        resultLabel.Text = "missed the plane";
                        resultLabel.Visible = true;
                        hit = false;
                    }
                }
                else
                {
                    t += timeStep;
                    xt =(v0 * Math.Cos(theta) * t) + x0;
                    yt = -(0.5 * (g * t * t)) + (v0 * Math.Sin(theta) * t) + y0;
                    vy = vy0 - g * t;
                    spearWidth = Math.Sqrt((vx * vx) + (vy * vy));
                }
            }
            double cx = ((centerX+xt) / width) * 2 - 1;
            double cy = ((centerY+yt) / height) * 2 - 1;
            double r = (diameter / height) * 2;
            spearWidth = (spearWidth / height) * 2;
            double vxSpearWidth= (vx / width) * 2;
            double vySpearWidth = (vy / height) * 2;
            //drawCircle(cx, cy, r);
            if(!hit)
                drawAirplane(airplaneX, airplaneY);
            if (twocubeinterscet(cx - r, cy + r, 2 * r, 2 * r, airplaneX, airplaneY, imagew,imageh))
            {
                resultLabel.ForeColor = Color.Green;
                resultLabel.Text = "Hit the plane";
                resultLabel.Visible = true;
                hit = true;
            }
            if (projectileCheckBox.Checked)
                drawProjectile(numOfCircles);
            double m = (180.0 / Math.PI) * Math.Atan(vy/vx);
            if(velocityCheckBox.Checked)
                drawSpear(cx, cy, spearWidth, spearHeight, m);
            if(vxCheckBox.Checked)
                drawSpear(cx, cy, vxSpearWidth, spearHeight, 0);
            if(vyCheckBox.Checked)
                drawSpear(cx, cy, vySpearWidth, spearHeight, 90);
            GL.LoadIdentity();
            drawAxes();
            drawCircle(cx, cy, r);
            glControl1.SwapBuffers();
        }
        void drawProjectile(int numOfCircles)
        {
            double timeRange = landingTime / (double)numOfCircles;
            bool peak = false;
            int circleNum=0;
            for (double timeSlice = 0; timeSlice < landingTime; timeSlice+=timeRange)
            {
                if (circleNum == numOfCircles / 2)
                    peak = true;
                else
                    peak = false;
                double xt = (v0 * Math.Cos(theta) * timeSlice) + x0;
                double yt = -(0.5 * (g * timeSlice * timeSlice)) + (v0 * Math.Sin(theta) * timeSlice) + y0;
                double cx = ((centerX + xt) / width) * 2 - 1;
                double cy = ((centerY + yt) / height) * 2 - 1;
                double r = (smallCircleDiameter / height) * 2;
                drawSmallCircle(cx, cy, r, peak);
                circleNum++;
            }
        }
        public void drawCircle(double centerX,double centerY,double r)
        {
            GL.Begin(BeginMode.TriangleFan);
            int n = 100;
            double R = r;
            double cx = centerX, cy = centerY;
            double xs = cx + R, ys = cy, xe, ye;
            GL.Color3(1.0, 1.0, 1.0);
            GL.Vertex3(cx, cy, 0);
            double theta = 0;
            double step = 2 * Math.PI / n;
            for (double i = 1; i <= n; i += step)
            {
                theta = 2 * Math.PI / i;
                xs = cx + R * Math.Cos(theta);
                ys = cy + R * Math.Sin(theta);
                GL.Color3(1.0, 0.0, 0.0);
                GL.Vertex3(xs, ys, 0);
            }
            GL.Color3(1.0, 0.0, 0.0);
            GL.Vertex3(cx + R, cy, 0);
            GL.End();
        }
        public void drawSmallCircle(double centerX, double centerY, double r,bool peak)//the peak variable to make the peak with different color
        {
            Color circleColor = Color.White;
            if (peak)//color the circle with red
                circleColor = Color.Red;
            GL.Begin(BeginMode.TriangleFan);
            int n = 20;
            double R = r;
            double cx = centerX, cy = centerY;
            double xs = cx + R, ys = cy, xe, ye;
            GL.Color3(circleColor);
            GL.Vertex3(cx, cy, 0);
            double theta = 0;
            double step = 2 * Math.PI / n;
            for (double i = 1; i <= n; i += step)
            {
                theta = 2 * Math.PI / i;
                xs = cx + R * Math.Cos(theta);
                ys = cy + R * Math.Sin(theta);
                GL.Color3(circleColor);
                GL.Vertex3(xs, ys, 0);
            }
            GL.Color3(circleColor);
            GL.Vertex3(cx + R, cy, 0);
            GL.End();
        }
        public void drawSpear(double cx, double cy, double w,double height,double degree)
        {
            GL.LoadIdentity();
            GL.Translate(cx, cy, 0);
            GL.Rotate((float)degree, Vector3.UnitZ);
            drawRect(0, 0, w, height,Color.Blue);
        }
        public void drawRect(double cx, double cy, double w, double h,Color c)
        {
            GL.Begin(BeginMode.Quads);
            GL.Color3(c);
            GL.Vertex3(cx, cy, 0);
            GL.Color3(c);
            GL.Vertex3(cx + w, cy, 0);
            GL.Color3(c);
            GL.Vertex3(cx + w, cy + h, 0);
            GL.Color3(c);
            GL.Vertex3(cx, cy + h, 0);
            GL.End();
        }
        void drawAxes()
        {
            double oneLineWidth = 0.01, oneLineHeight = 0.05;
            double axecx = ((centerX ) / width) * 2 - 1;
            double axecy = ((centerY ) / height) * 2 - 1;
            drawRect(axecx,axecy,width,0.01,Color.Black);
            drawRect(axecx, axecy, 0.01, height, Color.Black);
            for (int i = 0; i < axeLines; i++)
            {
                double cx = (((centerX) + (i * (width / axeLines))) / width) * 2 - 1;
                double cy = (((centerY) + (i * (height / axeLines))) / height) * 2 - 1;
                drawRect(cx, axecy, oneLineWidth, oneLineHeight, Color.Black);
                drawRect(axecx, cy, oneLineHeight, oneLineWidth, Color.Black);
            }
        }
        void drawAirplane(double airplaneX, double airplaneY)
        {
            double imagex = airplaneX;
            double imagey = airplaneY;
            //Airplane
            GL.Color3(Color.White);
            GL.BindTexture(TextureTarget.Texture2D, imageId);
            GL.LoadIdentity();
            GL.Begin(BeginMode.Quads);
            GL.TexCoord2(0, 0);
            GL.Vertex3(imagex, imagey, 0);
            GL.TexCoord2(1, 0);
            GL.Vertex3(imagex + imagew, imagey, 0);
            GL.TexCoord2(1, 1);
            GL.Vertex3(imagex + imagew, imagey - imageh, 0);
            GL.TexCoord2(0, 1);
            GL.Vertex3(imagex, imagey - imageh, 0);
            GL.End();
        }
    }
}
