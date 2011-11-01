using System.Collections.Generic;
using HJD.Pexeso.Engine.Interface;
using System;

namespace HJD.Pexeso.Engine.Model
{
	internal class Player : IPlayer
	{
		private Guid id;
		private string name;
		private List<Guid> foundCards = new List<Guid>();

		public Player(string name)
		{
			this.name = name;
			this.id = Guid.NewGuid();
		}

		public Player(Guid id, string name)
		{
			this.name = name;
			this.id = id;
		}

		#region IPlayer Members

		public string Name
		{
			get { return this.name; }
		}

		public Guid Id
		{
			get { return this.id; }
		}

		public List<Guid> FoundCards
		{
			get { return this.foundCards; }
		}

		public void AddFoundCard(Guid cardId)
		{
			this.foundCards.Add(cardId);
		}

		#endregion
	}
}
