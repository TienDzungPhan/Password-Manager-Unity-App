using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/**
 * Controller to initialize Password Create Scence
 * Show saved Password if the request to this scence is to Update Password
 */
public class PasswordController : MonoBehaviour {

	InputField TitleInput;
	InputField IDInput;
	InputField YourPassword;
	Slider PasswordLengthSlider;
	GameObject Warning;

    private PasswordManager PwManager = new PasswordManager ();
	private PasswordInfo PwInfo = new PasswordInfo();

    private int GetModifiedDate(string ModTimeString)
    {

        System.DateTime CurrentTime = System.DateTime.Now;
        System.DateTime ModTime = System.DateTime.Parse(ModTimeString);
        return (int)(CurrentTime - ModTime).TotalSeconds;
        // All processes related to Password Expiration are done in seconds to be easier to monitor
        //return (int)(CurrentTime - ModTime).TotalDays;

    }

    public void InitializeScene () {

		string RequestedPassword = CrossSceneData.CrossSceneInformation;

		if (!string.IsNullOrEmpty (RequestedPassword)) {

            PwInfo = PwManager.GetPasswordInfo (RequestedPassword);

			TitleInput.text   = PwInfo.PasswordTitle;
			IDInput.text      = PwInfo.UserID;
			YourPassword.text = PwInfo.PasswordValue;
			PasswordLengthSlider.value = PwInfo.PasswordValue.Length;
            if (GetModifiedDate (PwInfo.ModifiedDate) < PwManager.GetPasswordExpirationSetting () || PwManager.GetPasswordExpirationSetting () == 0)
                Destroy (Warning);

		}
		if (string.IsNullOrEmpty (RequestedPassword))
			Destroy (Warning);

	}


	// Use this for initialization
	void Start () {
		TitleInput = GameObject.Find ("TitleInput").GetComponent<InputField> ();
		IDInput = GameObject.Find("IdInput").GetComponent<InputField> ();
		YourPassword = GameObject.Find ("YourPassword").GetComponent<InputField> ();
		PasswordLengthSlider = GameObject.Find ("PasswordLengthSlider").GetComponent<Slider> ();
		Warning = GameObject.Find("WarningSection");
		InitializeScene ();
	}
	
}
