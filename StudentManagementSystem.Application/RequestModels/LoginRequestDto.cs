namespace StudentManagementSystem.Application.RequestModels
{
    public record LoginRequestDto
    {
        public string? Username { get; set; }
        public string? Password { get; set; }
    }
}
