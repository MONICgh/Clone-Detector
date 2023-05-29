namespace task3
{
    struct Employee
    {
        public string name;
        public string surname;
        public DateTime dateOfBirth; 

        public Employee(string eName, string eSurname, DateTime eDateOfBirth)
        {
            name = eName;
            surname = eSurname; 
            dateOfBirth = eDateOfBirth;
        }
        public int GetAge()
        {
            DateTime curDate = DateTime.Now;
            return curDate.Year - dateOfBirth.Year - 1 +
        ((curDate.Month > dateOfBirth.Month || curDate.Month == dateOfBirth.Month && curDate.Day >= dateOfBirth.Day) ? 1 : 0);
        }

        public float GetSalary()
        {
            return 0;
        }
    }
}
