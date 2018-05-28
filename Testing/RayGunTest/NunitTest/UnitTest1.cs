using NUnit.Framework;
using RayGunLib;
namespace Tests {

    [TestFixture]
    public class Tests {
        Bug bug;
        Raygun gun;
        [SetUp]
        public void Setup () {
            bug = new Bug ();
            gun = new Raygun ();
        }

        // [Test]
        // public void Test1 () {
        //     Assert.Pass ();
        // }

        [Test]
        [TestCase(1)]
        [TestCase(2)]
        [TestCase(10)]
        public void TryShootDodgingBug () {

            bug.Dodge ();
            gun.FireAt (bug);
            

            bug.Dodge ();
            gun.FireAt (bug);

            bug.Dodge ();
            gun.FireAt (bug);

            Assert.IsFalse (bug.IsDead ());
            Assert.IsFalse (gun.HasAmmo ());
        }
    }
}