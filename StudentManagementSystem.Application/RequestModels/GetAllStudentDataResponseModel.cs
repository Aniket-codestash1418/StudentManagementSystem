namespace StudentManagementSystem.Application.RequestModels
{
    public class GetAllStudentDataResponseModel
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public int Age { get; set; }
        public string? Course { get; set; }
    }
}
