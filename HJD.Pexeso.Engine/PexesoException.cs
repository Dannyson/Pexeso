using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HJD.Pexeso.Engine
{
	public class PexesoException : Exception
	{
		public PexesoException(string message): base(message)
		{
		}
	}
}
