namespace EmployeeList_2._0
{
    public class CheckTextString
    {
        private string text;

        public CheckTextString(string text)
        {
            this.text = text;
        }

        public bool CheckText()
        {
            if (string.IsNullOrWhiteSpace(text) || text.Length > Program.numOfLetter)
                return false;
            else
                return true;
        }
    }
}
