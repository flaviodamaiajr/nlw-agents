namespace Agent.Application.DTOs.Room
{
    public record CreateRoomQuestionsDTO(string Question, string? Answer) : BaseDTO;
}
