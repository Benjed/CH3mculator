using System;
using CH3mculator.Module.PubChemViewer;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CH3mculator.Shell.Tests
{
    [TestClass]
    public class ShellViewModelTests
    {
        [TestMethod]
        public void Initialize()
        {
            new ShellViewModel();
        }

        [TestMethod]
        public void Shows_PubchemViewer_on_default()
        {
            var sut = new ShellViewModel();

            sut.ShownView.Should().BeOfType(typeof(PubChemViewerMainView));
        }

        [TestMethod]
        public void Resets_PubChemViewer_on_ShowPubChemViewerCommand()
        {
            var sut = new ShellViewModel();
            sut.ShownView = new System.Windows.Controls.UserControl();

            using (var sutMonitor = sut.Monitor())
            {
                sut.ShowPubChemViewerCommand.Execute(null);

                sut.ShownView.Should().BeOfType(typeof(PubChemViewerMainView));
                sutMonitor.Should().RaisePropertyChangeFor(x => x.ShownView);
            }
        }

        [TestMethod]
        public void ShowPubChemViewerCommand_Closes_NavigationDrawer()
        {
            var sut = new ShellViewModel();
            sut.IsNavigationDrawerOpened = true;
            using (var sutMonitor = sut.Monitor())
            {
                sut.ShowPubChemViewerCommand.Execute(null);

                sut.IsNavigationDrawerOpened.Should().BeFalse();
                sutMonitor.Should().RaisePropertyChangeFor(x => x.IsNavigationDrawerOpened);
            }
        }

        [TestMethod]
        public void Shows_current_modulename()
        {
            var sut = new ShellViewModel();
            sut.ShowPubChemViewerCommand.Execute(null);

            Assert.AreEqual(sut.ModuleName, "PubChemViewer");
        }
    }
}