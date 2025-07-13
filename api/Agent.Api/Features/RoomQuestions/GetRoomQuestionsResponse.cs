namespace Agent.Api.Features.RoomQuestions
{
    public record GetRoomQuestionsRequest
    {
        public Guid RoomId { get; set; }
    }
}
