using System;
using Zoo.Core.Enums;

namespace Zoo.Core.Models
{
    public class Zebra : Animal
    {
        /// <summary>
        /// Sets stripes
        /// </summary>
        public Zebra(Gender gender, DateTime birthday, int stripes) : base("Equus quagga", gender, birthday)
        {
            Stripes = stripes;
        }

        public int Stripes { get; }
    }
}