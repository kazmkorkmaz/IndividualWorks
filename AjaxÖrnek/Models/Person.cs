using System;

namespace AjaxÖrnek.Models
{
    public class Person
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int CarId { get; set; }
            public override string ToString()
        {
            return String.Format($"Car:Id: {Id} Name: {Name} CarId {CarId}");
        }
    }
}