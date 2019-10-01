using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MarsLander
{
    class MarsLanderHistory
    {
        //MarsLander ml = new MarsLander();
        RoundInfo[] rounds = new RoundInfo[10];
        int numRounds = 0;
        //Clone is provided to you; it'll create a copy of the current history
        // Look for opportunities to use it elsewhere.
        public MarsLanderHistory Clone()
        {
            MarsLanderHistory copy = new MarsLanderHistory();

            copy.rounds = new RoundInfo[this.rounds.Length];
            copy.numRounds = this.numRounds;
            for (int i = 0; i < copy.numRounds; i++)
                copy.rounds[i] = this.rounds[i];

            return copy;
        }

        public void AddRound(int height, int speed)
        {
            if (numRounds + 1 > rounds.Length)
            {
                RoundInfo[] temp = new RoundInfo[numRounds + 10];
                for (int i = 0; i < rounds.Length; i++)
                {
                    temp[i] = rounds[i];
                }
                rounds = new RoundInfo[numRounds + 10];
                for (int j = 0; j < temp.Length; j++)
                {
                    rounds[j] = temp[j];
                }
            }
            RoundInfo r = new RoundInfo(height, speed);
            rounds[numRounds] = r;
            numRounds++;
        }

        public int NumberOfRounds()
        {
            return numRounds;
        }

        public int GetHeight(int i)
        {
            return rounds[i].GetHeight();
        }
        
        public int GetSpeed(int i)
        {
            return rounds[i].GetSpeed();
        }

        // you'll need other methods in order to make the PrintHistory command work
    }

    // This is provided to you; you shouldn't need to add anything to it, but
    // if you want to you are welcome to do so
    class RoundInfo
    {
        private int height;
        private int speed;

        #region Accessors
        public int GetHeight()
        {
            return height;
        }
        public void SetHeight(int newValue)
        {
            height = newValue;
        }

        public int GetSpeed()
        {
            return speed;
        }
        public void SetSpeed(int newValue)
        {
            speed = newValue;
        }
        #endregion Accessors

        public RoundInfo(int h, int s)
        {
            height = h;
            speed = s;
        }
    }
}
