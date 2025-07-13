using Agent.Application.DTOs.Room;

namespace Agent.Application.Interfaces
{
    public interface IRoomService
    {
        Task<RoomDTO> CreateAsync(CreateRoomDTO createRoomRequest);
        Task<ICollection<RoomDTO>> GetAllAsync();
        Task<CreateRoomQuestionsDTO> CreateQuestionAsync(Guid roomId, string question);
    }
}
