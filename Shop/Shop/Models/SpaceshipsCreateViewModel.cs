using System.Reflection.Metadata.Ecma335;

namespace Shop.Models
{
    public class SpaceshipsCreateViewModel
    {
        public Guid? Id { get; set; } 
        public string Name { get; set; } 
        public string Type { get; set; }    

        public int Passangers { get; set; } 

        public int EnginPower { get; set; } 

        public string FuelType { get; set; }

        public int FuelCapacity { get; set; }

        public string Company { get; set; } 
    }
}
