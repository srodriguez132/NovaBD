namespace MiniSQLEngine
{
    internal class DropSecurity : MiniSQL
    {
        private string value;

        public DropSecurity(string value)
        {
            this.value = value;
        }
    }
}