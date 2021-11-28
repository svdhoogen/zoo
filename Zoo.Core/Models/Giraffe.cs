namespace Zoo.Core.Models
{
    public class Giraffe : Animal
    {
        public Giraffe() : base("Giraffa") { }

        public int NeckLengthInCm { get; set; }
    }
}