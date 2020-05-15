namespace RobotService.Models.Procedures
{
    using RobotService.Models.Robots.Contracts;

    public class Rest : Procedure
    {
        private const int ReductionOfHappiness = 3;
        private const int IncreaserOfEnergy = 10;

        public override void DoService(IRobot robot, int procedureTime)
        {
            robot.Happiness -= ReductionOfHappiness;
            robot.Energy += IncreaserOfEnergy;

            ProcedureTimeRemover(robot, procedureTime);
        }
    }
}
