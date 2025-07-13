namespace Agent.Api.Features.RoomQuestions
{
    public record GetRoomQuestionsResponse
    {
        public Guid RoomId { get; set; }
        public int MyProperty { get; set; }
    }
}
