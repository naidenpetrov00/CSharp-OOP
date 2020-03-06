namespace PersonsInfo
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Team
    {
        private string name;
        private List<Person> firstTeam;
        private List<Person> reserveTeam; 

        public Team(string name)
        {
            this.name = name;
            this.firstTeam = new List<Person>();
            this.reserveTeam = new List<Person>();
        }

        public IReadOnlyList<Person> FirstTeam
        {
            get { return this.firstTeam; }
            private set { this.firstTeam = (List<Person>)value; }
        }

        public IReadOnlyList<Person> ReserveTeam
        {
            get { return this.reserveTeam; }
            private set { this.reserveTeam = (List<Person>)value; }
        }

        public void AddPlayer(Person person)
        {

            if (person.Age < 40)
            {
                this.firstTeam.Add(person);
            }
            else
            {
                this.reserveTeam.Add(person);
            }
        }

        public override string ToString()
        {
            var output = new StringBuilder();
            output.AppendLine($"First team has {this.FirstTeam.Count} players.");
            output.AppendLine($"Reserve team has {this.ReserveTeam.Count} players.");

            return output.ToString().Trim();
        }
    }
}
