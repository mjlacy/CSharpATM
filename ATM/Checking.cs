﻿using System;

namespace ATM
{
    [Serializable]
    class Checking: Account
    {
        public Checking(int bal, int num, String name, String PIN) : base(bal, num, name, PIN) {}


        protected override void GetInterest()
        {
            int datediff = date2.DayOfYear - date1.DayOfYear;
            Rate = .05 / 365;
            double ratetime = Math.Pow(1 + Rate, datediff);

            if (date2.Year - date1.Year > 0) //allows for different years to be input
            {
                int yeardiff = date2.Year - date1.Year;
                ratetime *= Math.Pow(1.05, yeardiff);
            }
            Balance *= (decimal) ratetime;
            date1 = date2;
        }
    }
}
