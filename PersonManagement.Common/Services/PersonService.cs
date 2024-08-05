using PersonManagement.Common.Entities;
using PersonManagement.Common.Interfaces.Repository;
using PersonManagement.Common.Interfaces.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonManagement.Common.Services
{
    public class PersonService : IPersonService
    {
        private readonly IRepository<Person> _personRepository;

        public PersonService(IRepository<Person> personRepository)
        {
            _personRepository = personRepository;
        }

        public async Task<IEnumerable<Person>> GetAllPeopleAsync()
        {
            return await _personRepository.GetAllAsync();
        }

        public async Task<Person> GetPersonByIdAsync(int id)
        {
            return await _personRepository.GetByIdAsync(id);
        }

        public async Task AddPersonAsync(Person person)
        {
            await _personRepository.AddAsync(person);
        }

        public async Task UpdatePersonAsync(Person person)
        {
            await _personRepository.UpdateAsync(person);
        }

        public async Task DeletePersonAsync(int id)
        {
            var person = await _personRepository.GetByIdAsync(id);
            if (person != null)
            {
                await _personRepository.DeleteAsync(person);
            }
        }
    }
}
