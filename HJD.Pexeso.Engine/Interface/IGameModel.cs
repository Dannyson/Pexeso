using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HJD.Pexeso.Engine.Model;

namespace HJD.Pexeso.Engine.Interface
{
	public interface IGameModel
	{
		List<DTO.Card> GetCards();
		DTO.GameBoard GetGameBoard();
		List<DTO.Player> GetPlayers();
		DTO.Player GetPlayer(Guid id);
		DTO.Card GetCard(Guid id);
		Guid GetActivePlayer();
		GameState GetGameState();
	}
}
