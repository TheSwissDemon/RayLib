using Raylib_cs;
using raylib_cs_template;
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
            Rectangle rect = new(400, 450, 110, 80);

            Rectangle platform = new(480, 350, 250, 80);

            Collission collision = new Collission(platform, rect);

            float gravity = 500f;
            float velocity = 0;
            float jumpForce = -400f;
            bool isJumping = false;



            //Raylib.SetTargetFPS(280);

            // main loop
            while (!Raylib.WindowShouldClose())
            {
                float deltaTime = Raylib.GetFrameTime();
                float rectbottom = rect.Y + 80;

                if (Raylib.IsKeyPressed(KeyboardKey.Space) && !isJumping)
                {

                    velocity = jumpForce;
                    isJumping = true;
                }
                if (Raylib.IsKeyDown(KeyboardKey.D)) { rect.X += 400 * deltaTime; }
                if (Raylib.IsKeyDown(KeyboardKey.A)) { rect.X -= 400 * deltaTime; }

                if (isJumping)
                {
                    velocity += gravity * deltaTime;
                    rect.Y += velocity * deltaTime;
                }
                bool isColliding = collision.collided(platform, rect);
                if (rect.Y + rect.Height >= windowHeight && isColliding)
                {

                    rect.Y = windowHeight - rect.Height;
                    velocity = 0;
                    isJumping = false;
                }

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
                Raylib.DrawRectangleRec(platform, Color.Red);


                // handle input
                /*if (Raylib.IsKeyDown(KeyboardKey.Space))
                {
                    //Raylib.DrawText("SPACE", 160, 160, 150, Color.White);
                    rect.X += 1;
                }*/


                Raylib.EndDrawing();
            }

            Raylib.CloseWindow();
        }
    }
}
