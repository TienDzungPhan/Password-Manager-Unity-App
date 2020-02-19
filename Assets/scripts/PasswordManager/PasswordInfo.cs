using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * Structure of a Password Object
 */
public class PasswordInfo
{
    public string PasswordTitle;
    public string UserID;
    public string PasswordValue;
    public string ModifiedDate;

    public PasswordInfo CreateFromJSON(string JsonString)
    {
        return JsonUtility.FromJson<PasswordInfo>(JsonString);
    }

    public string SaveToJson()
    {
        return JsonUtility.ToJson(this);
    }

}
