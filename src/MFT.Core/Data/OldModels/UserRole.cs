using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace MFT.Core.Data.Models
{
	public class UserRole : EntityBase
	{
		public string Name { get; set; }



		public virtual ICollection<User> Users { get; set; }
	}
}