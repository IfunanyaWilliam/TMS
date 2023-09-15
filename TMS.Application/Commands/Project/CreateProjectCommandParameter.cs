namespace TMS.Application.Commands.Project
{
    using MediatR;
    using TMS.Domain.Project;

    public class CreateProjectCommandParameter : IRequest<Project>
    {
        public CreateProjectCommandParameter(string name, string description)
        {
             Name = name;
            Description = description;
        }

        public string Name { get; set; }

        public string Description { get; set; }
    }
}
