namespace RobotService
{
    using RobotService.Models.Procedures.Contracts;
    using RobotService.Models.Robots.Contracts;
    using System.Collections.Generic;
    using System.Linq;

    public abstract class Procedure : IProcedure
    {
        private List<IRobot> robots;

        public IReadOnlyCollection<IRobot> Robots => robots;

        public void DoService(IRobot robot, int procedureTime)
        {
            throw new System.NotImplementedException();
        }

        public string History()
        {
            throw new System.NotImplementedException();
        }
    }
}
