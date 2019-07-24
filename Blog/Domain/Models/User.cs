using System;
using System.ComponentModel;
namespace Blog.Domain.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }

		[DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        public string Password { get; set; }
		public EUserRole Role { get; set; }
    }
}
