using System;

namespace HJD.Pexeso.Engine.Interface
{
	internal interface ICard
	{
		Guid Id { get; }
		int GroupId { get; }
		bool IsTurnedFaceUp { get; }
		bool Removed { get; }

		void TurnFaceDown();
		void TurnFaceUp();
		void Turn();
		void RemoveFromGame();
	}
}
