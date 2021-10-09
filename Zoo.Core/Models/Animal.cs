using System;
using Zoo.Core.Enums;

namespace Zoo.Core.Models
{
    public abstract class Animal
    {
        /// <summary>
        /// Preferably use constructor with scientific name
        /// </summary>
        protected Animal()
        {
            ScientificName = "Unknown";
        }

        /// <summary>
        /// Constructor which sets animal's scientific name
        /// </summary>
        /// <param name="scientificName"></param>
        protected Animal(string scientificName)
        {
            ScientificName = scientificName;
        }

        public string ScientificName { get; }

        public string Name { get; set; }

        public Gender Gender { get; set; }

        public DateTime Birthday { get; set; }

        public int Age => CalculateAge();

        /// <summary>
        /// Return the amount of days until the animals next birthday
        /// </summary>
        /// <returns></returns>
        public int DaysUntilNextBirthday()
        {
            // Get next birthday date
            var nextBirthdayDate = new DateTime(DateTime.UtcNow.Year + 1, Birthday.Month, Birthday.Year);

            return (int)(nextBirthdayDate - Birthday).TotalDays;
        }

        /// <summary>
        /// Calculates age of animal based on birthday and current date
        /// </summary>
        /// <returns></returns>
        private int CalculateAge()
        {
            var now = DateTime.UtcNow;

            // We return the years that passed between birthday and current date.
            // This check makes sure a full year has passed in the overlap between current date and birthday
            if (now.Month > Birthday.Month ||
                now.Month == Birthday.Month &&
                now.Day >= Birthday.Day)
                return now.Year - Birthday.Year;

            // We return the amount of years minus one since a
            // full year hasn't passed in the current year
            return now.Year - Birthday.Year - 1;
        }
    }
}