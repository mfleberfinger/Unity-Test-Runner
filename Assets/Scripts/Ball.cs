using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Starts the ball moving in some direction and limits speed.
/// </summary>
public class Ball : MonoBehaviour
{
	[Tooltip("Ball goes this fast.")]
	public float speed = 10f;

	private Rigidbody rb = null;

	// Initialize variables and start moving.
    void Start()
    {
		Vector2 random = Random.insideUnitCircle.normalized;
		random = random * speed;
		rb = gameObject.GetComponent<Rigidbody>();

		rb.velocity = new Vector3(random.x, random.y, 0f);
	}

	// Regulate speed.
	private void FixedUpdate()
	{
		if (rb.velocity.magnitude > speed + 3)
			rb.velocity = rb.velocity.normalized * speed;
	}
}
