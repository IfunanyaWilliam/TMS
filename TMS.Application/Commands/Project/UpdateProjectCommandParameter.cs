﻿namespace TMS.Application.Commands.Project
{
    using MediatR;
    using Repository;

    public class UpdateProjectCommandParameter : IRequest<bool>, IMediatRHandler
    {
        public UpdateProjectCommandParameter(
            Guid id,
            string name, 
            string description)
        {
            Id = id;
            Name = name;
            Description = description;
        }

        public Guid Id { get; }

        public string Name { get; }

        public string Description { get; }
    }
}
