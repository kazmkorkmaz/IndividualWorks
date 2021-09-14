using System;

namespace AjaxÖrnek.Models
{
    public class Car
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public override string ToString()
        {
            return String.Format($"Car:Id: {Id} Name: {Name} Description {Description}");
        }
    }
}