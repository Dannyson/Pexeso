using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HJD.Pexeso.Engine.Interface
{
	public interface IGameController
	{
		event EventHandler OnGameChanged;

		void AddPlayer(string name);
		void RemovePlayer(Guid id);
		void RemovePlayers();
		void NewGame(int cardCount, int groupSizeToFind);
		void CardSelected(Guid playerId, Guid cardId);
		void ApproveNextRound(Guid playerId);
	}
}
