namespace TMS.Application.Commands.AppTask
{
    using MediatR;

    public class DeleteAppTaskCommandParameter : IRequest<bool>
    {
        public DeleteAppTaskCommandParameter(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; }
    }
}
