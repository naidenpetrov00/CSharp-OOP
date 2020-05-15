namespace RobotService.Models.Procedures
{
    using RobotService.Models.Robots.Contracts;

    public class Polish : Procedure
    {
        private const int ReductionOfHappiness = 7;

        public override void DoService(IRobot robot, int procedureTime)
        {
            robot.Happiness -= ReductionOfHappiness;

            ProcedureTimeRemover(robot, procedureTime);
        }
    }
}
