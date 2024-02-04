using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
	private Rigidbody2D rb;
	private SpriteRenderer sr;
	private float timer = 0.0f;
	private Color bulletColor;

	public delegate void Hit(float dmg);
	public static Hit hit;
	public float speed = 4.0f;
	public float damage = 1.0f;

	// Start is called before the first frame update
	void Start()
	{
        	rb = gameObject.GetComponent<Rigidbody2D>();
		sr = gameObject.GetComponent<SpriteRenderer>();
		bulletColor = new Color(1,1,1,1);

		rb.velocity = speed * transform.up;
	}
	
	// Update is called once per frame
	void Update()
	{
        	timer += Time.deltaTime;
		Debug.Log(timer);
		sr.color = bulletColor * (1 - (timer / 4));

		if (timer >= 2) Destroy(gameObject);
	}

	void OnTriggerEnter2D(Collider2D col)
	{
		hit?.Invoke(damage);
		Destroy(gameObject);
	}
}
