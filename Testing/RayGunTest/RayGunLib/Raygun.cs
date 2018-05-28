namespace RayGunLib {
    public class Raygun {
        public Raygun () { }
        private int ammo = 3;

        public void FireAt (Bug bug) {
            if (HasAmmo ()) {
                if (bug.IsDodging ()) {
                    bug.Miss ();
                } else {
                    bug.Hit ();
                }
                ammo--;
            }
        }

        public void Recharge () {
            ammo = 3;
        }

        public bool HasAmmo () {
            return ammo > 0;
        }
    }
}