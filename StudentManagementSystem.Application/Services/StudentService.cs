using StudentManagementSystem.Application.Interfaces;
using StudentManagementSystem.Application.RequestModels;
using StudentManagementSystem.Domain.Entities;

namespace StudentManagementSystem.Application.Services
{
    public interface IStudentService
    {
        Task<IEnumerable<GetAllStudentDataResponseModel>> GetAllAsync();
        Task<Student> GetByIdAsync(int id);
        Task<Student> AddAsync(StudentDto dto);
        Task<bool> UpdateAsync(UpdateStudentDto dto);
        Task<bool> DeleteAsync(int id);
    }

    public class StudentService : IStudentService
    {
        private readonly IStudentRepository _studentRepository;

        public StudentService(IStudentRepository studentRepository)
        {
            this._studentRepository = studentRepository ?? throw new ArgumentNullException(nameof(studentRepository));
        }

        public async Task<Student> AddAsync(StudentDto dto)
        {
            Student student = new()
            {
                Age = dto.Age,
                Course = dto.Course,
                Email = dto.Email,
                Name = dto.Name,
                CreatedDate = DateTime.UtcNow
            };
            var response = await _studentRepository.AddAsync(student);
            return response!;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var response = await _studentRepository.DeleteAsync(id);
            return response!;
        }

        public async Task<IEnumerable<GetAllStudentDataResponseModel>> GetAllAsync()
        {

            List<GetAllStudentDataResponseModel> listResponse = new();
            var response = await _studentRepository.GetAllAsync();
            foreach (var item in response)
            {
                GetAllStudentDataResponseModel model = new()
                {
                    Id = item.Id,
                    Name = item.Name,
                    Age = item.Age,
                    Course = item.Course,
                    Email = item.Email,
                };
                listResponse.Add(model);
            }

            return listResponse;
        }

        public Task<Student> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> UpdateAsync(UpdateStudentDto dto)
        {
            Student student = new()
            {
                Id = dto.Id,
                Name = dto.Name,
                Age = dto.Age,
                Course = dto.Course,
                Email = dto.Email,
            };
            var response = await _studentRepository.UpdateAsync(student);
            return response;
        }
    }
}
