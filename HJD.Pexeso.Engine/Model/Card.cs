using HJD.Pexeso.Engine.Interface;
using System;

namespace HJD.Pexeso.Engine.Model
{
	internal class Card : ICard
	{
		private Guid id;
		private bool turnedFaceUp;
		private int groupId;
		private bool removed = false;

		public Card(int pairId)
		{
			this.id = Guid.NewGuid();
			this.groupId = pairId;
		}

		public Card(Guid id, int pairId)
		{
			this.id = id;
			this.groupId = pairId;
		}

		#region ICard Members

		public System.Guid Id
		{
			get { return this.id; }
		}

		public bool IsTurnedFaceUp
		{
			get { return turnedFaceUp; }
		}

		public int GroupId
		{
			get { return groupId; }
		}

		public bool Removed
		{
			get { return removed; }
		}

		public void TurnFaceUp()
		{
			turnedFaceUp = true;
		}

		public void TurnFaceDown()
		{
			turnedFaceUp = false;
		}

		public void Turn()
		{
			this.turnedFaceUp = !turnedFaceUp;
		}

		public void RemoveFromGame()
		{
			this.removed = true;
		}

		#endregion
	}
}
