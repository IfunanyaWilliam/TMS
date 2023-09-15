namespace TMS.Application.Queries.Project
{
    using MediatR;
    using Domain.Project;

    public class GetAllProjectsQueryParamter : IRequest<IEnumerable<Project>>
    {
        public GetAllProjectsQueryParamter(
            string searchParam,
            int pageNumber,
            int pageSize)
        {
            SearchParam = searchParam;
            PageNumber = pageNumber;
            PageSize = pageSize;
        }


        public int PageNumber { get; }

        public int PageSize { get; }

        public string SearchParam { get; }
    }
}
