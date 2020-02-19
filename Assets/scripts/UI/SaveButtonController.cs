using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;// Required when using Event data.

/**
 * Controller of Save Button on Password Create Scene
 */
public class SaveButtonController : MonoBehaviour, IPointerDownHandler, IPointerUpHandler {

	InputField TitleInput;
    InputField IDInput;
	InputField YourPassword;

    private PasswordManager PwManager = new PasswordManager ();

	private bool InputValidated () {
		if (TitleInput.text == "")
			return false;
		if (IDInput.text == "")
			return false;
		if (YourPassword.text == "")
			return false;

		return true;
	}

	private string GetCurrentTime () {
		return System.DateTime.Now.ToString ();
	}

	void Start () {
		TitleInput = GameObject.Find ("TitleInput").GetComponent<InputField> ();
        IDInput = GameObject.Find("IdInput").GetComponent<InputField> ();
		YourPassword = GameObject.Find ("YourPassword").GetComponent<InputField> ();
	}

	public void OnPointerDown (PointerEventData eventData) {
		//Do Nothing
	}

	public void OnPointerUp (PointerEventData eventData) {

		if (InputValidated ()) {
            string PwID;

            if (string.IsNullOrEmpty (CrossSceneData.CrossSceneInformation))
                PwID = PwManager.NumberOfPasswords ().ToString ();
            else
                PwID = CrossSceneData.CrossSceneInformation;

            PwManager.SavePasswordInfo(PwID, TitleInput.text, IDInput.text, YourPassword.text, GetCurrentTime());
            Camera.main.GetComponent<SceneController> ().changeScene ("HomeScreen");
		}
	}

}
