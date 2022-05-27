using System;
using System.Collections.Generic;

namespace PlanYourHeist
{
   public class LockSpecialist : TeamMember
   {
        public override void PerformSkill(Bank bank)
       {
           Console.WriteLine($"{Name} is picking the vault. Decreased security {SkillLevel} points");
           bank.VaultScore = bank.VaultScore - SkillLevel;
           if(bank.VaultScore <= 0)
           {
               Console.WriteLine($"{Name} has opened the vault!");
           }
       }
   }
}
