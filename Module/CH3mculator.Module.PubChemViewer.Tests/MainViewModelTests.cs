using System;
using CH3mculator.Module.PubChemViewer;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CH3mculator.Module.PubChemViewer.Tests
{
    [TestClass]
    public class MainViewModelTests
    {
        [TestMethod]
        public void Initialize()
        {
            new MainViewModel();
        }
    }
}