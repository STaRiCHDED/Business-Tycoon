namespace Models
{
    public class PlayerBalanceModel
    {
        public int Balance { get; set; }
        public PlayerBalanceModel(int balance)
        {
            Balance = balance;
        }
    }
}