namespace SchoolSystem_Data.Helper
{
	public class JwtAuthResult
	{
		public string AccessToken { get; set; }
		public RefreshToken UserResfereshToken { get; set; }
	}
	public class RefreshToken
	{
		public string UserName { get; set; }
		public string TokenString { get; set; }
		public DateTime ExpireAt { get; set; }
	}
}
