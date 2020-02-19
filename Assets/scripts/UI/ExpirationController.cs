using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/**
 * Controller of Expiration Dropdown in Settings Screen
 */
public class ExpirationController : MonoBehaviour {

    private PasswordManager PwManager = new PasswordManager ();
    
    public void SaveExpirationSetting ()
    {
        int Time = 0;

        switch (this.gameObject.GetComponent<Dropdown> ().value)
        {
            case 1:
                Time = 30;
                break;

            case 2:
                Time = 90;
                break;

            case 3:
                Time = 180;
                break;

            case 4:
                Time = 365;
                break;

            default:
                break;
        }

        PwManager.SavePasswordExpirationSetting (Time);
    }

    void Start ()
    {
        switch (PwManager.GetPasswordExpirationSetting ())
        {
            case 0:
                this.gameObject.GetComponent<Dropdown>().value = 0;
                break;

            case 30:
                this.gameObject.GetComponent<Dropdown>().value = 1;
                break;

            case 90:
                this.gameObject.GetComponent<Dropdown>().value = 2;
                break;

            case 180:
                this.gameObject.GetComponent<Dropdown>().value = 3;
                break;

            case 365:
                this.gameObject.GetComponent<Dropdown>().value = 4;
                break;

            default:
                break;
        }

    }
}
