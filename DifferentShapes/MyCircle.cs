using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SplashKitSDK;
using System.IO;

namespace DifferentShapes
{
    public class MyCircle : Shape
    {
        private int _radius; //radius field to store the radius of the circle

        //radius property, allows the user to get and set the radius
        public int Radius
        {
            get
            {
                return _radius;
            }
            set
            {
                _radius = value;
            }
        }

        //default constructor calling the other constructor and passing the color blue and radius 50
        public MyCircle() : this(Color.Blue, 50)
        {}

        //constructor with parameters
        public MyCircle(Color clr, int radius) : base (clr)
        {
            _radius = radius;
        }

        //override method to draw circles only
        public override void Draw()
        {
            if (Selected)
            {
                DrawOutline();
            }
            SplashKit.FillCircle(Color, X, Y, _radius);
        }

        //override method to draw the outline for the circle
        public override void DrawOutline()
        {
            //drawing outline with a radius bigger than the circle by 2 pixels
            SplashKit.DrawCircle(Color.Black, X, Y, _radius + 2);
        }

        public override bool IsAt(Point2D pt)
        {
            //checking if the point is at the circle
            //since for the circle, X and Y are the coordinates of the circle, then we need to cover the entier circle
            //checking if the mouse x-position is in the range [X - radius, X + radius] and if the mouse y-position is in the range [Y - radius, Y + radius]
            Circle circle = SplashKit.CircleAt(X, Y, _radius);
            if (SplashKit.PointInCircle(pt, circle))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public override void SaveTo(StreamWriter writer)
        {
            base.SaveTo(writer);
            writer.WriteLine(Radius);
        }

        public override void LoadFrom(StreamReader reader)
        {
            base.LoadFrom(reader);
            Radius = reader.ReadInteger();
        }
    }
}
