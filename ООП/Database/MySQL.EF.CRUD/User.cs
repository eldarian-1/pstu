using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MySQL.EF.CRUD
{
	[Table("users")]
	internal class User
	{
		[Key]
		[Column("user_id")]
		public int Id { get; set; }

		[Column("user_name")]
		public string Name { get; set; }

        public override bool Equals(object obj)
        {
			User user = obj as User;
            return user.Id == Id;
        }

        public override int GetHashCode()
        {
            return Id;
        }
    }
}
