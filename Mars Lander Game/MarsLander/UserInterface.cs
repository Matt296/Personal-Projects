using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MarsLander
{
    class UserInterface
    {
        private int height;
        public void PrintGreeting()
        {
            Console.WriteLine("Welcome to the Mars Lander game!");
        }

        // This should print the 'picture' of hte lander
        // for example:
        //      1000m: *
        //      900m: 
        //      800m:
        // etc, etc
        public void PrintLocation(int h)
        {
            height = h;
            if (height <= 3000)
            {
                for (int i = height/100; i >= 0  /*i < height*/; i--)
                {
                    Console.Write(" {0}m:", i * 100);
                    if(i * 100 <= height && (i + 1) * 100 > height)
                    {
                        Console.Write("*");
                    }
                    Console.WriteLine();
                }
            }
            Console.WriteLine();
        }

        // This prints out the info about the lander
        // For example:
        //      Exact height: 1350 meters
        //      Current (downward) speed: -350 meters/second
        //      Fuel points left: 0
        public void PrintLanderInfo( int h, int s, int f)
        {
            Console.WriteLine("Exact height: {0} meters", h);
            Console.WriteLine("Current (downward) speed: {0} meters/second", s);
            Console.WriteLine("fuel points left: {0}", f);
            Console.WriteLine();
        }

        // This will ask the user for how much fuel they want to burn,
        // verify that they've type in an acceptable integer,
        //  (repeatedly asking the user for input if needed),
        // and will then return that number back to the main method
        public int GetFuelToBurn(int nFuel)
        {
            int num;
            Console.WriteLine("How many points of fuel would you like to burn?");
            //int fuelBurned = Int32.Parse(Console.ReadLine());
            string fuelBurned = Console.ReadLine();
            bool number = Int32.TryParse(fuelBurned, out num);
            if (number)
            {
                if (num > nFuel)
                {
                    Console.WriteLine("You don't have {0} points of fuel!", fuelBurned);
                    return 0;
                }
                //bool number = Int32.TryParse(, out num);
                else if (num < 0)
                {
                    Console.WriteLine("You can't burn less than 0 points of fuel!");
                    return 0;
                }
                else
                {
                    return num;
                }
            }
            else
            {
                Console.WriteLine("You need to type a whole number of fuel points to burn!");
                return GetFuelToBurn(nFuel);
            }
            return 0;
        }

        // This will only be called once the lander is on the surface of Mars, 
        //  and will tell the player if they successly landed or if they crashed
        public void PrintEndOfGameResult(MarsLander ml, int maxSpeed)
        {
            if(ml.GetSpeed() > maxSpeed)
            {
                Console.WriteLine("The maximum speed for a safe landing is 10; your lander's current speed is 500 You have crashed the lander into the surface of Mars, killing everyone on board," +
                    "costing NASA millions of dollars, and setting the space program back by decades! Here's the height/speed info for you:");
            }
            if (ml.GetSpeed() <= maxSpeed)
            {
                Console.WriteLine("Congratulations!! You've successfully landed your Mars Lander, without crashing!!!");
            }
            //PrintHistory(ml.GetHistory());
        }
        
        // This will print out, for example: 
        //      Round # 	Height (in m) 	Speed (downwards, in m/s)
        //      0 		850 		150
        //      1 		650 		200
        //  etc
        //
        // This is provided to you, but you'll need to add stuff elsewhere in order to make it work 
        public void PrintHistory(MarsLanderHistory mlh)
        {
            Console.WriteLine("Round #\t\tHeight (in m)\t\tSpeed (downwards, in m/s)");
            for (int i = 0; i < mlh.NumberOfRounds(); i++)
            {
                Console.WriteLine("{0}\t\t{1}\t\t\t{2}", i, mlh.GetHeight(i), mlh.GetSpeed(i));
            }
        }
    }
}
