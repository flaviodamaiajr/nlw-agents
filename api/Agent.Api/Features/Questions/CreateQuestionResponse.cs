namespace Agent.Api.Features.Questions
{
    public class CreateQuestionResponse
    {
        public Guid Id { get; set; }
        public string Question { get; set; } = null!;
        public DateTime CreatedAt { get; set; }
    }
}
