using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SplashKitSDK;
using System.IO;

namespace DifferentShapes
{
    public class MyRectangle : Shape //MyRectangle class now inherits all the features from the Shape class
    {
        private int _height, _width;

        //default constructor
        public MyRectangle() : this(Color.Green, 0, 0, 100, 100)
        {}

        //constructor that takes in parameters
        public MyRectangle(Color clr, float x, float y, int width, int height) : base (clr)
        {
            X = x;
            Y = y;
            Width = width;
            Height = height;
        }

        //Width property
        public int Width
        {
            get
            {
                return _width;
            }
            set
            {
                _width = value;
            }
        }

        //Height property
        public int Height
        {
            get
            {
                return _height;
            }
            set
            {
                _height = value;
            }
        }

        //override draw method to draw rectangles only
        public override void Draw()
        {
            if (Selected)
            {
                DrawOutline();
            }
            SplashKit.FillRectangle(Color, X, Y, _width, _height);
        }

        //override draw method to draw outlines for rectangles
        public override void DrawOutline()
        {
            SplashKit.DrawRectangle(Color.Black, X-2, Y-2, Width + 4, Height + 4);
        }

        //checking if the cursor is at a drawn rectangle
        public override bool IsAt(Point2D pt)
        {
            //the X and Y are the top left corner of the rectangle
            //therefore, check if mouse x-position is in the range [X, X + Width] and if the mouse y-position is in the range [Y, Y + height]
            if ((pt.X >= X && pt.X <= (X + Width)) && (pt.Y) >= Y && pt.Y <= (Y + Height))
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
            writer.WriteLine(Width);
            writer.WriteLine(Height);
        }

        public override void LoadFrom(StreamReader reader)
        {
            base.LoadFrom(reader);
            Width = reader.ReadInteger();
            Height = reader.ReadInteger();
        }
    }
}
