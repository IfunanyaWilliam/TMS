﻿namespace TMS.Application.QueryHandlers.Project
{
    using MediatR;
    using System.Threading;
    using System.Threading.Tasks;
    using TMS.Application.Queries.Project;
    using TMS.Application.Repository;
    using TMS.Domain.Project;

    public class GetProjectByIdQueryHandler : IRequestHandler<GetProjectByIdQueryParameter, Project>, IMediatRHandler
    {
        private readonly IProjectRepository _projectRepository;

        public GetProjectByIdQueryHandler(IProjectRepository projectRepository)
        {
            _projectRepository = projectRepository;
        }

        public async Task<Project> Handle(
            GetProjectByIdQueryParameter request,
            CancellationToken cancellationToken)
        {
            return await _projectRepository.GetProjectByIdAsync(request.Id);
        }
    }
}