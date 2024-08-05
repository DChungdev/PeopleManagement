using PersonManagement.Common.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonManagement.Common.Interfaces.Service
{
    public interface IPersonService
    {
        Task<IEnumerable<Person>> GetAllPeopleAsync();
        Task<Person> GetPersonByIdAsync(int id);
        Task AddPersonAsync(Person person);
        Task UpdatePersonAsync(Person person);
        Task DeletePersonAsync(int id);
    }
}
