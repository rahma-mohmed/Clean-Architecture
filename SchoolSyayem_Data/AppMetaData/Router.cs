namespace SchoolSystem_Data.AppMetaData
{
	public static class Router
	{
		public const string root = "api";
		//public const string version = "v1";
		public const string Rule = root + "/"; //+ version + "/";

		public static class StudentRouting
		{
			public const string prefix = Rule + "Student";
			public const string List = prefix + "/List";
			public const string GetById = prefix + "/{id}";
			public const string Create = prefix + "/Create";
			public const string Edit = prefix + "/Edit";
			public const string Delete = prefix + "/{id}";
			public const string Paginated = prefix + "/Paginated";
		}

		public static class DepartmentRouting
		{
			public const string prefix = Rule + "Department";
			public const string List = prefix + "/List";
			public const string GetById = prefix + "/{id}";
			public const string Create = prefix + "/Create";
			public const string Edit = prefix + "/Edit";
			public const string Delete = prefix + "/{id}";
			public const string Paginated = prefix + "/Paginated";
		}

		public static class UserRouting
		{
			public const string prefix = Rule + "User";
			public const string List = prefix + "/List";
			public const string GetById = prefix + "/{id}";
			public const string Create = prefix + "/Create";
			public const string Edit = prefix + "/Edit";
			public const string Delete = prefix + "/{id}";
			public const string Paginated = prefix + "/Paginated";
			public const string Password = prefix + "/Password";
		}

		public static class AuthenticationRouting
		{
			public const string prefix = Rule + "Authentication";
			public const string SignIn = prefix + "/SignIn";
			public const string RefreshToken = prefix + "/RefreshToken";
		}
		public static class AuthorizationsRouting
		{
			public const string prefix = Rule + "Authorization";
			public const string AddRoles = prefix + "/Add";
		}
	}
}
