namespace TFWebApi.Data
{
    public class StringFunctions
    {
        public string ConcatenateStrings(string s1, string s2)
        {
            return s1 + s2;
        }

        public bool IsPalindrome(string s)
        {
            string reversed = new string(s.Reverse().ToArray());
            return s.Equals(reversed, StringComparison.OrdinalIgnoreCase);
        }
    }
}
