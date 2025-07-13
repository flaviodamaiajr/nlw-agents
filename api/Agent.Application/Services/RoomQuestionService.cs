using Agent.Application.DTOs.Room;
using Agent.Application.Interfaces;
using Agent.Domain.Entities;
using Agent.Domain.Interfaces;

namespace Agent.Application.Services
{
    public class RoomQuestionService : IRoomQuestionService
    {
        private readonly IRoomQuestionRepository _roomQuestionRepository;

        public RoomQuestionService(IRoomQuestionRepository roomQuestionRepository)
        {
            _roomQuestionRepository = roomQuestionRepository;
        }

        public async Task<CreateRoomQuestionsDTO> CreateAsync(Guid roomId, string question)
        {
            var roomQuestion = await _roomQuestionRepository.CreateAsync(new RoomQuestion()
            {
                RoomId = roomId,
                Question = question,
            });

            // TODO: Retornar a reposta com a IA

            return new CreateRoomQuestionsDTO(roomQuestion.Question, null)
            {
                Id = roomQuestion.Id,
                CreatedAt = roomQuestion.CreatedAt
            };
        }
    }
}
