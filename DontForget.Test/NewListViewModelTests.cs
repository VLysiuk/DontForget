using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caliburn.Micro;
using DontForget.ViewModels;
using NFluent;
using NSubstitute;
using NUnit.Framework;

namespace DontForget.Test
{
    [TestFixture]
    public class NewListViewModelTests
    {
        [Test]
        public void ShouldNotAcceptNewListWhenNameIsEmpty()
        {
            var navigationService = Substitute.For<INavigationService>();
            var viewModel = new NewListViewModel(navigationService);

            viewModel.ListName = string.Empty;

            Check.That(viewModel.CanAccept).IsFalse();
        }

        [Test]
        public void ShouldAcceptNewListWhenNameIsNotEmpty()
        {
            var navigationService = Substitute.For<INavigationService>();
            var viewModel = new NewListViewModel(navigationService);

            viewModel.ListName = "some name";

            Check.That(viewModel.CanAccept).IsTrue();
        }

        [Test]
        public void ShouldGoBackWhenCancel()
        {
            var navigationService = Substitute.For<INavigationService>();
            var viewModel = new NewListViewModel(navigationService);

            viewModel.Cancel();

            navigationService.Received().GoBack();
        }
    }
}
