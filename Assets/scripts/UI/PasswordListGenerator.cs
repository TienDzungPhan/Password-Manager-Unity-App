using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/**
 * Generate a list of saved Password on Home Screen
 * (Using Prefab)
 */
public class PasswordListGenerator : MonoBehaviour {

    Text TotalPasswordsText;

	public GameObject Parent;
	public GameObject PasswordPrefab;

    private PasswordManager PwManager = new PasswordManager();

	// Use this for initialization
	void Start () {

        TotalPasswordsText = GameObject.Find("TotalPasswordsText").GetComponent<Text> ();

		for (int i = 0; i < PwManager.NumberOfPasswords (); i++) {
			GameObject newPasswordPrefab = Instantiate (PasswordPrefab, new Vector3(0, 140 - i*70, 0), Quaternion.identity) as GameObject;
			newPasswordPrefab.transform.SetParent (Parent.transform, false);
            newPasswordPrefab.GetComponent<PasswordInfoController> ().SetPasswordID (i.ToString ());
            TotalPasswordsText.text = "Total " + (i+1).ToString () + " Password(s)"; 
		}

		CrossSceneData.CrossSceneInformation = "";

	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
