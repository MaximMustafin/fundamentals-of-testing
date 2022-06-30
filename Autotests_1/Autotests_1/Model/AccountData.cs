namespace Autotests_1
{
    public class AccountData
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public AccountData(string Username, string Password) 
        {
            this.Username = Username;
            this.Password = Password;
        }
    }
}
