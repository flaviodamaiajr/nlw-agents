using FastEndpoints;

namespace Agent.Api.Features.Questions
{
    public class CreateQuestionEndPoint : Endpoint<CreateQuestionRequest, CreateQuestionResponse>
    {
        public override void Configure()
        {
            Post("/api/rooms/{roomId}/question");
            AllowAnonymous();
        }

        public override async Task HandleAsync(CreateQuestionRequest req, CancellationToken ct)
        {
            await SendAsync(new CreateQuestionResponse(), 201, ct);
        }
    }
}
