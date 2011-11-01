using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HJD.Pexeso.Engine.Interface;
using HJD.Pexeso.Engine.Model;

namespace HJD.Pexeso.Engine.Helpers
{
	internal static class CardHelper
	{
		public static List<ICard> ShuffleCards(List<ICard> cards)
		{
			Random random = new Random();
			List<ICard> shuffledCards = new List<ICard>();
			int index;
			while (cards.Count != 0)
			{
				index = random.Next(0, cards.Count);
				ICard card = cards[index];
				shuffledCards.Add(card);
				cards.Remove(card);
			}
			return shuffledCards;
		}

		public static Dictionary<Guid, ICard> CreateCards(int cardCount, int cardGroupSize)
		{
			Dictionary<Guid, ICard> cards = new Dictionary<Guid, ICard>();
			int cardGroupsCount = (int)(cardCount / cardGroupSize);
			Card card;

			for (int i = 1; i <= cardGroupsCount; i++)
			{
				for (int y = 1; y <= cardGroupSize; y++)
				{
					card = new Card(i);
					cards.Add(card.Id, card);
				}
			}

			return cards;
		}

		//public static void DealCards(List<ICard> cards)
		//{
		//    //if (cards == null)
		//    //{
		//    //    throw new ArgumentNullException("cards");
		//    //}

		//    //int x = 0, y = 0;
		//    //foreach (ICard card in cards)
		//    //{
		//    //    if (x >= this.width)
		//    //    {
		//    //        x = 0;
		//    //        y++;
		//    //    }
		//    //    this.deltCards[x, y] = card;
		//    //    x++;
		//    //}
		//}
	}
}
