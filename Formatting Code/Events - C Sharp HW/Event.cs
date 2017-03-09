// <copyright file="Event.cs" company="ReplaceThis">
//     ReplaceThis. All rights reserved.
// </copyright>
// <author>ReplaceThis</author>

namespace HomeworkEvents
{
    using System;
    using System.Text;

    /// <summary>Summary not implemented yet!</summary>
    public class Event : IComparable
    {
        /// <summary>Summary not implemented yet!</summary>
        private DateTime date;

        /// <summary>Summary not implemented yet!</summary>
        private string title;

        /// <summary>Summary not implemented yet!</summary>
        private string location;

        /// <summary>Initializes a new instance of the <see cref="Event"/> class</summary>
        /// <param name="date">To be implemented later</param>
        /// <param name="title">To be implemented later</param>
        /// <param name="location">To be implemented later</param>
        public Event(DateTime date, string title, string location)
        {
            this.Date = date;
            this.Title = title;
            this.Location = location;
        }

        /// <summary>Gets or sets <see cref="this.Date"/> </summary>
        public DateTime Date
        {
            get
            {
                return this.date;
            }

            set
            {
                // Implement validation
                this.date = value;
            }
        }

        /// <summary>Gets or sets <see cref="this.Title"/> </summary>
        public string Title
        {
            get
            {
                return this.title;
            }

            set
            {
                // Implement validation
                this.title = value;
            }
        }

        /// <summary>Gets or sets <see cref="this.Location"/> </summary>
        public string Location
        {
            get
            {
                return this.location;
            }

            set
            {
                // Implement validation
                this.location = value;
            }
        }

        /// <summary>Summary not implemented yet!</summary>
        /// <param name="obj">To be implemented later</param>
        /// <returns>To be implemented later</returns>
        public int CompareTo(object obj)
        {
            Event other = obj as Event;
            int byDate = this.Date.CompareTo(other.Date);
            int byTitle = this.Title.CompareTo(other.Title);
            int byLocation = this.Location.CompareTo(other.Location);
            if (byDate == 0)
            {
                if (byTitle == 0)
                {
                    return byLocation;
                }
                else
                {
                    return byTitle;
                }
            }
            else
            {
                return byDate;
            }
        }

        /// <summary>Overrides ToString Method</summary>
        /// <returns>The instance of <see cref="Event"/> to string</returns>
        public override string ToString() 
        {
            var strBuilder = new StringBuilder();

            strBuilder.Append(this.Date.ToString("yyyy-MM-ddTHH:mm:ss"));
            strBuilder.Append(" | " + this.Title);

            if (this.Location != null && this.Location != string.Empty)
            {
                strBuilder.Append(" | " + this.Location);
            }
            
            return strBuilder.ToString();
        }
    }
}
