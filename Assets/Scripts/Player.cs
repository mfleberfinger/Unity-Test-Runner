using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
	[Tooltip("Speed at which the player moves.")]
	public float speed = 20;

	private bool goUp, goDown;
	private Rigidbody rb;

	private void Start()
	{
		goUp = goDown = false;
		rb = GetComponent<Rigidbody>();
	}

	// Update is called once per frame
	void Update()
    {
        goUp = Input.GetKey("up");
		goDown = Input.GetKey("down");
    }

	private void FixedUpdate()
	{
		if (goUp)
			rb.velocity = Vector3.up * speed;
		else if (goDown)
			rb.velocity = Vector3.down * speed;
		else
			rb.velocity = Vector3.zero;
	}
}
