namespace TMS.Application.Queries.AppTask
{
    using MediatR;
    using Domain.AppTask;

    public class GetAllAppTasksQueryParameter : IRequest<IEnumerable<AppTask>>
    {
        public GetAllAppTasksQueryParameter(
            int pageNumber,
            int pageSize,
            string searchParam)
        {
            PageNumber = pageNumber;
            PageSize = pageSize;
            SearchParam = searchParam;
        }


        public int PageNumber { get; }

        public int PageSize { get; }

        public string SearchParam { get; }
    }
}
