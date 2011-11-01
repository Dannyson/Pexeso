using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HJD.Pexeso.Engine.Interface;
using HJD.Pexeso.Engine.DTO;
using HJD.Pexeso.Engine.Model;

namespace HJD.Pexeso.Engine
{
	internal class GameModel : IGameModel
	{
		private Game game;

		public GameModel(Game game)
		{
			this.game = game;
		}

		#region IModel Members

		public List<HJD.Pexeso.Engine.DTO.Card> GetCards()
		{
			List<HJD.Pexeso.Engine.DTO.Card> cards = new List<HJD.Pexeso.Engine.DTO.Card>();
			foreach (ICard card in game.Cards.Values)
			{
				HJD.Pexeso.Engine.DTO.Card cardDTO = new HJD.Pexeso.Engine.DTO.Card()
				{
					Id = card.Id,
					IsTurnedFaceUp = card.IsTurnedFaceUp,
					GroupId = card.GroupId,
					Removed = card.Removed
				};
				cards.Add(cardDTO);
			}
			return cards;
		}

		public List<HJD.Pexeso.Engine.DTO.Player> GetPlayers()
		{
			List<HJD.Pexeso.Engine.DTO.Player> players = new List<HJD.Pexeso.Engine.DTO.Player>();
			foreach (IPlayer player in game.Players.Values)
			{
				players.Add(TransferIPlayerToDTO(player));
			}
			return players;
		}

		public HJD.Pexeso.Engine.DTO.Player GetPlayer(Guid id)
		{
			return TransferIPlayerToDTO(game.Players[id]);
		}

		public HJD.Pexeso.Engine.DTO.Card GetCard(Guid id)
		{
			return TransferICardToDTO(game.Cards[id]);
		}

		public Guid GetActivePlayer()
		{
			return game.ActivePlayerId;
		}

		public GameState GetGameState()
		{
			return game.GameState;
		}

		public DTO.GameBoard GetGameBoard()
		{
			DTO.GameBoard gameBoard = new DTO.GameBoard()
			{
				CardCount = game.GameBoard.CardCount,
				Width = game.GameBoard.Width,
				Height = game.GameBoard.Height,
				Cards = game.GameBoard.Cards,
				CardGroupSize = game.CardGroupSize
			};

			return gameBoard;
		}


		#endregion

		private HJD.Pexeso.Engine.DTO.Player TransferIPlayerToDTO(IPlayer player)
		{
			HJD.Pexeso.Engine.DTO.Player playerDTO = new HJD.Pexeso.Engine.DTO.Player()
			{
				Id = player.Id,
				FoundCards = player.FoundCards,
				Name = player.Name
			};

			return playerDTO;
		}

		private HJD.Pexeso.Engine.DTO.Card TransferICardToDTO(ICard card)
		{
			HJD.Pexeso.Engine.DTO.Card cardDTO = new HJD.Pexeso.Engine.DTO.Card()
			{
				Id = card.Id,
				IsTurnedFaceUp = card.IsTurnedFaceUp,
				GroupId = card.GroupId,
				Removed = card.Removed
			};
			return cardDTO;
		}
	}
}
