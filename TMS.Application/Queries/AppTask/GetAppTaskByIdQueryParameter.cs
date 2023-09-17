namespace TMS.Application.Queries.AppTask
{
    using MediatR;
    using Domain.AppTask;

    public class GetAppTaskByIdQueryParameter : IRequest<AppTask>
    {
        public GetAppTaskByIdQueryParameter(Guid id)
        {
            Id = id;
        }
        public Guid Id { get; }
    }
}
