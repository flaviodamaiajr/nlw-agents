using Agent.Application.DTOs.Room;

namespace Agent.Application.Interfaces
{
    public interface IRoomQuestionService
    {
        Task<CreateRoomQuestionsDTO> CreateAsync(Guid roomId, string question);
    }
}
