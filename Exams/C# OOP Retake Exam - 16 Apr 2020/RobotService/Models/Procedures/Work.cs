namespace RobotService.Models.Procedures
{
    using RobotService.Models.Robots.Contracts;

    public class Work : Procedure
    {
        private const int IncreaserOfHappiness = 12;
        private const int ReductionOfEnergy = 6;

        public override void DoService(IRobot robot, int procedureTime)
        {
            robot.Happiness += IncreaserOfHappiness;
            robot.Energy -= ReductionOfEnergy;

            ProcedureTimeRemover(robot, procedureTime);
        }
    }
}
