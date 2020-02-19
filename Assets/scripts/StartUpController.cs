using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/**
 * Route to Sign Up Screen if User doesn't have Master Password
 */
public class StartUpController : MonoBehaviour {

	// Use this for initialization
	void Start () {
		if (!PlayerPrefs.HasKey("MasterPassword"))
			SceneManager.LoadScene("SignUp_Screen");
	}

}
