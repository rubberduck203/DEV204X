namespace Module9
{
    internal class Student
    {
        internal string FistName { get; set; }
        internal string LastName { get; set; }
        internal string City { get; set; }

        internal Student(string first, string last, string city)
        {
            this.FistName = first;
            this.LastName = last;
            this.City = city;
        }
    }
}
