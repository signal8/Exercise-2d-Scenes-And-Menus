using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class objectScreenWrap
{
	public static Vector3 wrap(Vector3 pos)
	{
		if (pos.x > 9.41f) pos.x = -9.4f;
		else if (pos.x < -9.41f) pos.x = 9.4f;

		if (pos.y > 5.31f) pos.y = -5.3f;
		else if (pos.y < -5.31f) pos.y = 5.3f;

		return pos;
	}
}
