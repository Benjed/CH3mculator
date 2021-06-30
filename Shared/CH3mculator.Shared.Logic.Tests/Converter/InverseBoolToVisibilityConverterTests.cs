using System;
using System.Windows;
using CH3mculator.Shared.Logic.Converter;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CH3mculator.Shared.Logic.Tests
{
    [TestClass]
    public class InverseBoolToVisibilityConverterTests
    {
        [TestMethod]
        public void Initialize()
        {
            new InverseBoolToVisibilityConverter();
        }

        [TestMethod]
        [DataRow(true, Visibility.Collapsed)]
        [DataRow(false, Visibility.Visible)]
        [DataRow(null, Visibility.Visible)]
        [DataRow("RandomText", Visibility.Visible)]
        [DataRow(1, Visibility.Visible)]
        [DataRow(0, Visibility.Visible)]
        public void ConvertTests(object value, Visibility expectedResult)
        {
            var sut = new InverseBoolToVisibilityConverter();

            var result = sut.Convert(value, typeof(Visibility), null, null);

            Assert.AreEqual(result, expectedResult);
        }

        [TestMethod]
        [DataRow(Visibility.Collapsed, true)]
        [DataRow(Visibility.Visible, false)]
        [DataRow(Visibility.Hidden, true)]
        [DataRow(null, true)]
        [DataRow("RandomText", true)]
        [DataRow(0, true)]
        [DataRow(1, true)]
        public void ConvertBackTests(object value, bool expectedResult)
        {
            var sut = new InverseBoolToVisibilityConverter();

            var result = sut.ConvertBack(value, typeof(bool), null, null);

            Assert.AreEqual(result, expectedResult);
        }
    }
}
