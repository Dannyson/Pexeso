using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HJD.Pexeso.Engine.DTO
{
	public class GameBoard
	{
		int cardCount;
		int width;
		int height;
		int cardGroupSize;
		Guid[,] cards;

		public Guid[,] Cards
		{
			get { return cards; }
			set { cards = value; }
		}

		public int CardCount
		{
			get { return cardCount; }
			set { cardCount = value; }
		}

		public int CardGroupSize
		{
			get { return cardGroupSize; }
			set { cardGroupSize = value; }
		}

		public int Width
		{
			get { return width; }
			set { width = value; }
		}

		public int Height
		{
			get { return height; }
			set { height = value; }
		}
	}
}
