﻿namespace TMS.Application.Commands.Project
{
    using MediatR;
    using TMS.Domain.Project;

    public class UpdateProjectCommandParameter : IRequest<bool>
    {
        public UpdateProjectCommandParameter(
            Guid id,
            string name, 
            string description,
            ProjectStatus projectStatus)
        {
            Id = id;
            Name = name;
            Description = description;
            ProjectStatus = projectStatus;
        }

        public Guid Id { get; }

        public string Name { get; }

        public string Description { get; }

        public ProjectStatus ProjectStatus { get; }
    }
}
