using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BestU_v0._0._1
{
    public class Habit : ToDo
    {
    // A habit has a name (found in base class) and the day that you started it.
    // In addition, we compute the current day streak, which is the 
    // number of days since you began the habit.
        public DateTime StartDate { get; set; }
        private int DayStreak => (DateTime.Today - StartDate).Days;


    // Constructor for when we pass a date for our Habit
        public Habit(string _name, DateTime _startDate) : base(_name)
        {
            Name = _name;
            StartDate = _startDate;
        }

    // Constructor for when we only pass the Habit name, no date.
    // In this case, we automatically set the date to be today's date.
        public Habit(string _name) : base(_name)
        {
            Name = _name;
            StartDate = DateTime.Today;
        }
    }
}
