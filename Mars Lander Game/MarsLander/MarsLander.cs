using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MarsLander
{
    class MarsLander
    {
        // positive speed == speed towards Mars (DOWNWARD)

        private MarsLanderHistory mlh = new MarsLanderHistory();
        private int fuel;
        private int speed;
        private int height;
        // you'll need to add data fields & methods so that the rest of the program
        // can use the various properties of the lander (such as height, speed, etc)
        private UserInterface ui = new UserInterface();
        public void ForUser()
        {
            ui.PrintLanderInfo(height, speed, fuel);
        }
        public MarsLander()
        {
            height = 1000;
            speed = 100;
            fuel = 500;
        }
        public MarsLander(int a, int b, int c)
        {
            height = a;
            speed = b;
            fuel = c;
        }
        public int GetSpeed()
        {
            return speed; 
        }
        public void SetSpeed(int s)
        {
            speed = s;
        }
        public int GetFuelPoints()
        {
            return fuel;
        }
        public void SetFuelPoints(int f)
        {
            fuel = f;
        }
        public void DecreaseFuelPoints(int fuelToBurn)
        {
            fuel = fuel - fuelToBurn;
        }
        public void SetHeight(int h)
        {
            if (height < 0)
            {
                height = 0;
            }
            else
            {
                height = h;
            }
        }
        public int GetHeight()
        {
            return height;
        }
        public void CalculateNewSpeed(int fuelToBurn)

        {
            speed = speed - fuelToBurn + 50;
        }
        public void CalculateNewHeight()
        {
            height = height - speed;
            if(height < 0)
            {
                height = 0;
            }
        }
        public MarsLanderHistory GetHistory()
        {
            return mlh;
        }
    }
}
