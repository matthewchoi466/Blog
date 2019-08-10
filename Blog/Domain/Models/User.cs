using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
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
        public IList<Article> Articles { get; set; } = new List<Article>();
    }
}
