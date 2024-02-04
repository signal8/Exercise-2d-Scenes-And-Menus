using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class exploder : MonoBehaviour
{
	public GameObject explosion;

	public void explode(Vector3 pos)
	{
		Instantiate(explosion, pos, Quaternion.identity);
	}
}
