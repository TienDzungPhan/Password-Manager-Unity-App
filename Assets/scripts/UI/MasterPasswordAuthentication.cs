using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;// Required when using Event data.

/**
 * Controller of Login Button on Login Screen
 */
public class MasterPasswordAuthentication : MonoBehaviour, IPointerDownHandler, IPointerUpHandler {

	InputField PasswordInput;

	private PasswordManager PwManager = new PasswordManager ();

	// Use this for initialization
	void Start () {
		PasswordInput = GameObject.Find ("PasswordInput").GetComponent<InputField> ();
	}

	public void OnPointerDown(PointerEventData eventData) {
		//Do Nothing
	}

	public void OnPointerUp(PointerEventData eventData) {

		if (PwManager.UserAuthenticated (PasswordInput.text)) {
			Camera.main.GetComponent<SceneController> ().changeScene ("HomeScreen");
		}

	}

}
