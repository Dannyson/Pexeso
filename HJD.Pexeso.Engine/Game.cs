using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HJD.Pexeso.Engine.Interface;
using HJD.Pexeso.Engine.Helpers;
using HJD.Pexeso.Engine.Model;

namespace HJD.Pexeso.Engine
{
	internal class Game
	{
		private const int DEFAULT_GROUP_SIZE = 2;

		private int activePlayer = 0;
		private Guid activePlayerId = Guid.Empty;
		private Dictionary<Guid, IPlayer> players = new Dictionary<Guid, IPlayer>();
		private Dictionary<Guid, ICard> cards = new Dictionary<Guid, ICard>();
		private int cardGroupSize = DEFAULT_GROUP_SIZE;
		private List<ICard> selectedCards = new List<ICard>();
		private GameState gameState = GameState.Initialzed;
		private GameBoard gameBoard = new GameBoard();

		internal GameBoard GameBoard
		{
			get { return gameBoard; }
			set { gameBoard = value; }
		}

		internal Guid ActivePlayerId
		{
			get { return players.Keys.ToArray()[activePlayer]; }
		}

		internal GameState GameState
		{
			get { return gameState; }
			set { gameState = value; }
		}

		internal List<ICard> SelectedCards
		{
			get { return selectedCards; }
			set { selectedCards = value; }
		}

		internal int ActivePlayer
		{
			get { return activePlayer; }
			set { activePlayer = value; }
		}

		internal Dictionary<Guid, IPlayer> Players
		{
			get { return players; }
			set { players = value; }
		}

		internal Dictionary<Guid, ICard> Cards
		{
			get { return cards; }
			set { cards = value; }
		}

		internal int CardGroupSize
		{
			get { return cardGroupSize; }
			set { cardGroupSize = value; }
		}

		internal void Reset()
		{
			activePlayer = 0;
			players = new Dictionary<Guid, IPlayer>();
			cards = new Dictionary<Guid, ICard>();
			cardGroupSize = DEFAULT_GROUP_SIZE;
		}
	}
}
