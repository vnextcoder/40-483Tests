using System;
using System.Collections.Generic;
namespace IEquatablePerson {
    public class Person : IEquatable<Person>, ICloneable {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public Person Manager { get; set; }
        public bool Equals (Person other) {
            return (FirstName == other.FirstName && LastName == other.LastName && Manager == other.Manager);
        }
        public override string ToString () {
            return FirstName + " " + LastName + (Manager != null? " reporting " + Manager.ToString (): "");
        }
        public object Clone () {

            Person newperson = new Person ();
            newperson.FirstName = this.FirstName;
            newperson.LastName = this.LastName;
            if (Manager != null) {
                newperson.Manager = (Person) this.Manager.Clone ();
            }
            return newperson;
        }
    }

    public class Person2 {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}