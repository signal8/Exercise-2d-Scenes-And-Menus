using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class asteroidSmall : MonoBehaviour
{
	private Rigidbody2D rb;

	public float initialSpeed = 1.5f;
	public int health = 2;

	// Start is called before the first frame update
	void Start()
	{
		bullet.hit += Explode;

		rb = gameObject.AddComponent<Rigidbody2D>() as Rigidbody2D;
		transform.Rotate(0.0f, 0.0f, Random.value * 360.0f);

		rb.velocity = initialSpeed * transform.up;
	}
	
	// Update is called once per frame
	void Update()
	{
        	transform.position = objectScreenWrap.wrap(transform.position);
    	}

	void Explode(float dmg)
	{
		health -= (int)dmg;
		if (health > 0) return;

		exploder x = GetComponent<exploder>();
		x.explode(transform.position);

		Destroy(gameObject);
	}
}
