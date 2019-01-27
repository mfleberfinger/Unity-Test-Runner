using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    public class Boundary_Tests
    {
		/// <summary>
		/// Verify that when a GameObject with the "Ball" label leaves the space
		/// defined by a GameObject with a trigger and a Boundary script
		/// component, that the "Ball" is destroyed.
		/// </summary>
		/// <returns></returns>
        [UnityTest]
		public IEnumerator Boundary_Destroy_Respawn_Test()
		{
			GameObject boundary = null;
			GameObject ball = null;
			GameObject ballPrefab = null;
			GameObject ballSpawn = null;
			Watcher watcher = null;

			ballSpawn = new GameObject();
			ballSpawn.transform.position = Vector3.zero;
			ball = CreateBall();
			// An inactive gameobject must be created to replace the ball prefab
			// expected by the Boundary script.
			ballPrefab = CreateBall();
			ballPrefab.SetActive(false);
			boundary = CreateBoundary(ballSpawn.transform, ballPrefab);
			watcher = boundary.GetComponent<Watcher>();

			// Get the ball moving and wait for it to go out of bounds.
			ball.GetComponent<Rigidbody>().velocity = new Vector3(100f, 0f, 0f);

			while (!watcher.IsTestFinished)
				yield return new WaitForFixedUpdate();
			// After the ball passes through the boundary, give the Destroy()
			// call a few ticks to occur.
			for(int i = 0; i < 3; i++)
				yield return new WaitForFixedUpdate();
			
			// Make sure that the ball was destroyed.
			// Workaround for Unity implementation detail that breaks normal
			// null checking...
			// https://answers.unity.com/questions/865405/nunit-notnull-assert-strangeness.html
			// https://answers.unity.com/questions/524998/testing-for-null-bug-or-feature.html
			Assert.That(ball == null, Is.True, "Ball was not destroyed.");

			// Make sure that a new ball has spawned to replace the destroyed ball.
			ball = GameObject.FindGameObjectWithTag("Ball");
			Assert.That(ball == null, Is.False, "Ball did not respawn.");

			yield return null;
		}

		/// <summary>
		/// Creates a simplified test ball in the scene.
		/// </summary>
		/// <returns>A stationary ball at the scene origin.</returns>
		private GameObject CreateBall()
		{
			GameObject ball = new GameObject();
			SphereCollider col = ball.AddComponent<SphereCollider>();
			Rigidbody rb = ball.AddComponent<Rigidbody>();
			
			ball.tag = "Ball";
			ball.transform.position = Vector3.zero;
			ball.transform.localScale = Vector3.one;
			col.center = Vector3.zero;
			col.radius = 0.5f;
			rb.useGravity = false;

			return ball;
		}

		/// <summary>
		/// Creates a minimal boundary object in the scene. The boundary object
		/// will have the Watcher script attached for testing.
		/// </summary>
		/// <param name="ball">GameObject to replace the ball prefab.</param>
		/// <param name="ballSpawn">Spawnpoint for the ball.</param>
		/// <returns>A boundary game object at the scene origin.</returns>
		private GameObject CreateBoundary(Transform ballSpawn, GameObject ball)
		{
			GameObject boundaryGO = new GameObject();
			BoxCollider col = boundaryGO.AddComponent<BoxCollider>();
			Boundary boundaryScript = null;

			boundaryGO.transform.position = Vector3.zero;
			boundaryGO.transform.localScale = Vector3.one;
			col.isTrigger = true;
			col.center = Vector3.zero;
			col.size = new Vector3(2f, 2f, 2f);
			boundaryScript = boundaryGO.AddComponent<Boundary>();
			boundaryScript.ball = ball;
			boundaryScript.ballSpawn = ballSpawn;
			boundaryGO.AddComponent<Watcher>();

			return boundaryGO;
		}

		/// <summary>
		/// Allows the test to know when the ball passes through the boundary.
		/// </summary>
		public class Watcher : MonoBehaviour
		{
			private bool triggered = false;

			public bool IsTestFinished
			{
				get { return triggered; }
			}

			private void OnTriggerExit(Collider other)
			{
				triggered = true;
			}
		}
    }
}
