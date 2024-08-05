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
    public class ProfessorService : IProfessorService
    {
        private readonly IRepository<Professor> _professorRepository;

        public ProfessorService(IRepository<Professor> professorRepository)
        {
            _professorRepository = professorRepository;
        }

        public async Task<IEnumerable<Professor>> GetAllProfessorsAsync()
        {
            return await _professorRepository.GetAllAsync();
        }

        public async Task<Professor> GetProfessorByIdAsync(int id)
        {
            return await _professorRepository.GetByIdAsync(id);
        }

        public async Task AddProfessorAsync(Professor professor)
        {
            await _professorRepository.AddAsync(professor);
        }

        public async Task UpdateProfessorAsync(Professor professor)
        {
            await _professorRepository.UpdateAsync(professor);
        }

        public async Task DeleteProfessorAsync(int id)
        {
            var professor = await _professorRepository.GetByIdAsync(id);
            if (professor != null)
            {
                await _professorRepository.DeleteAsync(professor);
            }
        }
    }
}
