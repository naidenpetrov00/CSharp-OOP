namespace RobotService.Models.Procedures
{
    using RobotService.Models.Robots.Contracts;

    public class TechCheck : Procedure
    {
        private const int ReductionOfEnergy = 8;

        public override void DoService(IRobot robot, int procedureTime)
        {
            robot.Energy -= ReductionOfEnergy;

            if (robot.IsChecked)
            {
                robot.Energy -= ReductionOfEnergy;
            }
            else
            {
                robot.IsChecked = true;
            }

            ProcedureTimeRemover(robot, procedureTime);
        }
    }
}
