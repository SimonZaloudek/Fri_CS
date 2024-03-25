using CV5__cv4_;

public class Person
{

    private readonly string? _firstName;
    public int Age { get; }
    public DateTime? Birthday { get; set; } 
    public string FullName => $"{FirstName} {LastName}";
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public Gender Gender { get; set; }

    public Person(string pFirstName, DateTime? pBirthday, string pLastName,Gender pGender = Gender.Unknown) 
    {
        Birthday = pBirthday;  
        FirstName = pFirstName;
        LastName = pLastName;
        Gender = pGender;
    }

    public Person() 
    {
    
    }

    public Boolean Equals(Person other) 
    {
        return this.Equals(other);
    }

    public int GetHashCode() 
    {
        return HashCode.Combine(FirstName, LastName); 
    }

    public string ToString()
    {
        string v = Birthday.ToString();
        return v;
    }
}
