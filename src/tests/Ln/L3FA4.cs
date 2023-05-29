namespace task3
{
    struct Programmer
    {
        private const float baseSalary = 100000;

        private Employee _parent;

        public string name;
        public string surname;
        public DateTime dateOfBirth;

        public Programmer(string pName, string pSurname, DateTime pDateOfBirth)
        {
            name = pName;
            surname = pSurname; 
            dateOfBirth = pDateOfBirth; 
            _parent = new Employee(name, surname, dateOfBirth);
        }

        public int GetAge()
        {
            return _parent.GetAge();
        }

        public float GetSalary() // a-la override
        {
            return baseSalary;
        }
    }
}
