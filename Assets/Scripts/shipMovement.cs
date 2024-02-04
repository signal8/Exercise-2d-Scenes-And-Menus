using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shipMovement : MonoBehaviour
{
	private Vector3 shipPosition;
	private bool isDying = false;
	private Rigidbody2D rb;
	private SpriteRenderer sr;
	private BoxCollider2D bc;
	private float cooldown = 0.0f;
	private float timer = 0.0f;

	public float speed = 5.0f;
	public float accelPerSecond = 5.0f;
	public float currentSpeed = 0.0f;
	public float maxSpeed = 10.0f;
	public GameObject exhaustObject;
	public GameObject bulletPoint;
	public GameObject bulletPrefab;

	void Start()
	{
		rb = GetComponent<Rigidbody2D>();
		sr = GetComponent<SpriteRenderer>();
		bc = GetComponent<BoxCollider2D>();
		bullet.hit += Die;
	}

	// Update is called once per frame
	void Update()
	{
		if (isDying == true || timer > 0.0f)
		{
			timer -= Time.deltaTime;
			return;
		}
		else
		{
			sr.enabled = true;
			bc.enabled = true;
			isDying = false;
			transform.position = Vector3.zero;
			transform.rotation = Quaternion.identity;
		}


		if (Input.GetKey("w"))
		{
			exhaustObject.SetActive(true);
			currentSpeed += accelPerSecond * Time.deltaTime;
		} 
		else 
		{
			exhaustObject.SetActive(false);
			currentSpeed -= accelPerSecond * Time.deltaTime;
		}

		Mathf.Clamp(currentSpeed, 0.0f, maxSpeed);

		if (Input.GetKey("a"))
		{
			transform.rotation = Quaternion.Euler(0, 0, 
					90.0f * Time.deltaTime);
		} 
		else if (Input.GetKey("d"))
		{
			transform.rotation = Quaternion.Euler(0, 0, 
					-90.0f * Time.deltaTime);
		}

		rb.velocity = transform.up * currentSpeed;

		transform.position = objectScreenWrap.wrap(transform.position);

		if ((Input.GetKey("space")) && (cooldown <= 0.0f))
		{
			cooldown = 0.2f;
			Instantiate(bulletPrefab, bulletPoint.transform.position
					, transform.rotation);
		}
		else if (cooldown > 0.0f) cooldown -= Time.deltaTime;
	}

	void Die(float dmg)
	{
		isDying = true;
		exploder x = GetComponent<exploder>();
		x.explode(transform.position);

		sr.enabled = false;
		bc.enabled = false;
	}
}
