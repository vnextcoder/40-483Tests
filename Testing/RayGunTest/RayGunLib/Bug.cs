namespace RayGunLib {
	public class Bug {
		private bool dodging;
		private bool dead;

		public void Dodge () {
			dodging = true;
		}

		public void Hit () {
			dead = true;
		}

		public void Miss () {
			dodging = false;
		}

		public bool IsDodging () {
			return dodging;
		}

		public bool IsDead () {
			return dead;
		}
	}
}