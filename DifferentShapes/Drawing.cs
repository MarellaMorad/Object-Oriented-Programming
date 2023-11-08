using SplashKitSDK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace DifferentShapes
{
    public class Drawing
    {
        //Add a private, read only, field to store the list of _shapes. Use List<Shape> as the type
        private readonly List<Shape> _shapes;

        //_background private field
        private Color _background;

        //public Background property for the background color.
        public Color Background
        {
            get
            {
                return _background;
            }
            set
            {
                _background = value;
            }
        }

        //constructor that takes in the background color as a parameter
        public Drawing(Color background)
        {
            _shapes = new List<Shape>();
            _background = background;
        }

        //default constructor - without parameters
        public Drawing() : this(Color.White)
        {
            _shapes = new List<Shape>();
            _background = Color.White;
        }

        public int ShapeCount
        {
            get
            {
                return _shapes.Count;
            }
        }

        public void AddShape(Shape shape)
        {
            _shapes.Add(shape);
        }
        
        public void Draw()
        {
            SplashKit.ClearScreen(Background);
            foreach (Shape shape in _shapes)
            {
                shape.Draw();
            }
        }

        public void SelectShapeAt(Point2D pt)
        {
            foreach (Shape s in _shapes)
            {
                if (s.IsAt(pt))
                {
                    s.Selected = true;
                }
                else
                {
                    s.Selected = false;
                }
            }
        }

        public List<Shape> SelectedShapes
        {
            get
            {
                List<Shape> result = new List<Shape>();
                foreach (Shape s in _shapes)
                {
                    if (s.Selected == true)
                    {
                        result.Add(s);
                    }
                }

                return result;
            }
        }

        public void RemoveShape(Shape shape)
        {
            _shapes.Remove(shape);
        }

        public void Save(string filename)
        {
            StreamWriter writer;

            writer = new StreamWriter(filename);
            try
            {
                writer.WriteColor(Background); //output the background color as three floating point numbers (RGB), which can
                                               //then be used to recreate the color using Color's RGBColor function when the file is loaded.
                writer.WriteLine(ShapeCount);  //outputs the number of shapes, so that when the file is read back in we can use
                                               //that number to determine how many shapes need to be read in

                foreach (Shape s in _shapes)
                {
                    s.SaveTo(writer);
                }
            }
            finally
            {
                writer.Close();
            }            
        }

        public void Load(string filename)
        {
            StreamReader reader;
            int count;
            Shape s;
            string kind;

            reader = new StreamReader(filename);
            try
            {
                Background = reader.ReadColor();
                count = reader.ReadInteger();
                _shapes.Clear();

                for (int i = 0; i < count; i++)
                {
                    kind = reader.ReadLine();

                    s = Shape.CreateShape(kind);

                    s.LoadFrom(reader);
                    _shapes.Add(s);
                }
            }
            finally
            {
                reader.Close();
            }
        }
    }
}
