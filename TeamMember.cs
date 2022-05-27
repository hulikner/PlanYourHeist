using System;

namespace PlanYourHeist
{
   public class TeamMember : IRobber
   {
        public string Name {get;set;}
        public int SkillLevel {get;set;}
        public double CourageFactor{get;set;}
        public int PercentageCut {get;set;}
        // public TeamMember(string name, int skillLevel, double courageFactor)
        // {
        //     Name = name;
        //     SkillLevel = skillLevel;
        //     CourageFactor = courageFactor;
        // }
        public virtual void PerformSkill(Bank bank)
       {
           Console.WriteLine($"{Name} is kicking security guard ass! Decreased security {SkillLevel} points");
           bank.SecurityGuardScore = bank.SecurityGuardScore - SkillLevel;
           if(bank.SecurityGuardScore <= 0)
           {
               Console.WriteLine($"{Name} has killed all the security guards!");
           }
       }
   }

}
