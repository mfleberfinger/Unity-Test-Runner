using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
	/// <summary>
	/// Tests for the Ball script.
	/// </summary>
    public class Ball_Tests
    {
		/// <summary>
		/// Make sure the Ball script causes what it is attached to to move.
		/// </summary>
		/// <returns></returns>
        [UnityTest]
		public IEnumerator Ball_Moves_Test()
		{
			GameObject ball = CreateBall();
			Vector3 initialPosition = ball.transform.position;
			
			yield return new WaitForFixedUpdate();

			Assert.That(ball.transform.position, Is.Not.EqualTo(initialPosition));

			yield return null;
		}

		/// <summary>
		/// Make sure that the Ball script limits the speed of the ball.
		/// </summary>
		/// <returns></returns>
		[UnityTest]
		public IEnumerator Ball_Speed_Limit_Test()
		{
			GameObject ball = CreateBall();
			Ball script = ball.GetComponent<Ball>();
			Rigidbody rb = ball.GetComponent<Rigidbody>();

			script.speed = 10;

			// Give the script a tick to set the initial speed.
			yield return new WaitForFixedUpdate();
			// Break the speed limit.
			rb.velocity = Vector3.one * 50;
			// Wait for correction.
			yield return new WaitForFixedUpdate();
			// Assert speed limit.
			Assert.That(rb.velocity.magnitude, Is.LessThanOrEqualTo(script.speed));

			yield return null;
		}

		/// <summary>
		/// Make sure ball bouncing works against paddle
		/// </summary>
		/// <returns></returns>
        [UnityTest]
		public IEnumerator Ball_Bounce_Test()
		{
			GameObject ball = CreateBall();
			Ball script = ball.GetComponent<Ball>();
			Rigidbody rb = ball.GetComponent<Rigidbody>();

			script.speed = 10;

            Vector3 ogvec = Vector3.right * 10;
            rb.velocity = ogvec;

			Vector3 initialPosition = ball.transform.position;

            

			yield return new WaitUntil(() => (ball.GetComponent<Rigidbody>().velocity != ogvec));

			Assert.That(ball.GetComponent<Rigidbody>().velocity.magnitude, Is.EqualTo(ogvec.magnitude),
                "Checking that bounce is lossless");

			yield return null;
		}

		/// <summary>
		/// Creates a test ball in the scene.
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
			ball.AddComponent<Ball>();

			return ball;
		}
    }
}
