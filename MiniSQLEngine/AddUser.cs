﻿namespace MiniSQLEngine
{
    internal class AddUser : MiniSQL
    {
        private string value1;
        private string value2;
        private string value3;

        public AddUser(string value1, string value2, string value3)
        {
            this.value1 = value1;
            this.value2 = value2;
            this.value3 = value3;
        }
    }
}