namespace Agent.Application.DTOs
{
    public abstract record BaseDTO
    {
        public Guid Id { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
