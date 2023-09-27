﻿namespace Shop.Models.Spaceship
{
    public class SpaceshipDetailsViewModel
    {
        public Guid? Id { get; set; }

        public string Name { get; set; }

        public string Type { get; set; }

        public int Passangers { get; set; }

        public int EnginPower { get; set; }

        public int Crew { get; set; }

        public string Company { get; set; }

        public int CargoWeight { get; set; }



        //only in database

        public DateTime CreatedAt { get; set; }

        public DateTime Modifieted { get; set; }
    }
}