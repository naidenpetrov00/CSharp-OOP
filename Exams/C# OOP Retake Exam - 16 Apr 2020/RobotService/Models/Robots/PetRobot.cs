﻿namespace RobotService.Models.Robots
{
    class PetRobot : Robot
    {
        public PetRobot(string name, int energy, int happiness, int procedureTime)
            : base(name, energy, happiness, procedureTime) { }
    }
}
