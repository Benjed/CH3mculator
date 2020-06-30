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

        [TestMethod]
        public void ExecuteSearchCommand_Activates_Loading()
        {
            var sut = new MainViewModel();
            using (var sutMonitor = sut.Monitor())
            {
                sut.ExecuteSearchCommand.Execute("Oxygen");

                sutMonitor.Should().RaisePropertyChangeFor(x => x.IsLoading);
            }
        }
    }
}