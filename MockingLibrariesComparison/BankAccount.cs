using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MockingLibrariesComparison
{
    public interface IBankAccount
    {
        string CustomerName { get; }
        double Balance { get; }
        double GetBalance();
        double Debit(double amount);
       // double Credit(double amount);    //metoda prywatna do testow
    }

    public class BankAccount : IBankAccount
    {
        private string m_customerName;
        private double m_balance;
        private bool m_frozen = false;

        public BankAccount()
        {
        }

        public BankAccount(string customerName, double balance)
        {
            m_customerName = customerName;
            m_balance = balance;
        }

        public string CustomerName
        {
            get { return m_customerName; }
        }

        public double Balance
        {
            get { return m_balance; }
        }

        public virtual double GetBalance()
        {
            return m_balance;
        }

        public double Debit(double amount)
        {
            if (m_frozen)
            {
                throw new Exception("Account frozen");
            }

            if (amount > m_balance)
            {
                throw new ArgumentOutOfRangeException("amount");
            }

            if (amount < 0)
            {
                throw new ArgumentOutOfRangeException("amount");
            }
            
            m_balance += amount; // intentionally incorrect code

            return m_balance;
        }

        public virtual double Credit(double amount)
        {
            if (m_frozen)
            {
                throw new Exception("Account frozen");
            }

            if (amount < 0)
            {
                throw new ArgumentOutOfRangeException("amount");
            }

            m_balance += amount;
            return m_balance;
        }

        private void FreezeAccount()
        {
            m_frozen = true;
        }

        private void UnfreezeAccount()
        {
            m_frozen = false;
        }
    }
}
