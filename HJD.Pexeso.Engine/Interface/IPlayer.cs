using System;
using System.Collections.Generic;

namespace HJD.Pexeso.Engine.Interface
{
	internal interface IPlayer
	{
		Guid Id { get; }
		string Name { get; }
		List<Guid> FoundCards { get; }

		void AddFoundCard(Guid cardId);
	}
}
