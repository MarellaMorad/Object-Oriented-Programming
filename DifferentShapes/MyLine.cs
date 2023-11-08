using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SplashKitSDK;
using System.IO;

namespace DifferentShapes
{
    public class MyLine : Shape
    {
        private float _endX;
        private float _endY;

        //default constructor
        public MyLine() : this(Color.Red, 0, 0, 100, 100)
        {}

        //constructor that takes in parameters
        public MyLine(Color clr, float starX, float starY, float endX, float endY) : base (clr)
        {
            X = starX;
            Y = starY;
            EndX = endX;
            EndY = endY;
        }

        //EndX property
        public float EndX
        {
            get
            {
                return _endX;
            }
            set
            {
                _endX = value;
            }
        }

        //EndY property
        public float EndY
        {
            get
            {
                return _endY;
            }
            set
            {
                _endY = value;
            }
        }

        //override draw method to draw lines
        public override void Draw()
        {
            if(Selected)
            {
                DrawOutline();
            }
            SplashKit.DrawLine(Color, X, Y, EndX, EndY);
        }

        //override draw outline method to draw two filled circles at both ends of the line using the coordinates (X,Y) and (EndX, EndY)
        public override void DrawOutline()
        {
            SplashKit.FillCircle(Color, X, Y, 3);
            SplashKit.FillCircle(Color, EndX, EndY, 3);
        }

        public override bool IsAt(Point2D pt)
        {
            //defining the line with the given coordinates (X,Y) and (EndX, EndY) using SplashKit's LineFrom
            Line line = SplashKit.LineFrom(X, Y, EndX, EndY);
            //checking if the point is close to the line, less than 10 pixels
            if(SplashKit.PointLineDistance(pt, line) < 10)
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
            writer.WriteLine(EndX);
            writer.WriteLine(EndY);
        }

        public override void LoadFrom(StreamReader reader)
        {
            base.LoadFrom(reader);
            EndX = reader.ReadInteger();
            EndY = reader.ReadInteger();
        }
    }
}
