using System;
using Xunit;

namespace PrimeService.Tests {
    [AttributeUsage (AttributeTargets.Method, AllowMultiple = false)]
    public class TestPriorityAttribute : Attribute {
        public TestPriorityAttribute (int priority) {
            Priority = priority;
        }

        public int Priority { get; private set; }
    }
    public class PrimeService_IsPrimeShould {
        private readonly PrimeService _primeService;

        public PrimeService_IsPrimeShould () {
            _primeService = new PrimeService ();
        }

        #region Sample_TestCode
        [Trait ("Priority", "2")]
        [Theory]
        [InlineData (-1)]
        [InlineData (0)]
        [InlineData (1)]

        public void ReturnFalseGivenValuesLessThan2 (int value) {
            var result = _primeService.IsPrime (value);

            Assert.False (result, $"{value} should not be prime");
        }
        #endregion

        [Theory]
        [InlineData (2)]
        [InlineData (3)]
        [InlineData (5)]
        [InlineData (7)]
        [Trait ("Category", "bvt")]
        [Trait("Category", "SkipWhenLiveUnitTesting")]
        [Trait ("Priority", "3")]
        public void ReturnTrueGivenPrimesLessThan10 (int value) {
            var result = _primeService.IsPrime (value);

            Assert.True (result, $"{value} should be prime");
        }

        [Theory]
        [InlineData (4)]
        [InlineData (6)]
        [InlineData (8)]
        [InlineData (9)]
        [Trait ("Category", "Nightly")]
        [Trait ("Priority", "1")]
        public void ReturnFalseGivenNonPrimesLessThan10 (int value) {
            var result = _primeService.IsPrime (value);

            Assert.False (result, $"{value} should not be prime");
        }
    }
}