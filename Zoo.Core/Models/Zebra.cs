namespace Zoo.Core.Models
{
    public class Zebra : Animal
    {
        /// <summary>
        /// Sets stripes
        /// </summary>
        public Zebra() : base("Equus quagga") { }

        public int Stripes { get; init; }
    }
}