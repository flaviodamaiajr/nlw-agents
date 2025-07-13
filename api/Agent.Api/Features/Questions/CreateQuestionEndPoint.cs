using Agent.Application.Interfaces;
using FastEndpoints;
using System.Net;

namespace Agent.Api.Features.Questions
{
    public class CreateQuestionEndPoint : Endpoint<CreateQuestionRequest, CreateQuestionResponse>
    {
        private readonly IRoomQuestionService _roomQuestionService;

        public CreateQuestionEndPoint(IRoomQuestionService roomQuestionService)
        {
            _roomQuestionService = roomQuestionService;
        }

        public override void Configure()
        {
            Post("/api/rooms/{roomId}/question");
            AllowAnonymous();
        }

        public override async Task HandleAsync(CreateQuestionRequest req, CancellationToken ct)
        {
            var question = await _roomQuestionService.CreateAsync(req.RoomId, req.Question);

            await SendAsync(new CreateQuestionResponse
            {
                Question = req.Question,
                Id = question.Id,
                CreatedAt = question.CreatedAt
            }, (int)HttpStatusCode.Created, ct);
        }
    }
}
