using SchoolSystem_Data.Entities.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolSystem_Data.Entities
{
	public class UserRefreshToken
	{
		[Key]
		public int Id { get; set; }

		[ForeignKey(nameof(User))]
		public int UserId { get; set; }

		public string? JwtId { get; set; }

		public string? RefreshToken { get; set; }

		public string? JWTToken { get; set; }

		public DateTime AddedTime { get; set; }

		public bool IsRevoked { get; set; }

		public bool IsUsed { get; set; }

		public DateTime ExpiryDate { get; set; }

		[InverseProperty(nameof(User.UserRefreshTokens))]
		public virtual User? User { get; set; }
	}
}
