using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HJD.Pexeso.Engine.Interface;

namespace HJD.Pexeso.Engine.Model
{
	internal class GameBoard : IGameBoard
	{
		int cardCount;
		int width;
		int height;
		Guid[,] cards;

		#region IGameBoard Members

		public Guid[,] Cards
		{
			get { return cards; }
		}

		public int CardCount
		{
			get { return cardCount; }
		}

		public int Width
		{
			get { return width; }
		}

		public int Height
		{
			get { return height; }
		}

		public void SetCards(List<ICard> cards)
		{
			this.cardCount = cards.Count;
			this.height = (int)Math.Pow((double)this.cardCount, (double)(1.0 / 2.0));
			this.width = (int)Decimal.Ceiling((decimal)this.cardCount / (decimal)this.height);
			this.cards = new Guid[this.width, this.height];

			int i = 0;
			for (int y = 0; y < height; y++)
			{
				for (int x = 0; x < width; x++)
				{
					this.cards[x, y] = cards[i].Id;
					i++;
					if (i == cards.Count)
					{
						break;
					}
				}
			}
		}

		#endregion
	}
}
