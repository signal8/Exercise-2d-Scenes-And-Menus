using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class explosion : MonoBehaviour
{
	public void TriggerAnimationEvent(string msg)
	{
		if (msg == "end") Destroy(gameObject);
	}
}
