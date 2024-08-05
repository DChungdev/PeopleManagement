using PersonManagement.Common.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonManagement.Common.Interfaces.Service
{
    public interface IProfessorService
    {
        Task<IEnumerable<Professor>> GetAllProfessorsAsync();
        Task<Professor> GetProfessorByIdAsync(int id);
        Task AddProfessorAsync(Professor professor);
        Task UpdateProfessorAsync(Professor professor);
        Task DeleteProfessorAsync(int id);
    }
}
