namespace TMS.Application.Commands.Project
{
    using MediatR;


    internal class UpdateProjectCommandParameter : IRequest<bool>
    {
        public UpdateProjectCommandParameter(string name, string description)
        {
            Name = name;
            Description = description;
        }

        public string Name { get; set; }

        public string Description { get; set; }
    }
}
