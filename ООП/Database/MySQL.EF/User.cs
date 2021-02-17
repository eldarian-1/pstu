using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MySQL.EF
{
	[Table("users")]
	internal class User
	{
		[Key]
		[Column("user_id")]
		public int Id { get; set; }

		[Column("user_name")]
		public string Name { get; set; }
	}
}
