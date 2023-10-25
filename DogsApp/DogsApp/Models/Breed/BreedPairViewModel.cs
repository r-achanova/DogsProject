using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace DogsApp.Models.Breed
{
    public class BreedPairViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Breed")]
        public string Name { get; set; } = null!;
    }
}
