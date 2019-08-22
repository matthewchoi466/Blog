using System;
using System.ComponentModel;

namespace Blog.Domain.Models
{
    public enum EUserRole : byte
	{
		[Description("Admin")]
		Administrator = 1

	}
}
