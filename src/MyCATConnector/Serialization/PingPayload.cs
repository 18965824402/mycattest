﻿using System;

namespace MyCat.Data.Serialization
{
	internal class PingPayload
	{
		public static PayloadData Create()
		{
			return new PayloadData(new ArraySegment<byte>(new[] { (byte) CommandKind.Ping }));
		}
	}
}
