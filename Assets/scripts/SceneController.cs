using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * Main route of the application
 */
public class SceneController : MonoBehaviour {

	public void changeScene (string sceneName) {
		Application.LoadLevel (sceneName);
	}

}
