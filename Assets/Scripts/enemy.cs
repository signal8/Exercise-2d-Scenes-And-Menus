using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour
{
	private float timer = 0.0f;
	private Vector3 pos;

	public int leftSpeed = 3;
	public int health = 1;
	public GameObject bulletPrefab;

	void Start() { bullet.hit += Explode; }

	// Update is called once per frame
	void Update()
	{
		pos = transform.position;
		
		timer += Time.deltaTime;
		if (timer >= 2.0f) Instantiate(bulletPrefab, pos,
				Quaternion.identity);

		pos.x += leftSpeed * Time.deltaTime;
		pos.y += Mathf.Sin(pos.x) * (leftSpeed * Time.deltaTime);

		transform.position = objectScreenWrap.wrap(pos);
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
