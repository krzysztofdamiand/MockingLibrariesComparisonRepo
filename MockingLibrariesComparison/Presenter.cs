using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MockingLibrariesComparison
{
    public interface IView
    {
        
    }

    public class CustomerPresenter
    {
        public bool IsViewInjected = false; 
        private IView View { get; set; }
        private IBankAccount Account { get; set; }
        private BankAccount AccountConcrete { get; set; }

        public CustomerPresenter(IView view, IBankAccount bankaccount)
        {
            View = view;
            Account = bankaccount;
            AccountConcrete = bankaccount as BankAccount;
            IsViewInjected = true;
        }

        public double DebitCustomerAccount(double amount)
        {
            return Account.Debit(amount);
        }

        public double CreditCustomerAccount(double amount)
        {
            return AccountConcrete.Credit(amount);
        }
    }
}
