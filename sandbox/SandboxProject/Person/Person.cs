using System;
namespace SandboxProject
{
    public class Person
    {
        protected string firstName = "";
        protected string lastName = "";

        public string GetFirstName()
        {
            return firstName;
        }
        public void SetFirstName(string firstName_)
        {
            firstName = firstName_;
        }
         public string GetLasttName()
        {
            return firstName;
        }
        public void SetLastName(string lastName_)
        {
            lastName = lastName_;
        }

        public string GetPeopleNames()
        {
            return $"First Name: {firstName} Last Name: {lastName}";
        }
    }
}