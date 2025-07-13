namespace Agent.Api.Features.Questions
{
    public class CreateQuestionRequest
    {
        public Guid RoomId { get; set; }
        public string Question { get; set; } = null!;

    }
}
