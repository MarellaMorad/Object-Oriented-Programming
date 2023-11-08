using System;
using SplashKitSDK;
using System.Collections.Generic;

namespace ShapeDrawer
{
    public class Program
    {
        public static void Main()
        {
            //Opens a new window called Shape Drawer with dimensions 800 x 600
            new Window("Shape Drawer", 800, 600);

            Drawing drawing = new Drawing();
            

            //leaves the window open unless requested to be closed
            do
            {
                SplashKit.ProcessEvents(); //allows Splashkit to react to user interactions
                SplashKit.ClearScreen();
                
                if(SplashKit.MouseClicked(MouseButton.LeftButton) == true)
                {
                    //add a new Shape to your Drawing object based on the mouse's location.
                    Shape myShape = new Shape();
                    myShape.X = SplashKit.MouseX();
                    myShape.Y = SplashKit.MouseY();
                    drawing.AddShape(myShape);
                }

                if(SplashKit.KeyTyped(KeyCode.SpaceKey) == true)
                {
                    drawing.Background = SplashKit.RandomRGBColor(255);
                }

                if (SplashKit.MouseClicked(MouseButton.RightButton) == true)
                {
                    drawing.SelectShapeAt(SplashKit.MousePosition());
                }

                if(SplashKit.KeyTyped(KeyCode.BackspaceKey) == true || SplashKit.KeyTyped(KeyCode.DeleteKey) == true)
                {
                    List<Shape> selectedShapes = drawing.SelectedShapes;
                    foreach(Shape s in selectedShapes)
                    {
                        drawing.RemoveShape(s);
                    }
                }

                drawing.Draw();

                //refresh
                SplashKit.RefreshScreen();

            } while (!SplashKit.WindowCloseRequested("Shape Drawer"));
        }
    }
}

