using Agent.Application.DTOs.Room;

namespace Agent.Api.Features.Rooms
{
    public record GetRoomsResponse
    {
        public RoomDTO? Room { get; set; }
        public List<RoomQuestionsDTO>? RoomQuestions { get; set; }
    }
}
