using System.Collections.Generic;
using AjaxÖrnek.Models;

namespace AjaxÖrnek.Repository
{
    public class DataProvider
    {
        static List<Car> Cars = new List<Car>()
        {
            new Car{Id=2,Name="Volvo",Description="This is the description of Volvo"},
            new Car{Id=4,Name="Bmw",Description="This is the description of Bmw"},
            new Car{Id=8,Name="Fiat",Description="This is the description of Fiat"},
            new Car{Id=10,Name="Aston Martin",Description="This is the description of Aston Martin"}
        };

            static List<Person> People = new List<Person>()
        {
            new Person{Id=1,Name="Volvo",CarId=2},
            new Person{Id=2,Name="Bmw",CarId=4},
            new Person{Id=3,Name="Fiat",CarId=8},
            new Person{Id=4,Name="Aston Martin",CarId=10}
        };
        static public List<Person> GetPeople(int carId)
        {
            return People.FindAll(a=>a.CarId==carId);
        }
        static public List<Car> GetAllCars()
        {
            return Cars;
        }
    }
}