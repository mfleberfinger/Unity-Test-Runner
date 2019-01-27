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
    public class MyEditModeTests
    {
        // A Test behaves as an ordinary method
        //[Test]
        public void MyEditModeTestsSimplePasses()
        {
            // Use the Assert class to test conditions
			Debug.Log("EditMode tests run.");
			GameManager.TestOutput();
			SomeEditorScript.TestOutput();
        }

        // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
        // `yield return null;` to skip a frame.
        //[UnityTest]
        public IEnumerator MyEditModeTestsWithEnumeratorPasses()
        {
            // Use the Assert class to test conditions.
            // Use yield to skip a frame.
			Debug.Log("EditMode test with enumerator passes runs...");

			for (int i = 0; i < 3; i++)
			{
				Debug.Log(string.Format("{0} frames have been skipped.", i));
				yield return null;
			}
		
			yield return null;
        }

		/// <summary>
		/// Make sure there is a properly configured main camera in the scene.
		/// Another example use case for something like this: checking that the
		/// XR rig is present and configured properly.
		/// </summary>
		//[Test]
		public void CameraTest()
		{
			string noTaggedObjectMsg = "There is no game object with the" +
				" \"MainCamera\" tag.";
			string noCameraComponentMsg = "The object tagged with" +
				" \"MainCamera\" does not have a camera component.";
			GameObject cameraObject = null;
			Camera cameraComponent = null;
			
			cameraObject = GameObject.FindGameObjectWithTag("MainCamera");
			//Assert.IsNotNull(cameraObject, noTaggedObjectMsg);
			Assert.That(cameraObject, Is.Not.Null, noTaggedObjectMsg);
			cameraComponent = cameraObject.GetComponent<Camera>();
			//Assert.IsNotNull(cameraComponent, noCameraComponentMsg);
			Assert.That(cameraComponent, Is.Not.Null, noCameraComponentMsg);
		}

    }
}
