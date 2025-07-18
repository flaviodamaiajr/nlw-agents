﻿namespace Agent.Application.DTOs.Room
{
    public record RoomDTO(string Name, string Description, ICollection<RoomQuestionsDTO>? Questions = null) : BaseDTO;
}
