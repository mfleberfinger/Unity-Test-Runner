using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
	/// <summary>
	/// Tests whether the ball is set up correctly in the scene.
	/// </summary>
	public class BallSetup_Tests
	{
		/// <summary>
		/// Make sure that the ball is in the scene.
		/// </summary>
		[Test]
		public void Ball_Found_Test()
		{
			Assert.That(GetBall(), Is.Not.Null);
		}

		/// <summary>
		/// Make sure the ball has a Rigidbody component.
		/// </summary>
		[Test]
		public void Ball_Has_Rigidbody_Test()
		{
			GameObject ball = GetBall();
			Assume.That(ball, Is.Not.Null);
			Assert.That(ball.GetComponent<Rigidbody>(), Is.Not.Null);
		}

		/// <summary>
		/// Make sure the ball has a Sphere Collider.
		/// </summary>
		[Test]
		public void Ball_Has_SphereCollider_Test()
		{
			GameObject ball = GetBall();
			Assume.That(ball, Is.Not.Null);
			Assert.That(ball.GetComponent<SphereCollider>(), Is.Not.Null);
		}
		
		/// <summary>
		/// Make sure that the ball's physic material will allow it to bounce
		/// forever.
		/// </summary>
		[Test]
		public void Ball_Physic_Material_Test()
		{
			GameObject ball = null;
			Collider col = null;
			PhysicMaterial mat = null;

			// Assumptions and setup
			ball = GetBall();
			Assume.That(ball, Is.Not.Null);
			col = ball.GetComponent<SphereCollider>();
			Assume.That(col, Is.Not.Null);
			mat = col.material;

			// Assertions for physics material
			Assert.That(mat.dynamicFriction, Is.Zero);
			Assert.That(mat.staticFriction, Is.Zero);
			Assert.That(mat.bounciness, Is.EqualTo(1f));
			Assert.That(mat.frictionCombine,
				Is.EqualTo(PhysicMaterialCombine.Minimum));
			Assert.That(mat.bounceCombine,
				Is.EqualTo(PhysicMaterialCombine.Maximum));
		}

		/// <summary>
		/// Make sure the ball has the Ball script.
		/// </summary>
		[Test]
		public void Ball_Has_Ball_Script_Test()
		{
			GameObject ball = GetBall();
			Assume.That(ball, Is.Not.Null);
			Assert.That(ball.GetComponent<Ball>(), Is.Not.Null);
		}

		/// <summary>
		/// Verify that the ball's Rigidbody has the required settings.
		/// </summary>
		[Test]
		public void Rigidbody_Configuration_Test()
		{
			GameObject ball = null;
			Rigidbody rb = null;

			// Assumptions and test setup.
			ball = GetBall();
			Assume.That(ball, Is.Not.Null);
			rb = ball.GetComponent<Rigidbody>();
			Assume.That(rb, Is.Not.Null);

			// Assertions for Rigidbody configuration.
			Assert.That(rb.drag, Is.Zero, "Drag should be zero.");
			Assert.That(rb.useGravity, Is.False, "Gravity should be off.");
			Assert.That(rb.collisionDetectionMode, Is.EqualTo(CollisionDetectionMode.Continuous),
				"Should use continuous collision detection.");
			RigidbodyConstraints constraints = RigidbodyConstraints.FreezePositionZ;
			Assert.That(rb.constraints, Is.EqualTo(constraints), "Constraints are" +
				" wrong.");
		}

		/// <summary>
		/// Finds the ball in the scene.
		/// </summary>
		/// <returns>an object with the "Ball" tag or <c>null</c></returns>
		private GameObject GetBall()
		{
			return GameObject.FindGameObjectWithTag("Ball");
		}
	}
}
