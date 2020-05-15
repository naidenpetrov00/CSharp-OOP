namespace RobotService.Models.Procedures
{
    using RobotService.Models.Robots.Contracts;

    public class Charge : Procedure
    {
        private const int IncreaserOfHappiness = 12;
        private const int IncreaserOfEnergy = 10;

        public override void DoService(IRobot robot, int procedureTime)
        {
            robot.Happiness += IncreaserOfHappiness;
            robot.Energy += IncreaserOfEnergy;

            ProcedureTimeRemover(robot, procedureTime);
        }
    }
}
