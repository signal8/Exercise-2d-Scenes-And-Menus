using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyBullet : MonoBehaviour
{
	private Rigidbody2D rb;
	private float timer = 0.0f;
	
	public GameObject ship;
	public float speed = 4.0f;
	public float damage = 1.0f;

	// Start is called before the first frame update
	void Start()
	{
		if (ship != null) rb.velocity = 
			Vector3.Normalize(ship.transform.position 
			- transform.position) * speed;
		else 
		{
			Debug.Log("COULD NOT FIND SHIP");
			Destroy(gameObject);
		}
	}

	// Update is called once per frame
	void Update()
	{
		timer += Time.deltaTime;
		if (timer >= 5) Destroy(gameObject);
	}

	void OnTriggerEnter2D(Collider2D col)
	{
		bullet.hit?.Invoke(damage);
		Destroy(gameObject);
	}
}
