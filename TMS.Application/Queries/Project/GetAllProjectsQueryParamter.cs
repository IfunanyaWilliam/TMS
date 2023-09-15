namespace TMS.Application.Queries.Project
{
    using MediatR;
    using Domain.Project;

    public class GetAllProjectsQueryParamter : IRequest<IEnumerable<Project>>
    {
    }
}
