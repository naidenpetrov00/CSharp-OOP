namespace CounterStrike
{
    using CounterStrike.Models.Maps.Contracts;
    using CounterStrike.Models.Players;
    using CounterStrike.Models.Players.Contracts;
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Map : IMap
    {
        private List<Terrorist> terrorists;
        private List<CounterTerrorist> counterTerrorists;

        public Map()
        {
            this.terrorists = new List<Terrorist>();
            this.counterTerrorists = new List<CounterTerrorist>();
        }

        public string Start(ICollection<IPlayer> players)
        {
            var allCounterTerroristsAreDead = true;
            var allTerroristsAreDead = true;

            foreach (var player in players)
            {
                if (player.GetType().Name == "Terrorist")
                {
                    this.terrorists.Add((Terrorist)player);
                }
                else if (player.GetType().Name == "CounterTerrorist")
                {
                    this.counterTerrorists.Add((CounterTerrorist)player);
                }
            }

            while (true)
            {
                allCounterTerroristsAreDead = true;
                allTerroristsAreDead = true;

                foreach (var terrorist in this.terrorists)
                {
                    if (terrorist.IsAlive)
                    {
                        allTerroristsAreDead = false;
                        break;
                    }
                }
                if (allTerroristsAreDead)
                {
                    break;
                }
                foreach (var counterTerrorist in this.counterTerrorists)
                {
                    if (counterTerrorist.IsAlive)
                    {
                        allCounterTerroristsAreDead = false;
                        break;
                    }
                }
                if (allCounterTerroristsAreDead)
                {
                    break;
                }

                var tPoints = 0;
                foreach (var item in terrorists)
                {
                    if (item.IsAlive)
                    {
                        tPoints += item.Gun.Fire();
                    }
                }
                foreach (var item in counterTerrorists)
                {
                    if (item.IsAlive)
                    {
                        item.TakeDamage(tPoints);
                    }
                }

                var cPoints = 0;
                foreach (var item in counterTerrorists)
                {
                    if (item.IsAlive)
                    {
                        cPoints += item.Gun.Fire();
                    }
                }
                foreach (var item in terrorists)
                {
                    if (item.IsAlive)
                    {
                        item.TakeDamage(cPoints);
                    }
                }

                //foreach (var terrorist in this.terrorists)
                //{
                //    if (terrorist.IsAlive)
                //    {
                //        foreach (var counterTerrorist in this.counterTerrorists)
                //        {
                //            if (counterTerrorist.IsAlive)
                //            {
                //                counterTerrorist.TakeDamage(terrorist.Gun.Fire());
                //            }
                //        }
                //    }
                //}
                //foreach (var counterTerrorist in this.counterTerrorists)
                //{
                //    if (counterTerrorist.IsAlive)
                //    {
                //        foreach (var terrorist in this.terrorists)
                //        {
                //            if (terrorist.IsAlive)
                //            {
                //                terrorist.TakeDamage(counterTerrorist.Gun.Fire());
                //            }
                //        }
                //    }
                //}
            }
            if (allTerroristsAreDead)
            {
                return "Counter Terrorist wins!";
            }
            else if (allCounterTerroristsAreDead)
            {
                return "Terrorist wins!";
            }

            return "No one wins!Problem";
        }
    }
}