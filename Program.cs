using System;
using System.Collections.Generic;

namespace PlanYourHeist
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Plan Your Heist!");
            // Console.WriteLine("What difficulty?");
            // int diffLvl = 0;
            // Console.WriteLine("How many trials would you like to run?");
            // int trialRuns = Int32.Parse(Console.ReadLine());

            Hacker jon = new Hacker()
            {
                Name = "Jon",
                SkillLevel = 50,
                CourageFactor = 50,
                PercentageCut = 10
            };
            LockSpecialist jack = new LockSpecialist()
            {
                Name = "Jack",
                SkillLevel = 50,
                CourageFactor = 50,
                PercentageCut = 10
            };
            Muscle bruce = new Muscle()
            {
                Name = "Bruce",
                SkillLevel = 50,
                CourageFactor = 50,
                PercentageCut = 10
            };
            Hacker jill = new Hacker()
            {
                Name = "Jill",
                SkillLevel = 50,
                CourageFactor = 50,
                PercentageCut = 10
            };
            LockSpecialist bill = new LockSpecialist()
            {
                Name = "Bill",
                SkillLevel = 50,
                CourageFactor = 50,
                PercentageCut = 10
            };
            Muscle rocky = new Muscle()
            {
                Name = "Rocky",
                SkillLevel = 50,
                CourageFactor = 50,
                PercentageCut = 10
            };



            List<IRobber> rolodex = new List<IRobber>()
            {
                jon, jack, bruce, jill, bill, rocky
            };
            string newOp = "operative";
            while(newOp != "")
            {
            Console.WriteLine($"{rolodex.Count} available operatives");
            Console.WriteLine("New Operative? Enter Name...");
            newOp = Console.ReadLine();
            if(newOp != "")
            {
            Console.WriteLine("What is the operatives specialty?");
            Console.WriteLine("1) Hacker (Disables alarms)");
            Console.WriteLine("2) Muscle (Disarms guards)");
            Console.WriteLine("3) Lock Specialist (cracks vault)");
            int opSkillChoice = Int32.Parse(Console.ReadLine());
            Console.WriteLine("Enter the operatives skill level (1-100)");
            int opSkillLevel = Int32.Parse(Console.ReadLine());
            Console.WriteLine("What is the operatives demanded cut?");
            int opCut = Int32.Parse(Console.ReadLine());
            if (opSkillChoice == 1)
            {
            Hacker operative = new Hacker()
            {
                Name = newOp,
                SkillLevel = opSkillLevel,
                PercentageCut = opCut
            };
                rolodex.Add(operative);
            }
            else if (opSkillChoice == 2)
            {
            Muscle operative = new Muscle()
            {
                Name = newOp,
                SkillLevel = opSkillLevel,
                PercentageCut = opCut
            };
                rolodex.Add(operative);
            }
            else
            {
            LockSpecialist operative = new LockSpecialist()
            {
                Name = newOp,
                SkillLevel = opSkillLevel,
                PercentageCut = opCut
            };
                rolodex.Add(operative);
            }
            }
            }
            Random random = new Random();
            Bank targetBank = new Bank()
            {
                AlarmScore = random.Next(0,101),
                VaultScore = random.Next(0,101),
                SecurityGuardScore = random.Next(0,101),
                CashOnHand = random.Next(50000,1000001)
            };

            string large = "";
            string small = "";
            int a = targetBank.AlarmScore;
            int b = targetBank.VaultScore;
            int c = targetBank.SecurityGuardScore;

            if (a > b && a > c)
                large = "Alarm System";
            else if (b > a && b > c)
                large = "Vault";
            else if (c > a && c > b)
                large = "Security Guards";

            if (a < b && a < c)
                small = "Alarm System";
            else if (b < a && b < c)
                small = "Vault";
            else if (c < a && c < b)
                small = "Security Guards";
            Console.WriteLine($"The {large} is the most secure and the {small} is the most insecure.");
            List<IRobber> selectFrom = new List<IRobber>();
            selectFrom = rolodex;
            List<IRobber> crew = new List<IRobber>();
            int select = 1;
            while(select != 0 && selectFrom.Count != 0)
            {
                Console.WriteLine("Choose a crew member");
                Console.WriteLine();
                Console.WriteLine("Or choose 0 to start.");
                Console.WriteLine();
            for(int i=0; i<selectFrom.Count; i++)
            {
                Console.WriteLine($"{i+1}) {selectFrom[i].Name}, {selectFrom[i].Specialty}, Skill Level = {selectFrom[i].SkillLevel}, Percentage Cut = {selectFrom[i].PercentageCut}");
            }
                select = Int32.Parse(Console.ReadLine());
                if(select != 0)
                {
                crew.Add(selectFrom[select - 1]);
                selectFrom.Remove(selectFrom[select-1]);
                }
                else {break;}
            }
            Console.WriteLine($"{targetBank.CashOnHand}");
            foreach(IRobber member in crew)
            {
                member.PerformSkill(targetBank);
                member.PercentageCut = member.PercentageCut * 0.01;
                member.BankLoot = member.PercentageCut * targetBank.CashOnHand;
            }
            foreach(IRobber member in crew)
            {
                targetBank.CashOnHand = targetBank.CashOnHand - member.BankLoot;
            }
            
            if(targetBank.AlarmScore <= 0 && targetBank.VaultScore <= 0 && targetBank.SecurityGuardScore <= 0)
            {
                Console.WriteLine("Success!");
                foreach(IRobber member in crew)
                {
                    Console.WriteLine($"{member.Name}'s cut is ${Math.Round(member.BankLoot)}");
                }
                    Console.WriteLine($"Whats left for you is ${Math.Round(targetBank.CashOnHand)}");
            }
            else
            {
                Console.WriteLine("Failure");
            }
            













            // for(int i=0; i<trialRuns; i++)
            // {
            // string memberName = "member";
            // List<TeamMember> myTeam = new List<TeamMember>();
            // while(memberName !="")
            // {
            // Console.WriteLine("Enter a Team Members Name.");
            // memberName = Console.ReadLine();
            // if(memberName != "")
            // {
            // Console.WriteLine("This members skill level is...");
            // int memberSkillLevel = Int32.Parse(Console.ReadLine());
            // Console.WriteLine("and their courage factor...?");
            // double memberCourageFactor = Int32.Parse(Console.ReadLine());
            // TeamMember newMember = new TeamMember(){Name = memberName, SkillLevel = memberSkillLevel, CourageFactor = memberCourageFactor};
            // myTeam.Add(newMember);
            // }
            // }

            // // TeamMember newMember2 = new TeamMember("derick", 4, 2.2);
            // // TeamMember newMember3 = new TeamMember("karla", 5, 1.1);
            // // TeamMember newMember4 = new TeamMember("olivia", 10, 0.1);
            // // TeamMember newMember5 = new TeamMember("jordan", 10, 10.0);
            // // myTeam.Add(newMember2);
            // // myTeam.Add(newMember3);
            // // myTeam.Add(newMember4);
            // // myTeam.Add(newMember5);

            
            // Console.WriteLine();
            // Console.WriteLine($"{myTeam.Count} Team Members");
            // foreach(TeamMember member in myTeam)
            // {
            //     Console.WriteLine($"{member.Name}, {member.SkillLevel}, {member.CourageFactor}");
            // }
            // Console.WriteLine(myTeam.Count);

            // var luck = random.Next(-10, 10);
            // int bankDiffLvl = diffLvl;
            // int teamLvl = 0;
            // bankDiffLvl = bankDiffLvl + luck;
            // foreach(TeamMember member in myTeam)
            // {
            //     teamLvl += member.SkillLevel;
            // }
            // Console.WriteLine(teamLvl);
            // Console.WriteLine(bankDiffLvl);

            // if(teamLvl > bankDiffLvl)
            // {
            //     Console.WriteLine("Sucess");
            // }
            // if(teamLvl < bankDiffLvl)
            // {
            //     Console.WriteLine("Failure");
            // }
            // }

            

        }
    }
}
