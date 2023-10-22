using Bank;

namespace BankAccountTests
{
    public class BankAccountTests
    {
        [SetUp]
        public void Setup()
        {
        }


        [Test]
        public void Test_BankAccount()
        {
            var bank = new BankAccount(1000);
            Assert.That(bank, Is.Not.Null);
            Assert.That(1000, Is.EqualTo(bank.Amount));
        }

        [Test]
        public void Test_Try_Less_Than_Zero()
        {
            Assert.That(() => new BankAccount(-1000), Throws.ArgumentException);
        }

        [Test]
        public void Test_Deposit()
        {
            var bank = new BankAccount(1000);
            bank.Deposit(100);
            Assert.That(1100, Is.EqualTo(bank.Amount));
        }

        [Test]
        public void Test_Try_Deposit_Negative()
        {
            var bank = new BankAccount(1000);
            Assert.That(() => bank.Deposit(-100), Throws.ArgumentException);
        }

        [Test]
        public void Test_Try_Deposit_Zero()
        {
            var bank = new BankAccount(1000);
            Assert.That(() => bank.Deposit(0), Throws.ArgumentException);
        }

        [Test]
        public void Test_Try_Withd_More_Than_Count()
        {
            var bank = new BankAccount(1000);
            bank.Deposit(100);
            Assert.That(() => bank.Withdraw(1100), Throws.ArgumentException);
        }

        [Test]
        public void Test_Try_With_Zero_Value()
        {
            var bank = new BankAccount(1000);
            bank.Deposit(100);
            Assert.That(() => bank.Withdraw(0), Throws.ArgumentException);
        }

        [Test]
        public void Test_Try_WithdNegative()
        {
            var bank = new BankAccount(1000);
            bank.Deposit(100);
            Assert.That(() => bank.Withdraw(-100), Throws.ArgumentException);
        }

        [Test]
        public void Test_With_Sum_Less()
        {
            var bank = new BankAccount(1000);
            bank.Deposit(100);
            bank.Withdraw(100);
            Assert.That(998, Is.EqualTo(bank.Amount));
        }

        [Test]
        public void Test_Withd_Sum_Equal_1000()
        {
            var bank = new BankAccount(1000);
            bank.Deposit(1000);
            bank.Withdraw(1000);
            Assert.That(980, Is.EqualTo(bank.Amount));
        }

        [Test]
        public void Test_Withd_Sum_More_1000()
        {
            var bank = new BankAccount(1000);
            bank.Deposit(1000);
            bank.Withdraw(1100);
            Assert.That(845, Is.EqualTo(bank.Amount));
        }

    }
}