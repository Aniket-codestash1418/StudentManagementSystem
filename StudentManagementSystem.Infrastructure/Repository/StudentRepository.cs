using Microsoft.EntityFrameworkCore;
using StudentManagementSystem.Application.Interfaces;
using StudentManagementSystem.Domain.Entities;
using StudentManagementSystem.Infrastructure.DatabaseContext;

namespace StudentManagementSystem.Infrastructure.Repository
{
    public class StudentRepository : IStudentRepository
    {
        private readonly AppDbContext _appDbContext;

        public StudentRepository(AppDbContext appDbContext)
        {
            this._appDbContext = appDbContext ?? throw new ArgumentNullException(nameof(appDbContext));
        }

        public async Task<Student> AddAsync(Student student)
        {
            try
            {
                var response = await _appDbContext.Students.AddAsync(student);
                _appDbContext.SaveChanges();
                return student;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> DeleteAsync(int Id)
        {
            try
            {
                var existingRecord = await _appDbContext.Students.Where(x => x.Id == Id).FirstOrDefaultAsync();
                if (existingRecord != null)
                {
                    existingRecord.IsDeleted = true;
                    await _appDbContext.SaveChangesAsync();
                    return true;
                }
                return false;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<IEnumerable<Student>> GetAllAsync()
        {
            try
            {
                var response = await _appDbContext.Students.Where(x => x.IsDeleted == false).ToListAsync();
                return response;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public Task<Student> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> UpdateAsync(Student student)
        {
            try
            {
                var existingRecord = await _appDbContext.Students.Where(x => x.Id == student.Id).FirstOrDefaultAsync();
                if (existingRecord != null)
                {
                    existingRecord.Name = student.Name;
                    existingRecord.Email = student.Email;
                    existingRecord.Course = student.Course;
                    existingRecord.Age = student.Age;
                    await _appDbContext.SaveChangesAsync();
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                return false;
                throw;
            }
        }
    }
}
