using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;// Required when using Event data.


/**
 * Controller of each Item on the Password list on Home Screen
 */
public class PasswordInfoController : MonoBehaviour, IPointerDownHandler, IPointerUpHandler {

    private string PasswordID;
    private PasswordManager PwManager = new PasswordManager ();
    private PasswordInfo PwInfo = new PasswordInfo();


    public void SetPasswordID (string ID)
    {
        PasswordID = ID;
    }

    private void SetPasswordInfo ()
    {
        PwInfo = PwManager.GetPasswordInfo (PasswordID);
    }

    private string GetModifiedDate (string ModTimeString) {

		System.DateTime CurrentTime = System.DateTime.Now;
		System.DateTime ModTime     = System.DateTime.Parse(ModTimeString);
        int TimeDiff = (int)(CurrentTime - ModTime).TotalSeconds; 
        // All processes related to Password Expiration are done in seconds to be easier to monitor
        //int TimeDiff = (int)(CurrentTime - ModTime).TotalDays;

        if (TimeDiff >= PwManager.GetPasswordExpirationSetting() && PwManager.GetPasswordExpirationSetting() != 0)
            transform.Find("ModifiedDate").GetComponent<Text>().color = Color.red;

        if (TimeDiff == 0)
			return "Changed today";
		else
			return string.Concat("Changed ", TimeDiff.ToString (), " day(s) ago");

	}

	private void DisplayToScreen () {
		transform.Find("PasswordTitle").GetComponent<Text>().text = PwInfo.PasswordTitle;
        transform.Find("UserID").GetComponent<Text>().text        = PwInfo.UserID;
        transform.Find("ModifiedDate").GetComponent<Text>().text = GetModifiedDate(PwInfo.ModifiedDate);
    }

    // Use this for initialization
    void Start () {
        SetPasswordInfo ();
		DisplayToScreen ();
    }

	public void OnPointerDown (PointerEventData eventData) {
		//Do Nothing
	}

	public void OnPointerUp (PointerEventData eventData) {
		CrossSceneData.CrossSceneInformation = PasswordID.ToString ();
		Application.LoadLevel ("PasswordCreateScene");
	}

}
