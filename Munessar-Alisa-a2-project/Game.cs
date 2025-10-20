using System;
using System.Numerics;

namespace MohawkGame2D;

public class Game
{
    // Colors
    Color darkGreen = new Color(9, 121, 105);
    Color lightGreen = new Color(175, 225, 175);
    Color skyTop = new Color(135, 206, 250);   // Light blue
    Color skyBottom = new Color(0, 128, 255);  // Deeper blue

    // Dot position
    float dotX = 100;
    float dotY = 100;

    // Score
    int score = 0;

    // Random Dots
    System.Random rand = new System.Random();

    public void Setup()
    {
        Window.SetTitle("Wolf Collector");
        Window.SetSize(400, 400);
        Draw.LineColor = Color.Clear;
    }

    public void Update()
    {
        // Clear background with gradient 
        Color[] gradient = new Color[]
{
         new Color(135, 206, 250),
         new Color(100, 180, 240),
         new Color(70, 160, 230),
         new Color(40, 130, 220),
         new Color(0, 100, 200)

};

        for (int i = 0; i < gradient.Length; i++)
        {
            Draw.FillColor = gradient[i];
            Draw.Rectangle(0, i * 80, 400, 80);
        }
        // Draw grass using triangles
        Draw.FillColor = lightGreen;

        for (int x = 0; x <= 400; x += 40)
        {
            Draw.Triangle(x, 400, x + 20, 350, x + 40, 400);
        }
        // Draw darker grass layer
        Draw.FillColor = darkGreen;
        for (int x = 20; x <= 400; x += 40)
        {
            Draw.Triangle(x, 400, x + 20, 350, x + 40, 400);
        }
        // Get mouse position
        float wolfX = Input.GetMouseX();
        float wolfY = Input.GetMouseY();

        //Draw Wolf and body part

        // Draw body
        Draw.FillColor = Color.White;
        Draw.Circle(wolfX, wolfY, 30); // Body

        // Draw head
        Draw.FillColor = Color.White;
        Draw.Circle(wolfX + 30, wolfY - 30, 20); // Head

        // Draw ear (small triangle)
        Draw.FillColor = Color.Gray;
        Draw.Triangle(
            wolfX + 25, wolfY - 45,
            wolfX + 35, wolfY - 60,
            wolfX + 45, wolfY - 45
        );

        //Draw other ear
        Draw.FillColor = Color.Gray;
        Draw.Triangle(
            wolfX + 15, wolfY - 45,
            wolfX + 25, wolfY - 60,
            wolfX + 45, wolfY - 45
            );

        //Draw snout
        Draw.FillColor = Color.Gray;
        Draw.Circle(wolfX + 55, wolfY - 30, 6);

        // Draw eye
        Draw.FillColor = Color.Black;
        Draw.Circle(wolfX + 35, wolfY - 35, 3);

        // Draw tail (small circle or triangle)
        Draw.FillColor = Color.White;
        Draw.Circle(wolfX - 35, wolfY - 10, 10);

        // Draw legs 
        Draw.FillColor = Color.Gray;
        Draw.Rectangle(wolfX - 15, wolfY + 25, 5, 15);
        Draw.Rectangle(wolfX + 10, wolfY + 25, 5, 15);

        // Draw dot
        Draw.FillColor = Color.Red;
        Draw.Circle(dotX, dotY, 10);

        // Check for collision 
        float distance = Vector2.Distance(new Vector2(wolfX, wolfY), new Vector2(dotX, dotY));
        if (distance < 40)
        {
            // Increase score
            score++;

            // Move dot to random position
            dotX = rand.Next(20, 380);
            dotY = rand.Next(20, 380);
        }

        // Draw score
        Draw.FillColor = Color.Black;

    }
}

