using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UKD_OOP_PR2
{
    public class Hobby
    {
        public string activity;
        public int timeTaken;
        public int usefullnessForIT;

        public Hobby(string _activity, int _timeTaken, int _usefullnessForIT)
        {
            activity = _activity;
            timeTaken = _timeTaken;
            usefullnessForIT = _usefullnessForIT;
        }
    }
}
