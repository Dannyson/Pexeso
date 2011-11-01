using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HJD.Pexeso.Engine.DTO
{
	public class Player
	{
		private Guid id;
		private string name;
		private List<Guid> foundCards;

		public Guid Id
		{
			get { return id; }
			set { id = value; }
		}

		public string Name
		{
			get { return name; }
			set { name = value; }
		}

		public List<Guid> FoundCards
		{
			get { return foundCards; }
			set { foundCards = value; }
		}
	}
}
