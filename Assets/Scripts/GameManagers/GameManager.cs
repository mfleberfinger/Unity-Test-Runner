// Script to represent some "game logic" to give us something to test.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
	// Start is called before the first frame update
	void Start()
	{
        
	}

	// Update is called once per frame
	void Update()
	{
        
	}


	/// <summary>
	/// Returns true.
	/// </summary>
	/// <returns><c>true</c></returns>
	public bool ReturnTrue()
	{
		return true;
	}

	/// <summary>
	/// Returns true, most of the time.
	/// </summary>
	/// <param name="i">Mock parameter</param>
	/// <returns><c>true</c>, unless it's <c>false</c></returns>
	public bool BuggyReturnTrue(int i)
	{
		if (i % 5 == 0)
			return false;
		else
			return true;
	}

	/// <summary>
	/// Used to see whether game logic scripts can be accessed via test scripts.
	/// </summary>
	public static void TestOutput()
	{
		Debug.Log("Game logic is accessible.");
	}
}
