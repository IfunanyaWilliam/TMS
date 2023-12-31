﻿namespace TMS.Application.Commands.Project
{
    using MediatR;
    public class AddAppTaskToProjectCommandParameter : IRequest<bool>
    {
        public AddAppTaskToProjectCommandParameter(
            Guid appTaskId,
            Guid projectId)
        {
            ProjectId = projectId;
            AppTaskId = appTaskId;
        }

        public Guid AppTaskId { get; }

        public Guid ProjectId { get; }
    }
}
