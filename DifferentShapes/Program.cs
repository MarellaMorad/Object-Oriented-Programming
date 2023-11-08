using System;
using SplashKitSDK;
using System.Collections.Generic;

namespace DifferentShapes
{
    public class Program
    {
        //creating ShaeKind that will determine what type of shape the user requested to draw
        private enum ShapeKind
        {
            Rectangle,
            Circle,
            Line
        }
        public static void Main()
        {
            //Registering the shapes
            Shape.RegisterShape("Rectangle", typeof(MyRectangle));
            Shape.RegisterShape("Circle", typeof(MyCircle));
            Shape.RegisterShape("Line", typeof(MyLine));

            //Opens a new window called Shape Drawer with dimensions 800 x 600
            new Window("Shape Drawer", 800, 600);

            Drawing myDrawing = new Drawing();
            //setting the default shapeKind to circle
            ShapeKind kindToAdd = ShapeKind.Circle;


            //leaves the window open unless requested to be closed
            do
            {
                SplashKit.ProcessEvents(); //allows Splashkit to react to user interactions
                SplashKit.ClearScreen();
                //if the user presses the R Key, then they've chosen to draw a rectangle
                if(SplashKit.KeyTyped(KeyCode.RKey))
                {
                    kindToAdd = ShapeKind.Rectangle;
                }
                //if the user presses the C Key, then they've chosen to draw a circle
                else if (SplashKit.KeyTyped(KeyCode.CKey))
                {
                    kindToAdd = ShapeKind.Circle;
                }
                //if the user presses the L Key, then they've chosen to draw a line
                else if (SplashKit.KeyTyped(KeyCode.LKey))
                {
                    kindToAdd = ShapeKind.Line;
                }

                //drawing the shapes when the mouse's left button is pressed, after taking in the user selection
                if (SplashKit.MouseClicked(MouseButton.LeftButton))
                {
                    Shape newShape;

                    if(kindToAdd == ShapeKind.Circle)
                    {
                        //add a new Shape to your Drawing object based on the mouse's location.
                        MyCircle newCircle = new MyCircle();

                        newShape = newCircle;
                    }
                    else if(kindToAdd == ShapeKind.Rectangle)
                    {
                        //add a new Shape to your Drawing object based on the mouse's location.
                        MyRectangle newRect = new MyRectangle();

                        newShape = newRect;
                    }
                    else
                    {
                        MyLine newLine = new MyLine();
                        newShape = newLine;
                    }

                    newShape.X = SplashKit.MouseX();
                    newShape.Y = SplashKit.MouseY();
                    myDrawing.AddShape(newShape);

                }

                //setting the background color to a random color when the user presses space
                if (SplashKit.KeyTyped(KeyCode.SpaceKey) == true)
                {
                    myDrawing.Background = SplashKit.RandomRGBColor(255);
                }
                
                //if the mouse's right button is clicked, select the shape (if the mouse is at a shape)
                if (SplashKit.MouseClicked(MouseButton.RightButton) == true)
                {
                    myDrawing.SelectShapeAt(SplashKit.MousePosition());
                }

                //pressing backspace or delete, allows the user to delete the selected shapes
                if (SplashKit.KeyTyped(KeyCode.BackspaceKey) == true || SplashKit.KeyTyped(KeyCode.DeleteKey) == true)
                {
                    List<Shape> selectedShapes = myDrawing.SelectedShapes;
                    foreach (Shape s in selectedShapes)
                    {
                        myDrawing.RemoveShape(s);
                    }
                }

                if(SplashKit.KeyTyped(KeyCode.SKey))
                {
                    myDrawing.Save("TestDrawing.txt");
                }

                if (SplashKit.KeyTyped(KeyCode.OKey))
                {
                    try
                    {
                        myDrawing.Load("TestDrawing.txt");
                    } catch(Exception e)
                    {
                        Console.Error.WriteLine("Error loading file : {0}", e.Message);
                    }
                    
                }

                myDrawing.Draw();

                //refresh
                SplashKit.RefreshScreen();

            } while (!SplashKit.WindowCloseRequested("Shape Drawer"));
        }
    }
}

