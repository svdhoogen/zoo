namespace Zoo.Core.Models
{
    public class Zebra : Animal
    {
        public Zebra() : base("Equus quagga") { }

        public int Stripes { get; set; }
    }
}