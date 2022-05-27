using System;

namespace PlanYourHeist
{
   public interface IRobber 
   {
        string Name {get;set;}
        int SkillLevel {get;set;}
        double PercentageCut {get;set;}
        string Specialty {get;set;}
        double BankLoot {get;set;}
        void PerformSkill(Bank bank);
   }

}