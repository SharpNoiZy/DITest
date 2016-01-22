using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace MFT.Core.Data.Models
{
	public class EntityBase
	{
		public Guid Id { get; set; }


		public EntityBase()
		{
			Id = Guid.NewGuid();
		}
	}
}