namespace SchoolSystem_Core.Wrapper
{
	public class PaginatedResult<T>
	{
		#region Feilds
		public List<T> Data { get; set; }

		public int CurrentPage { get; set; }

		public int TotalPages { get; set; }

		public int TotalCount { get; set; }

		public object Meta { get; set; }

		public int PageSize { get; set; }

		public bool HasPreviousPage => CurrentPage > 1;

		public bool HasNextPage => CurrentPage < TotalPages;

		public List<string> Messages { get; set; }

		public bool Succeeded { get; set; }

		#endregion

		#region Constructors

		public PaginatedResult(List<T> data)
		{
			Data = data;
		}

		internal PaginatedResult(bool succeeded, List<T> data = default, List<string> messages = null, int count = 0, int pagenumber = 1, int pagesize = 10)
		{
			Data = data;
			PageSize = pagesize;
			CurrentPage = pagenumber;
			Succeeded = succeeded;
			TotalPages = (int)Math.Ceiling(count / (double)pagesize);
			TotalCount = count;
		}

		#endregion

		#region Handle Function
		public static PaginatedResult<T> Success(List<T> data, int count, int pagenumber, int pagesize)
		{
			return new(true, data, null, count, pagenumber, pagesize);
		}

		#endregion
	}
}
