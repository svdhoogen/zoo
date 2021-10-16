using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Zoo.Core.Models
{
    public class Enclosure
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public Enclosure()
        {
            _animals = new List<Animal>();
        }

        private string _name;
        public string Name
        {
            get => _name;
            set => _name = value;
        }

        private List<Animal> _animals;

        /// <summary>
        /// Adds an animal
        /// </summary>
        /// <param name="animal"></param>
        public void AddAnimal(Animal animal) => _animals.Add(animal);

        /// <summary>
        /// Removes an animal
        /// </summary>
        /// <param name="animal"></param>
        public void RemoveAnimal(Animal animal) => _animals.Remove(animal);

        /// <summary>
        /// Returns all animals in enclosure
        /// </summary>
        /// <returns></returns>
        public ReadOnlyCollection<Animal> GetAnimals() => new ReadOnlyCollection<Animal>(_animals);
    }
}