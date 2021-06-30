using System;
using System.Windows;
using CH3mculator.Shared.Logic.Converter;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CH3mculator.Shared.Logic.Tests
{
    [TestClass]
    public class BoolToVisibilityConverterTests
    {
        [TestMethod]
        public void Initialize()
        {
            new BoolToVisibilityConverter();
        }

        [TestMethod]
        [DataRow(true, Visibility.Visible)]
        [DataRow(false, Visibility.Collapsed)]
        [DataRow(null, Visibility.Collapsed)]
        [DataRow("RandomText", Visibility.Collapsed)]
        [DataRow(1, Visibility.Collapsed)]
        [DataRow(0, Visibility.Collapsed)]
        public void ConvertTests(object value, Visibility expectedResult)
        {
            var sut = new BoolToVisibilityConverter();

            var result = sut.Convert(value, typeof(Visibility), null, null);

            Assert.AreEqual(result, expectedResult);
        }

        [TestMethod]
        [DataRow(Visibility.Collapsed, false)]
        [DataRow(Visibility.Visible, true)]
        [DataRow(Visibility.Hidden, false)]
        [DataRow(null, false)]
        [DataRow("RandomText", false)]
        [DataRow(0, false)]
        [DataRow(1, false)]
        public void ConvertBackTests(object value, bool expectedResult)
        {
            var sut = new BoolToVisibilityConverter();

            var result = sut.ConvertBack(value, typeof(bool), null, null);

            Assert.AreEqual(result, expectedResult);
        }
    }
}
