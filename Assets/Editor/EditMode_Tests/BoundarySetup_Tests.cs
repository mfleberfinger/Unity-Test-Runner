using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
	/// <summary>
	/// Tests whether the game boundary is set up correctly in the scene.
	/// </summary>
    public class BoundarySetup_Tests
    {
		/// <summary>
		/// Make sure the boundary is in the scene.
		/// </summary>
        [Test]
		public void Boundary_Found_Test()
		{
			Assert.That(GetBoundary(), Is.Not.Null);
		}

		/// <summary>
		/// Make sure the boundary has its collider.
		/// </summary>
		[Test]
		public void Boundary_Has_BoxCollider_Test()
		{
			GameObject boundary = GetBoundary();
			Assume.That(boundary, Is.Not.Null);
			Assert.That(boundary.GetComponent<BoxCollider>(), Is.Not.Null);
		}

		/// <summary>
		/// Make sure the boundary's collider is a trigger.
		/// </summary>
		[Test]
		public void Collider_Is_Trigger_Test()
		{
			GameObject boundary = null;
			Collider col = null;

			// Assumptions and setup.
			boundary = GetBoundary();
			Assume.That(boundary, Is.Not.Null);
			col = boundary.GetComponent<BoxCollider>();
			Assume.That(col, Is.Not.Null);

			// Assertion
			Assert.That(col.isTrigger, Is.True);
		}

		/// <summary>
		/// Make sure the boundary has its script attached.
		/// </summary>
		[Test]
		public void Boundary_Has_Boundary_Script_Test()
		{
			GameObject boundary = GetBoundary();
			Assume.That(boundary, Is.Not.Null);
			Assert.That(boundary.GetComponent<Boundary>(), Is.Not.Null);
		}

		/// <summary>
		/// Make sure the values of the boundary script set through the editor
		/// are correct.
		/// </summary>
		[Test]
		public void Boundary_Script_Configured_Test()
		{
			GameObject go = null;
			Boundary script = null;
			
			// Assumptions and setup.
			go = GetBoundary();
			Assume.That(go, Is.Not.Null);
			script = go.GetComponent<Boundary>();
			Assume.That(script, Is.Not.Null);
			
			// Assertions
			Assert.That(script.ball, Is.Not.Null);
			Assert.That(script.ballSpawn, Is.Not.Null);
		}

		/// <summary>
		/// Finds the boundary in the scene.
		/// </summary>
		/// <returns>an object with the "Boundary" tag or <c>null</c></returns>
		private GameObject GetBoundary()
		{
			return GameObject.FindGameObjectWithTag("Boundary");
		}
    }
}
