﻿using ExtendedLINQ;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExtendedLINQClassicNetFramework
{
    class QuaryExamples
    {
        public static void Example1()
        {
            using (var context = new DefectModelDataContext())
            {
                context.Log = Console.Out;

                User tim = (from user in context.Users
                            where user.Name == "Tim Trotter"
                            select user).Single();

                var query = from defect in context.Defects
                            where defect.Status != Status.Closed
                            where defect.AssignedTo == tim
                            select defect.Summary;

                foreach (var summary in query)
                {
                    Console.WriteLine(summary);
                }
            }
        }

        public static void Example2()
        {
            using (var context = new DefectModelDataContext())
            {
                context.Log = Console.Out;

                var query = from user in context.Users
                            let length = user.Name.Length
                            orderby length
                            select new { Name = user.Name, Length = length };

                foreach (var entry in query)
                {
                    Console.WriteLine("{0}: {1}", entry.Length, entry.Name);
                }
            }
        }

        public static void Example3()
        {
            using (var context = new DefectModelDataContext())
            {
                context.Log = Console.Out;

                var query = from defect in context.Defects
                            join subscription in context.NotificationSubscriptions 
                                on defect.Project equals subscription.Project
                            select new { defect.Summary, subscription.EmailAddress };

                foreach (var entry in query)
                {
                    Console.WriteLine(entry);
                }
            }
        }

    }
}
