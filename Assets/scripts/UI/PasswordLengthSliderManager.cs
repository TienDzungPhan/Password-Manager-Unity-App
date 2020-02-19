using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/**
 * Controller of Password Length Slider on Password Create Scene
 */
public class PasswordLengthSliderManager : MonoBehaviour {

	Text SliderValue;
	Slider PasswordLengthSlider;

	void Start() {
		this.SliderValue = GameObject.Find ("SliderValue").GetComponent<Text> ();
		this.PasswordLengthSlider = GameObject.Find ("PasswordLengthSlider").GetComponent<Slider> ();
	}

	void Update() {
		this.SliderValue.text = this.PasswordLengthSlider.value.ToString ();
	}
}
