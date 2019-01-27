using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class SomeEditorScript : Editor
{
	/// <summary>
	/// Simple test method to see if testing scripts can access editor scripts.
	/// </summary>
	public static void TestOutput()
	{
		Debug.Log("Editor scripts are accessible.");
	}
}
