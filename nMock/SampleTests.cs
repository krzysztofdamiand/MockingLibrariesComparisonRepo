using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NMock;
using MockingLibrariesComparison;
using NSubstitute;
using FakeItEasy;
using Moq;

namespace nMock
{
    [TestClass]
    public class SampleTests
    {
        private NMock.MockFactory _factory;

        public SampleTests()
        {         
            
        }

        [TestInitialize]
        public void TestInitialize()
        {
            
        }

        [TestMethod]
        public void UnitTest_NSubstitute()
        {
            var mockBankAccount = Substitute.For<IBankAccount>();
            var mockView = Substitute.For<IView>();
            var presenter = new CustomerPresenter(mockView, mockBankAccount);

            mockBankAccount.Debit(10).Returns(100);
            var result = presenter.DebitCustomerAccount(10);

            Assert.AreEqual(100, result);
            Assert.IsTrue(typeof(IBankAccount).IsInstanceOfType(mockBankAccount));
        }

        [TestMethod]
        public void UnitTest_Moq()
        {
            var mockBankAccount = new Moq.Mock<IBankAccount>();
            var mockView = new Moq.Mock<IView>();

            mockBankAccount.Setup(e => e.Debit(10))
                .Returns(100);

            var presenter = new CustomerPresenter(mockView.Object, mockBankAccount.Object);
            var result = presenter.DebitCustomerAccount(10);

            Assert.AreEqual(100, result);
            Assert.IsTrue(typeof(IBankAccount).IsInstanceOfType(mockBankAccount.Object));
        }

        [TestMethod]
        public void UnitTest_NMock3()
        {
            _factory = new NMock.MockFactory();
            var mockBankAccount = _factory.CreateMock<IBankAccount>();
            var mockView = _factory.CreateMock<IView>();
           
            mockBankAccount.Expects.One.MethodWith(_ => _.Debit(10))             
                .WillReturn(100);

            var presenter = new CustomerPresenter(mockView.MockObject, mockBankAccount.MockObject);
            var result = presenter.DebitCustomerAccount(10);            

            Assert.AreEqual(100, result);
            Assert.IsTrue(typeof(IBankAccount).IsInstanceOfType(mockBankAccount.MockObject));
        }

        [TestMethod]
        public void UnitTest_FakeItEasy()
        {
            var mockBankAccount = A.Fake<IBankAccount>();
            var mockView = A.Fake<IView>();
            var presenter = new CustomerPresenter(mockView, mockBankAccount);

            A.CallTo(() => mockBankAccount.Debit(10)).Returns(100);
            var result = presenter.DebitCustomerAccount(10);
            
            Assert.AreEqual(100, result);
            Assert.IsTrue(typeof(IBankAccount).IsInstanceOfType(mockBankAccount));
        }

           

        //*****************************************************************************
        //TESTY METOD PRYWATNYCH
        //mokujemy teraz klasę nie interfejs
        //*****************************************************************************


        [TestMethod]
        public void UnitTest_NMock3_Concrete()
        {
            _factory = new NMock.MockFactory();
            var mockBankAccount = _factory.CreateMock<BankAccount>();
            var mockView = _factory.CreateMock<IView>();

            //nie da sie bo prywatna
            //mockBankAccount.Expects.One.MethodWith(_ => _.Credit(10))
            //    .WillReturn(100);

            mockBankAccount.Expects.One.MethodWith(_ => _.Credit(10))
                .WillReturn(100);

            var presenter = new CustomerPresenter(mockView.MockObject, mockBankAccount.MockObject);
            var result = presenter.CreditCustomerAccount(10);

            Assert.AreEqual(100, result);
            Assert.IsTrue(typeof(IBankAccount).IsInstanceOfType(mockBankAccount.MockObject));
        }

        [TestMethod]
        public void UnitTest_FakeItEasy_Concrete()
        {
            var mockBankAccount = A.Fake<BankAccount>();
            var mockView = A.Fake<IView>();
            var presenter = new CustomerPresenter(mockView, mockBankAccount);

            A.CallTo(() => mockBankAccount.Credit(10)).Returns(100);
            var result = presenter.CreditCustomerAccount(10);

            Assert.AreEqual(100, result);
            Assert.IsTrue(typeof(IBankAccount).IsInstanceOfType(mockBankAccount));
        }

        [TestMethod]
        public void UnitTest_Moq_Concrete()
        {
            var mockBankAccount = new Moq.Mock<BankAccount>();
            var mockView = new Moq.Mock<IView>();

            mockBankAccount.Setup(e => e.Credit(10))
                .Returns(100);

            var presenter = new CustomerPresenter(mockView.Object, mockBankAccount.Object);
            var result = presenter.CreditCustomerAccount(10);

            Assert.AreEqual(100, result);
            Assert.IsTrue(typeof(IBankAccount).IsInstanceOfType(mockBankAccount.Object));
        }


        [TestMethod]
        public void UnitTest_NSubstitute_Concrete()
        {
            var mockBankAccount = Substitute.For<BankAccount>();
            var mockView = Substitute.For<IView>();
            var presenter = new CustomerPresenter(mockView, mockBankAccount);

            mockBankAccount.Credit(10).Returns(100);
            var result = presenter.CreditCustomerAccount(10);

            Assert.AreEqual(100, result);
            Assert.IsTrue(typeof(IBankAccount).IsInstanceOfType(mockBankAccount));
        }

    }
}
