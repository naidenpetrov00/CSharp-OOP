namespace CounterStrike.Models.Guns
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Pistol : Gun
    {
        private const int gunStrikeCount = 1;
        private bool lastBulletFired = false;

        public Pistol(string name, int bulletsCount)
            : base(name, bulletsCount) { }

        public override int Fire()
        {
            if (this.BulletsCount == 0)
            {
                return 0;
            }
            if (this.BulletsCount - gunStrikeCount == 0 && !lastBulletFired)
            {
                lastBulletFired = true;
                return gunStrikeCount;
            }

            this.BulletsCount -= gunStrikeCount;

            return gunStrikeCount;
        }
    }
}
