using Raylib_cs;
using System.Numerics;

namespace RaylibTemplate
{
    class Program
    {
        public static void Main()
        {
            // window initialization
            int windowHeight = 480;
            int windowWidth = 800;
            Raylib.InitWindow(windowWidth, windowHeight, "Template");
            Rectangle rect = new(400, 250, 110, 80);
            int gravity = 1;
            Raylib.SetTargetFPS(280);

            // main loop
            while (!Raylib.WindowShouldClose())
            {
                // begin rendering
                Raylib.BeginDrawing();
                // clear background
                Raylib.ClearBackground(Color.Black);

                // drawing fps
                Raylib.DrawFPS(10, 10);

                // draw with raw parameters
                //Raylib.DrawRectangle(250, 75, 100, 100, Color.Red);
                //Raylib.DrawCircle(150, 300, 50, Color.Green);

                // draw with Raylib shape objects (maybe don't create a new rect every frame)

                Raylib.DrawRectangleRec(rect, Color.Blue);
                rect.Y += gravity;
                float rectbottom = rect.Y + 80;
                int jumpVelocity = -200;
                if (rectbottom >= windowHeight)
                {
                    gravity = 0;
                }
                else { gravity = 1; }


                // handle input
                /*if (Raylib.IsKeyDown(KeyboardKey.Space))
                {
                    //Raylib.DrawText("SPACE", 160, 160, 150, Color.White);
                    rect.X += 1;
                }*/
                if (Raylib.IsKeyDown(KeyboardKey.D)) { rect.X += 2; }
                if (Raylib.IsKeyDown(KeyboardKey.A)) { rect.X -= 2; }
                if (Raylib.IsKeyPressed(KeyboardKey.Space)) { rect.Y += jumpVelocity; }


                Raylib.EndDrawing();
            }

            Raylib.CloseWindow();
        }
    }
}
