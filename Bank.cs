using System;
using System.Collections.Generic;

namespace PlanYourHeist
{
   public class Bank 
   {
       public double CashOnHand {get;set;}
       public int AlarmScore {get;set;}
       public int VaultScore {get;set;}
       public int SecurityGuardScore {get;set;}
       public bool IsSecure()
       {
           if(AlarmScore <= 0 && VaultScore <=0 && SecurityGuardScore <= 0)
           {
               return false;
           }
           else
           {
               return true;
           }
       }
   }

}
