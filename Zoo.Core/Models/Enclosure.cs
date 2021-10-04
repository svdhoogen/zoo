using System.Collections.Generic;

namespace Zoo.Core.Models
{
    public class Enclosure
    {
        public string Name { get; set; }

        public List<Animal> Animals { get; set; }
    }
}