namespace RobotService
{
    using RobotService.Models.Procedures.Contracts;
    using RobotService.Models.Robots;
    using RobotService.Models.Robots.Contracts;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public abstract class Procedure : IProcedure
    {
        private readonly List<IRobot> robots;

        public Procedure()
        {
            this.robots = new List<IRobot>();
        }

        public IReadOnlyCollection<IRobot> Robots => robots;

        public abstract void DoService(IRobot robot, int procedureTime);

        public string History()
        {
            var sb = new StringBuilder();

            sb.AppendLine(this.GetType().Name);

            foreach (var robot in this.Robots)
            {
                sb.AppendLine
                    (string.Format($" Robot type: {0} - {1} - Happiness: {2} - Energy: {3}"
                    , robot.GetType().Name
                    , robot.Name
                    , robot.Happiness
                    , robot.Energy)
                    );
            }

            return sb.ToString().Trim();
        }
    }
}
