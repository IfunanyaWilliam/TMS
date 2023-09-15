namespace TMS.Application.Commands.Project
{
    using MediatR;

    public class CreateProjectCommandParameter : IRequest<bool>
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
