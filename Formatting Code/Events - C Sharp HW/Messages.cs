// <copyright file="Messages.cs" company="ReplaceThis">
//     ReplaceThis. All rights reserved.
// </copyright>
// <author>ReplaceThis</author>

namespace HomeworkEvents
{
    using System.Text;

    public static class Messages
    {
        private static StringBuilder output = new StringBuilder();

        public static StringBuilder Output 
        {
            get
            {
                return output;
            }

            set
            {
                // Validation
                output = value;
            }
        }

        public static void EventAdded()
        {
            output.Append("Event added\n");

            // System.Console.WriteLine("Event Added"); //Line added for feedback purpose
        }

        public static void EventDeleted(int x)
        {
            if (x == 0)
            {
                NoEventsFound();
            }
            else
            {
                output.AppendFormat("{0} events deleted\n", x);
            }
        }

        public static void NoEventsFound()
        {
            output.Append("No events found\n");
        }

        public static void PrintEvent(Event eventToPrint)
        {
            if (eventToPrint != null)
            {
                output.Append(eventToPrint + "\n");
            }
        }
    }
}
