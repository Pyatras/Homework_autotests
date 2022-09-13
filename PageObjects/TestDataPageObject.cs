namespace TestProject1212.PageObjects
{
    public class TestDataPageObject
    {
        public static string _username = "torquemada71@protonmail.com";
        public static string _password = "ss1236ss";
        public static string _wrongPassword = "abcdefg";
        public static string _wrongEmail = "123456@protnmail.com";
        public const string _key = "7acf0637949ec8a55a769ae099b710df";
        public const string _token = "1ebedf68aff3cf95c34648ab36a56d3dda9c002b2dead31c4c0c2d1b8a9ec024";
        public const string _boardName = "TestBoard";
        public const string _url2 = $"https://api.trello.com/1/boards/?key={_key}&token={_token}&name={_boardName}";
        public const string _expectedLogin2 = "Pyatras";
    }
}
