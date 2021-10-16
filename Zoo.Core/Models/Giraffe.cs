using System;
using Zoo.Core.Enums;

namespace Zoo.Core.Models
{
    public class Giraffe : Animal
    {
        public Giraffe(Gender gender, DateTime birthday) : base("Giraffa", gender, birthday) { }

        public int NeckLengthInCm { get; set; }
    }
}