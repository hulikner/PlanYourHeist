using System;
using System.Collections.Generic;

namespace PlanYourHeist
{
   public class Hacker : TeamMember
   {
        public override string Specialty {get;set;} = "Hacker";

       public override void PerformSkill(Bank bank)
       {
           Console.WriteLine($"{Name} is hacking the alarm system. Decreased security {SkillLevel} points");
           bank.AlarmScore = bank.AlarmScore - SkillLevel;
           if(bank.AlarmScore <= 0)
           {
               Console.WriteLine($"{Name} has disabled the alarm system!");
           }
       }
   }

}
