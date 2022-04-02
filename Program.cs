using System;
namespace creditcard
{
    class Savings
    {
        int balance = 10000;
        Credit x;
        public Savings(Credit x)
        {
            this.x = x;
        }
        public void Deductmoney()
        {
            if (x.Isrepayment() == 1)
            {
                balance = balance - x.Torepayment();
                Console.WriteLine("还款成功，你的余额为:{0}", balance);
            }
            else
            {
                Console.WriteLine("暂时不需要还款，你的余额为:{0}", balance);
            }
        }
    }

    class Credit
    {
        int repaydate = 28;
        int torepayment;
        int repaymentday;
        public Credit(int repayment, int repayday)
        {
            this.torepayment = repayment;
            this.repaymentday = repayday;
        }
        public int Torepayment()
        {
            return torepayment;
        }
        public int Isrepayment()
        {
            if (repaydate == repaymentday)
                return 1;
            else
                return 0;
        }
    }
    class Delegate
    {
        public delegate void pay();
        public event pay payment;
        public void Notify()
        {
            if (payment != null)
            {
                Console.WriteLine("触发事件：");
                payment();
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Delegate objDelegate = new Delegate();
            Credit x1 = new Credit(1000, 27);
            Credit x2 = new Credit(1250, 28);
            Savings c1 = new Savings(x1);
            Savings c2 = new Savings(x2);
            objDelegate.payment +=
                new Delegate.pay(c1.Deductmoney);
            objDelegate.payment +=
               new Delegate.pay(c2.Deductmoney);
            objDelegate.Notify();
        }
    }
}