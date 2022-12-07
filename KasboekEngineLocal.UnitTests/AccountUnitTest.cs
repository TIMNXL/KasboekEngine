using Shouldly;

namespace KasboekEngineBackend.UnitTests
{
    public class AccountUnitTest
    {
        [Fact]
        public void Account_ReceivesNameUserAndInitialBalance_CreatesNewAccount()
        {
            //Arrange, Act
            Account account = new("Tim", 1000m);

            //Assert
            account.Name.ShouldBe("Tim");
            account.InitialBalance.ShouldBe(1000m);
        }
    }
}
