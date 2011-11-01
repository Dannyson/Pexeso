using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HJD.Pexeso.Engine.Interface;
using HJD.Pexeso.Engine.Helpers;
using HJD.Pexeso.Engine.Model;

namespace HJD.Pexeso.Engine
{
	internal class GameController : IGameController
	{
		private Game game;

		public GameController(Game game)
		{
			this.game = game;
		}

		#region IGameController Members

		public void AddPlayer(string name)
		{
			if (string.IsNullOrEmpty(name))
			{
				throw new ArgumentException("Player name can`t be empty.");
			}

			Player player = new Player(name);
			game.Players.Add(player.Id, player);
			game.GameState = GameState.Initialzed;

			if (OnGameChanged != null)
			{
				OnGameChanged(this, null);
			}
		}

		public void RemovePlayer(Guid id)
		{
			game.Players.Remove(id);
			game.GameState = GameState.Initialzed;

			if (OnGameChanged != null)
			{
				OnGameChanged(this, null);
			}
		}

		public void RemovePlayers()
		{
			game.Players.Clear();
			game.GameState = GameState.Initialzed;

			if (OnGameChanged != null)
			{
				OnGameChanged(this, null);
			}
		}

		public void NewGame(int cardCount, int groupSizeToFind)
		{
			if (game.Players.Count == 0)
			{
				throw new PexesoException("Can`t start game without players");
			}
			
			game.Cards = CardHelper.CreateCards(cardCount, groupSizeToFind);
			game.GameBoard.SetCards(CardHelper.ShuffleCards(game.Cards.Values.ToList<ICard>()));
			game.ActivePlayer = 0;
			foreach(IPlayer player in game.Players.Values)
			{
				player.FoundCards.Clear();
			}
			game.CardGroupSize = groupSizeToFind;
			game.SelectedCards.Clear();
			game.GameState = GameState.WaitingForNextSelectedCard;

			if (OnGameChanged != null)
			{
				OnGameChanged(this, null);
			}
		}

		public void CardSelected(Guid playerId, Guid cardId)
		{
			if (game.ActivePlayerId == playerId)
			{
				if (game.SelectedCards.Count < game.CardGroupSize)
				{
					TurnCardFaceUp(cardId);
					if (game.SelectedCards.Count == game.CardGroupSize)
					{
						game.GameState = GameState.WaitingForNextRoundApproval;
					}
				}
			}
		}

		public event EventHandler OnGameChanged;

		public void ApproveNextRound(Guid playerId)
		{
			if ((game.ActivePlayerId == playerId) && (game.GameState == GameState.WaitingForNextRoundApproval))
			{
				bool match = CheckGroupMatch();
				if (!match)
				{
					if (game.ActivePlayer == game.Players.Count - 1)
					{
						game.ActivePlayer = 0;
					}
					else
					{
						game.ActivePlayer++;
					}
					game.GameState = GameState.WaitingForNextSelectedCard;
				}

				foreach (ICard card in game.SelectedCards)
				{
					if (match)
					{
						game.Players[game.Players.Keys.ToArray()[game.ActivePlayer]].FoundCards.Add(card.Id);
						card.RemoveFromGame();
					}
					else
					{
						card.TurnFaceDown();
					}
				}

				if (match)
				{
					if (CheckGameEnd())
					{
						game.GameState = GameState.Finished;
					}
					else
					{
						game.GameState = GameState.WaitingForNextSelectedCard;
					}
				}

				game.SelectedCards.Clear();

				if (OnGameChanged != null)
				{
					OnGameChanged(this, null);
				}
			}
		}

		#endregion

		private bool CheckGameEnd()
		{
			bool gameEnd = true;
			foreach (ICard card in game.Cards.Values.ToList())
			{
				if (!card.Removed)
				{
					gameEnd = false;
					break;
				}
			}

			return gameEnd;
		}

		private void TurnCardFaceUp(Guid id)
		{
			if (!game.Cards[id].Removed)
			{
				bool alredySelected = false;
				foreach (ICard card in game.SelectedCards)
				{
					if (card.Id == id)
					{
						alredySelected = true;
						break;
					}
				}

				if (!alredySelected)
				{
					game.Cards[id].TurnFaceUp();
					game.SelectedCards.Add(game.Cards[id]);

					if (OnGameChanged != null)
					{
						OnGameChanged(this, null);
					}
				}
			}
		}

		private bool CheckGroupMatch()
		{
			bool match = true;
			int? groupId = null;

			foreach (ICard card in game.SelectedCards)
			{
				if (!groupId.HasValue)
				{
					groupId = card.GroupId;
				}
				else
				{
					if (groupId != card.GroupId)
					{
						match = false;
						break;
					}
				}
			}

			return match;
		}
	}
}
