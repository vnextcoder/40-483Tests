using System;

class Person
{
    public string FirstName { get; set; }
    public string LastName { get; set; }

public Person(string firstname)
    {
        if (string.IsNullOrEmpty(firstname) )
        {
            throw new ArgumentOutOfRangeException("firstname", firstname, "fistname is either null or empty");

        }
    this.FirstName=firstname;
     

    }
    public Person(string firstname, string lastname):this(firstname)
    {
        if (string.IsNullOrEmpty(lastname)){
            throw new ArgumentOutOfRangeException("lastname", lastname, "lastname is either null or empty");
        }
        
        this.LastName=lastname;

    }
}