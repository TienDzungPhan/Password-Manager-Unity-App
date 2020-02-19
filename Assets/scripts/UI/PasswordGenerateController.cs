using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;// Required when using Event data.

/**
 * Controller of Password Generate Button on Password Create Scence
 */
public class PasswordGenerateController : MonoBehaviour, IPointerDownHandler, IPointerUpHandler {

	InputField YourPassword;
    Slider     PasswordLengthSlider;
	Toggle     AlphabetToggle, ALPHABETToggle, NumbersToggle, SpecialCharsToggle ;

    private PasswordManager Generator = new PasswordManager ();


    private void ShowPassword () {
        int PasswordLength = (int)PasswordLengthSlider.value;
        YourPassword.text = Generator.GeneratePassword (PasswordLength, AlphabetToggle.isOn, ALPHABETToggle.isOn, NumbersToggle.isOn, SpecialCharsToggle.isOn);
	}


	void Start () {
		YourPassword         = GameObject.Find ("YourPassword").GetComponent<InputField> ();
        PasswordLengthSlider = GameObject.Find("PasswordLengthSlider").GetComponent<Slider>();
		AlphabetToggle       = GameObject.Find ("AlphabetToggle").GetComponent<Toggle> ();
		ALPHABETToggle       = GameObject.Find ("ALPHABETToggle").GetComponent<Toggle> ();
		NumbersToggle        = GameObject.Find ("NumbersToggle").GetComponent<Toggle> ();
		SpecialCharsToggle   = GameObject.Find ("SpecialCharsToggle").GetComponent<Toggle> ();

		PasswordLengthSlider.value = 8;
	}

	public void OnPointerDown (PointerEventData eventData) {
		// Do Nothing
	}

	public void OnPointerUp (PointerEventData eventData) {
		ShowPassword ();
	}

}
