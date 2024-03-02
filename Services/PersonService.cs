using Microsoft.EntityFrameworkCore;
using WebApplicationTest1.Data;
using WebApplicationTest1.Models;


namespace WebApplicationTest1.Services
{
    public class PersonService : IPersonService
    {
        private readonly ApplicationDbContext _context;

        public PersonService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Person> CreatePerson(Person person)
        {
            _context.People.Add(person);
            await _context.SaveChangesAsync();
            return person;
        }

        public async Task<bool> DeletePerson(int id)
        {
            var person = _context.People.Find(id);
            if (person == null)
                return false;

            _context.People.Remove(person);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<Person> GetPersonById(int id)
        {
            return await _context.People.FindAsync(id);
        }

        public async Task<List<Person>> GetPeople()
        {
            return await _context.People.ToListAsync();
        }

        public async Task<Person> UpdatePerson(int id, Person person)
        {
            if (id != person.Id)
                throw new ArgumentException("Id MisMatching");

            var PersonData = _context.People.Find(id);

            PersonData.Name = person.Name;
            PersonData.Age = person.Age;

            try
            {
                await _context.SaveChangesAsync();
                return person;
            }
            catch (Exception e)
            {
                if (!CheckIfPersonExists(id))
                {
                    return null;
                }
                else
                {
                    throw;
                }
            }
        }

        private bool CheckIfPersonExists(int id)
        {
            return _context.People.Any(e => e.Id == id);
        }
    }
}
