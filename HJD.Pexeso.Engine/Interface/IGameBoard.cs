using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HJD.Pexeso.Engine.Interface
{
	internal interface IGameBoard
	{
		int CardCount { get; }
		int Width { get; }
		int Height { get; }
		Guid[,] Cards { get; }

		void SetCards(List<ICard> cards);
	}
}
