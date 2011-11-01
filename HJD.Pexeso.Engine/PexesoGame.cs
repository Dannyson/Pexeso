using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HJD.Pexeso.Engine.Interface;

namespace HJD.Pexeso.Engine
{
	public class PexesoGame
	{
		private Game game;

		private GameModel model;
		public IGameModel Model
		{
			get { return model; }
		}

		private GameController gameController;
		public IGameController GameController
		{
			get { return gameController; }
		}

		public PexesoGame()
		{
			this.game = new Game();
			model = new GameModel(game);
			gameController = new GameController(game);
		}
	}
}
