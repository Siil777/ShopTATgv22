﻿using System.Reflection.Metadata.Ecma335;

namespace Shop.Models.Spaceship
{
    public class SpaceshipsCreateViewModel
    {
        public Guid? Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }

        public int Passangers { get; set; }

        public int EnginPower { get; set; }

        public int Crew { get; set; }

        

        public string Company { get; set; }

        public int CargoWeight { get; set; }
    }
}
