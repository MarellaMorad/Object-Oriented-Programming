using System;
using SplashKitSDK;

namespace ShapeDrawer
{
    public class Program
    {
        public static void Main()
        {
            //Opens a new window called Shape Drawer with dimensions 800 x 600
            new Window("Shape Drawer", 800, 600);

            //create a new Shape variable
            Shape myShape = new Shape();

            //leaves the window open unless requested to be closed
            do
            {
                SplashKit.ProcessEvents(); //allows Splashkit to react to user interactions
                SplashKit.ClearScreen();

                //If the user clicks the LeftButton on their mouse
                if (SplashKit.MouseClicked(MouseButton.LeftButton) == true)
                {
                    //set the shapes x, y to be at the mouse's position
                    myShape.X = SplashKit.MouseX();
                    myShape.Y = SplashKit.MouseY();
                }

                //If the mouse is over the shape (pass the mouse position to the IsAt() method as a 2D point)
                if (myShape.IsAt(SplashKit.MousePosition()))
                {
                    //also check if the user presses the spacebar
                    if (SplashKit.KeyTyped(KeyCode.SpaceKey) == true)
                    {
                        //change the Color of the shape to a random color
                        myShape.Color = SplashKit.RandomRGBColor(255); //alpha = 255 for the color to be non-transparent
                    }
                }

                //draw the rectangle after checking and processing user input
                myShape.Draw();

                //refresh
                SplashKit.RefreshScreen();

            } while (!SplashKit.WindowCloseRequested("Shape Drawer"));
        }
    }
}

