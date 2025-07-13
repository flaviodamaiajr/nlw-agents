namespace Agent.Domain.Entities
{
    public class RoomQuestion : BaseEntity
    {
        public Guid RoomId { get; set; }
        public Room Room { get; set; }
        public string Question { get; set; } = null!;
        public string? Answer { get; set; }
    }
}
