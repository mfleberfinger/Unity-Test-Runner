using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Destroy the ball and spawn another if the ball goes out of bounds.
/// </summary>
public class Boundary : MonoBehaviour
{
	[Tooltip("The ball prefab.")]
	public GameObject ball = null;
	[Tooltip("Where to spawn the ball.")]
	public Transform ballSpawn = null;

	private void OnTriggerExit(Collider other)
	{
		if (other.tag == "Ball")
		{
			Destroy(other.gameObject);
			GameObject newBall = Instantiate(ball, ballSpawn.position,
				ballSpawn.rotation);
			
			// Added for compatibility with the Boundary_Destroy_Respawn_Test()...
			// which seems like a stupid reason to add code to the implementation.
			newBall.SetActive(true);
		}
	}
}
