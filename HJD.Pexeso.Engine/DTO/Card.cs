using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HJD.Pexeso.Engine.DTO
{
	public class Card
	{
		private Guid id;
		private int groupId;
		private bool isTurnedFaceUp;
		private bool removed;

		public Guid Id
		{
			get { return id; }
			set { id = value; }
		}

		public int GroupId
		{
			get { return groupId; }
			set { groupId = value; }
		}

		public bool IsTurnedFaceUp
		{
			get { return isTurnedFaceUp; }
			set { isTurnedFaceUp = value; }
		}

		public bool Removed
		{
			get { return removed; }
			set { removed = value; }
		}
	}
}
