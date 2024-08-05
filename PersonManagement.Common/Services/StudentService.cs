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
    public class StudentService : IStudentService
    {
        private readonly IRepository<Student> _studentRepository;

        public StudentService(IRepository<Student> studentRepository)
        {
            _studentRepository = studentRepository;
        }

        public async Task<IEnumerable<Student>> GetAllStudentsAsync()
        {
            return await _studentRepository.GetAllAsync();
        }

        public async Task<Student> GetStudentByIdAsync(int id)
        {
            return await _studentRepository.GetByIdAsync(id);
        }

        public async Task AddStudentAsync(Student student)
        {
            await _studentRepository.AddAsync(student);
        }

        public async Task UpdateStudentAsync(Student student)
        {
            await _studentRepository.UpdateAsync(student);
        }

        public async Task DeleteStudentAsync(int id)
        {
            var student = await _studentRepository.GetByIdAsync(id);
            if (student != null)
            {
                await _studentRepository.DeleteAsync(student);
            }
        }
    }
}
