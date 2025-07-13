using Agent.Application.DTOs.Room;
using Agent.Application.Interfaces;
using Agent.Domain.Entities;
using Agent.Domain.Interfaces;

namespace Agent.Application.Services
{
    public class RoomService : IRoomService
    {
        private readonly IRoomRepository _roomRepository;
        private readonly IRoomQuestionRepository _roomQuestionRepository;


        public RoomService(IRoomRepository roomRepository, IRoomQuestionRepository roomQuestionRepository)
        {
            _roomRepository = roomRepository;
            _roomQuestionRepository = roomQuestionRepository;
        }

        public async Task<RoomDTO> CreateAsync(CreateRoomDTO createRoomRequest)
        {
            var room = new Room(createRoomRequest.Name, createRoomRequest.Description);

            await _roomRepository.CreateAsync(room);

            return new RoomDTO(room.Name, room.Description)
            {
                Id = room.Id,
                CreatedAt = room.CreatedAt
            };
        }

        public async Task<ICollection<RoomDTO>> GetAllAsync()
        {
            var rooms = await _roomRepository.GetRoomsAsync();

            return [.. rooms.Select(r => new RoomDTO(r.Name,
                                                           r.Description,
                                                           Questions: r.RoomQuestions?.Select(q => new RoomQuestionsDTO(q.Question, q.Answer) {
                                                               Id = r.Id,
                                                               CreatedAt = r.CreatedAt
                                                           }).ToList() ?? []){
                Id = r.Id,
                CreatedAt = r.CreatedAt
            })];
        }

        public async Task<CreateRoomQuestionsDTO> CreateQuestionAsync(Guid roomId, string question)
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
