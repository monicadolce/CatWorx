namespace CatWorx.BadgeMaker
{
    class Employee
    {
        // PascalCase for public variables and camelCase for private variables
        private string FirstName;
        private string LastName;
        private int Id;
        private string PhotoUrl;

        public Employee(string firstName, string lastName, int id, string photoUrl)
        {
            // Use camelCase for the parameters and PascalCase when assigning them to properties.
            FirstName = firstName;
            LastName = lastName;
            Id = id;
            PhotoUrl = photoUrl;

        }

        public string GetFullName()
        {
            return FirstName + " " + LastName;
        }

        public int GetId()
        {
            return Id;
        }

        public string GetPhotoUrl()
        {
            return PhotoUrl;
        }
    }
}