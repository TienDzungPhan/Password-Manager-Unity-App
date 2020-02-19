using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;// Required when using Event data.

/**
 * Controller of Sign Up Button on Sign Up Screen
 */
public class SignUpController : MonoBehaviour, IPointerDownHandler, IPointerUpHandler {

	InputField PasswordInput;
	InputField PasswordReInput;

	private PasswordManager PwManager = new PasswordManager ();

	private bool InputValidated () {
		if (this.PasswordInput.text == "")
			return false;
		if (this.PasswordReInput.text == "")
			return false;
		if (this.PasswordInput.text != this.PasswordReInput.text)
			return false;
		
		return true;
	}

	void Start () {
		PasswordInput = GameObject.Find ("PasswordInput").GetComponent<InputField> ();
		PasswordReInput = GameObject.Find ("PasswordReInput").GetComponent<InputField> ();
	}

	public void OnPointerDown(PointerEventData eventData) {
		//Do Nothing
	}

	public void OnPointerUp(PointerEventData eventData) {

		if (InputValidated ()) {
			PwManager.CreateMasterPassword (PasswordInput.text);
			Camera.main.GetComponent<SceneController> ().changeScene ("Login_Screen");
		}

	}
}
