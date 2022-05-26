using System;
using System.Collections.Generic;

namespace PlanYourHeist
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Plan Your Heist!");
            Console.WriteLine("What difficulty?");
            int diffLvl = Int32.Parse(Console.ReadLine());
            Console.WriteLine("How many trials would you like to run?");
            int trialRuns = Int32.Parse(Console.ReadLine());

            for(int i=0; i<trialRuns; i++)
            {
            string memberName = "member";
            List<TeamMember> myTeam = new List<TeamMember>();
            while(memberName !="")
            {
            Console.WriteLine("Enter a Team Members Name.");
            memberName = Console.ReadLine();
            if(memberName != "")
            {
            Console.WriteLine("This members skill level is...");
            int memberSkillLevel = Int32.Parse(Console.ReadLine());
            Console.WriteLine("and their courage factor...?");
            double memberCourageFactor = Int32.Parse(Console.ReadLine());
            TeamMember newMember = new TeamMember(memberName, memberSkillLevel, memberCourageFactor);
            myTeam.Add(newMember);
            }
            }

            // TeamMember newMember2 = new TeamMember("derick", 4, 2.2);
            // TeamMember newMember3 = new TeamMember("karla", 5, 1.1);
            // TeamMember newMember4 = new TeamMember("olivia", 10, 0.1);
            // TeamMember newMember5 = new TeamMember("jordan", 10, 10.0);
            // myTeam.Add(newMember2);
            // myTeam.Add(newMember3);
            // myTeam.Add(newMember4);
            // myTeam.Add(newMember5);

            
            Console.WriteLine();
            Console.WriteLine($"{myTeam.Count} Team Members");
            foreach(TeamMember member in myTeam)
            {
                Console.WriteLine($"{member.Name}, {member.SkillLevel}, {member.CourageFactor}");
            }
            Console.WriteLine(myTeam.Count);

            var random = new Random();
            var luck = random.Next(-10, 10);
            int bankDiffLvl = diffLvl;
            int teamLvl = 0;
            bankDiffLvl = bankDiffLvl + luck;
            foreach(TeamMember member in myTeam)
            {
                teamLvl += member.SkillLevel;
            }
            Console.WriteLine(teamLvl);
            Console.WriteLine(bankDiffLvl);

            if(teamLvl > bankDiffLvl)
            {
                Console.WriteLine("Sucess");
            }
            if(teamLvl < bankDiffLvl)
            {
                Console.WriteLine("Failure");
            }
            }

            

        }
    }
}
