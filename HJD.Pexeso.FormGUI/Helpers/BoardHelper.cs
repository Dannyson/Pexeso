using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using HJD.Pexeso.Engine.DTO;
using HJD.Pexeso.Engine;

namespace HJD.Pexeso.FormGUI.Helpers
{
	internal static class BoardHelper
	{
		private const string PICTURES_DIRECTORY = "Pictures";
		private const string BACK_PICTURE_DIRECTORY = "Background";
		private const string BACK_PICTURE_FILENAME = "Background.jpg";
		private const string PICTURES_PATTERN = "*.jpg";
		internal const int PICTURE_WIDTH = 100;
		internal const int PICTURE_PADDING = 2;

		internal static List<Bitmap> LoadFrontPictures(int count)
		{
			string[] pictureFiles = Directory.GetFiles(PICTURES_DIRECTORY, PICTURES_PATTERN);
			if (pictureFiles.Length < count)
			{
				throw new ArgumentOutOfRangeException("pictureFiles", "Not enough picture files.");
			}

			List<Bitmap> frontPictures = new List<Bitmap>();

			foreach (string fileName in pictureFiles)
			{
				try
				{
					frontPictures.Add(new Bitmap(fileName));
				}
				catch(Exception e)
				{
					throw new Exception("Error while loading front pictures. Looking for: " + fileName, e);
				}
			}
			return frontPictures;
		}

		internal static Bitmap LoadBackPicture()
		{
			Bitmap backPicture;
			string backPictureFilePath = string.Format(@"{0}\{1}\{2}\{3}", Application.StartupPath, PICTURES_DIRECTORY, BACK_PICTURE_DIRECTORY, BACK_PICTURE_FILENAME);
			try
			{
				backPicture = new Bitmap(backPictureFilePath);
			}
			catch (Exception e)
			{
				throw new Exception("Error while loading back picture. Looking for: " + backPictureFilePath, e);
			}

			return backPicture;
		}

		internal static Dictionary<Guid, PictureCard> CreateCards(List<Card> cards, List<Bitmap> frontPictures, Bitmap backPicture, int width, EventHandler pictureCardClick)
		{
			Dictionary<Guid, PictureCard> pictureCards = new Dictionary<Guid, PictureCard>();

			foreach (Card card in cards)
			{
				PictureCard pictureCard = new PictureCard(frontPictures[card.GroupId], backPicture, card.Id, width);
				pictureCard.Click += pictureCardClick;
				pictureCards.Add(card.Id, pictureCard);
			}

			return pictureCards;
		}

		internal static void DealCards(Guid[,] cardPositions, int width, int height, Dictionary<Guid, PictureCard> cards)
		{
			int cardsDelt = 0;
			for (int y = 0; y < height; y++)
			{
				for (int x = 0; x < width; x++)
				{
					if (cardsDelt == cards.Count)
					{
						break;
					}
					PictureCard card = cards[cardPositions[x, y]];
					card.Position = new Point(PICTURE_PADDING * (x + 1) + card.Width * x, (PICTURE_PADDING * (y + 1) + card.Height * y));
					cardsDelt++;
				}
			}
		}

		internal static void UpdateCards(Dictionary<Guid, PictureCard> pictureCards, List<Card> cards)
		{
			PictureCard pictureCard;

			foreach (Card card in cards)
			{
				if (pictureCards.ContainsKey(card.Id))
				{
					pictureCard = pictureCards[card.Id];
					if (card.Removed)
					{
						pictureCards.Remove(card.Id);
						DisposePictureCard(pictureCard);
					}
					else
					{
						if (card.IsTurnedFaceUp)
						{
							pictureCard.TurnFrontSideUp();
						}
						else
						{
							pictureCard.TurnBackSideUp();
						}
					}
				}
			}
		}

		internal static void DisposePictureCard(PictureCard pictureCard)
		{
			pictureCard.Image.Dispose();
			pictureCard.FrontPicture.Dispose();
			pictureCard.Dispose();
		}

		internal static void ClearPictureCards(Dictionary<Guid, PictureCard> pictureCards)
		{
			foreach (PictureCard card in pictureCards.Values)
			{
				DisposePictureCard(card);
			}
			pictureCards.Clear();
		}
	}
}
