namespace TMS.Application.Queries.Project
{
    using MediatR;
    using Domain.Project;

    public class GetProjectByIdQueryParameter : IRequest<Project>
    {
        public GetProjectByIdQueryParameter(Guid id) 
        {
            Id = id;
        }
        public Guid Id { get; }
    }
}
