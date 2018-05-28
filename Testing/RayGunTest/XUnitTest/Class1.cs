using System;
using RayGunLib;
using Xunit;
namespace RayGunTest {
    public class Class1 {
        [Fact]
        public void TryShootBug () {

            Bug bug = new Bug ();
            Raygun gun = new Raygun ();

            gun.FireAt (bug);

            Assert.True (bug.IsDead ());
            Assert.True (gun.HasAmmo ());
        }

        [Fact]

        public void TryMakingHeapsOfGuns () {

            Raygun[] guns = new Raygun[5];
            Bug bug = new Bug ();

            Assert.Throws<IndexOutOfRangeException> (() => guns[5].FireAt (bug));

        }

        [Theory]
        [InlineData (true, false)]
        [InlineData (false, true)]
        public void TestBugDodges (bool didDodge, bool shouldBeDead) {

            Bug bug = new Bug ();
            Raygun gun = new Raygun ();

            if (didDodge) {
                bug.Dodge ();
            }

            gun.FireAt (bug);

            if (shouldBeDead) {
                Assert.True (bug.IsDead ());
            } else {
                Assert.False (bug.IsDead ());
            }
        }
    }
}