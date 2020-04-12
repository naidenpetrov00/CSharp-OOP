namespace CounterStrike.Models.Guns
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Rifle : Gun
    {
        private const int gunStrikeCount = 10;

        public Rifle(string name, int bulletsCount)
            : base(name, bulletsCount) { }

        public override int Fire()
        {
            if (this.BulletsCount == 0)
            {
                return 0;
            }
            if (this.BulletsCount - gunStrikeCount <= 0 )
            {
                return 0;
            }

            this.BulletsCount -= gunStrikeCount;

            return gunStrikeCount;
        }
    }
}
