using WebApplicationTest1.Models;

namespace WebApplicationTest1.Services
{
    public interface IPersonService
    {
        Task<List<Person>> GetPeople();
        Task<Person> GetPersonById(int id);
        Task<Person> CreatePerson(Person person);
        Task<Person> UpdatePerson(int id, Person person);
        Task<bool> DeletePerson(int id);
    }
}
