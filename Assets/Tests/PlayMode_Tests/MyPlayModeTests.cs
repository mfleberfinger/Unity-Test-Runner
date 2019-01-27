using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
	// These "tests" were written to verify that the test runner was running
	// tests as expected. The attributes identifying them as tests have been
	// commented out to avoid having them show up in the test runner.
	public class MyPlayModeTests
	{
		// A Test behaves as an ordinary method
		//[Test]
		public void MyPlayModeTestsSimplePasses()
		{
			// Use the Assert class to test conditions
			Debug.Log("PlayMode tests run.");
			GameManager.TestOutput();
		}

		// A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
		// `yield return null;` to skip a frame.
		//[UnityTest]
		public IEnumerator MyPlayModeTestsWithEnumeratorPasses()
		{
			// Use the Assert class to test conditions.
			// Use yield to skip a frame.
			Debug.Log("PlayMode test with enumerator passes runs...");

			for (int i = 0; i < 5; i++)
			{
				Debug.Log(string.Format("{0} seconds have passed.", i));
				yield return new WaitForSeconds(1f);
			}
		
			yield return null;
		}
	}
}