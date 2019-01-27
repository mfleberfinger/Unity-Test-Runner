using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
	/// <summary>
	/// Tests whether the player is correctly set up in the scene.
	/// </summary>
    public class PlayerSetup_Tests
    {

		/// <summary>
		/// Make sure the player is in the scene.
		/// </summary>
        [Test]
		public void Player_Found_Test()
		{
			Assert.That(GetPlayer(), Is.Not.Null);
		}

		/// <summary>
		/// Make sure the player has a box collider.
		/// </summary>
		[Test]
		public void Player_Has_BoxCollider_Test()
		{
			GameObject player = GetPlayer();
			Assume.That(player, Is.Not.Null);
			Assert.That(player.GetComponent<BoxCollider>(), Is.Not.Null);
		}

		/// <summary>
		/// Make sure the Player script is attached to the player.
		/// </summary>
		[Test]
		public void Player_Has_Player_Script_Test()
		{
			GameObject player = GetPlayer();
			Assume.That(player, Is.Not.Null);
			Assert.That(player.GetComponent<Player>(), Is.Not.Null);
		}

		/// <summary>
		/// Make sure the player has a Rigidbody component.
		/// </summary>
		[Test]
		public void Player_Has_Rigidbody_Test()
		{
			GameObject player = GetPlayer();
			Assume.That(player, Is.Not.Null);
			Assert.That(player.GetComponent<Rigidbody>(), Is.Not.Null);
		}

		/// <summary>
		/// Verify that the player's Rigidbody has the required settings.
		/// </summary>
		[Test]
		public void Rigidbody_Configuration_Test()
		{
			GameObject player = null;
			Rigidbody rb = null;

			// Assumptions and test setup.
			player = GetPlayer();
			Assume.That(player, Is.Not.Null);
			rb = player.GetComponent<Rigidbody>();
			Assume.That(rb, Is.Not.Null);

			// Assertions for Rigidbody configuration.
			Assert.That(rb.drag, Is.Zero, "Drag should be zero.");
			Assert.That(rb.useGravity, Is.False, "Gravity should be off.");
			Assert.That(rb.collisionDetectionMode, Is.EqualTo(CollisionDetectionMode.Continuous),
				"Should use continuous collision detection.");
			RigidbodyConstraints constraints = RigidbodyConstraints.FreezeAll &
				(~ RigidbodyConstraints.FreezePositionY);
			Assert.That(rb.constraints, Is.EqualTo(constraints), "Constraints are" +
				" wrong.");
		}

		/// <summary>
		/// Finds the player in the scene.
		/// </summary>
		/// <returns>an object with the "Player" tag or <c>null</c></returns>
		private GameObject GetPlayer()
		{
			return GameObject.FindGameObjectWithTag("Player");
		}
    }
}
