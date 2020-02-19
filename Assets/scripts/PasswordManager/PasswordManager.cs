using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

/**
 * The Password Manager
 */
public class PasswordManager {

    /**
     * Generate Password
     */

     // Dictionary
    private const string DIC_Numbers = "0123456789";
    private const string DIC_Alphabet = "abcdefghijklmnopqrstuvwxyz";
    private const string DIC_ALPHABET = "ABCDEFGHIJKLMOPQRSTUVWXYZ";
    private const string DIC_SpecialChars = " !\"#$%&'()*+,-./:;<=>?@[\\]^_`{|}~";

    // Get random class
    private static System.Random rand = new System.Random();

    // Get a random character from given Dictionary
    private char GetChar(string Dictionary)
    {
        int pos = rand.Next(Dictionary.Length);
        char c = Dictionary[pos];

        return c;
    }

    /**
     * Generate New Password from given length and Type of Characters to be used 
     * Objectives:
     *  1. Put 1 charater of each required Type (Dictionary) to a random position in the main Password string
     *  2. For remaining positions, randomly put characters of all Types (Dictionaries) 
     */
    public string GeneratePassword(int length, bool UseAlphabet, bool UseALPHABET, bool UseNumbers, bool UseSpecialChars)
    {
        string Dictionary = null;
        string Password = new string('0', length);
        StringBuilder sb = new StringBuilder(Password);

        int a_pos, A_pos, num_pos, sc_pos;

        a_pos = -1; A_pos = -1; num_pos = -1; sc_pos = -1;

        if (UseAlphabet)
        {
            Dictionary = string.Concat(Dictionary, DIC_Alphabet);
            a_pos = rand.Next(length);
        }

        if (UseALPHABET)
        {
            Dictionary = string.Concat(Dictionary, DIC_ALPHABET);
            do
            {
                A_pos = rand.Next(length);
            } while (A_pos == a_pos);
        }

        if (UseNumbers)
        {
            Dictionary = string.Concat(Dictionary, DIC_Numbers);
            do
            {
                num_pos = rand.Next(length);
            } while (num_pos == a_pos || num_pos == A_pos);
        }

        if (UseSpecialChars)
        {
            Dictionary = string.Concat(Dictionary, DIC_SpecialChars);
            do
            {
                sc_pos = rand.Next(length);
            } while (sc_pos == a_pos || sc_pos == A_pos || sc_pos == num_pos);
        }

        for (int i = 0; i < length; i++)
        {
            if (i == a_pos) sb[i] = this.GetChar(DIC_Alphabet);
            else if (i == A_pos) sb[i] = this.GetChar(DIC_ALPHABET);
            else if (i == num_pos) sb[i] = this.GetChar(DIC_Numbers);
            else if (i == sc_pos) sb[i] = this.GetChar(DIC_SpecialChars);
            else sb[i] = this.GetChar(Dictionary);

            Password = sb.ToString();
        }

        return Password;
    }

    /**
     * Return total number of Passwords
     */
    public int NumberOfPasswords ()
    {
        int num = 0;

        while (PlayerPrefs.HasKey(num.ToString()))
            num++;

        return num;

    }

    /**
     * Save Password and related Information
     */
    public void SavePasswordInfo (string PwID, string Title, string User, string PwValue, string ModDate)
    {
        PasswordInfo PwInfo = new PasswordInfo ();
        Crytography  Encryptor = new Crytography ();
        string PasswordJson;
        string EncryptedData;

        PwInfo.PasswordTitle = Title;
        PwInfo.UserID = User;
        PwInfo.PasswordValue = PwValue;
        PwInfo.ModifiedDate = ModDate;

        PasswordJson = PwInfo.SaveToJson ();
        EncryptedData = Encryptor.Encrypt (PasswordJson, PwID);

        PlayerPrefs.SetString (PwID, EncryptedData);

    }

    /**
     * Get Password and related Information
     */
    public PasswordInfo GetPasswordInfo (string PwID)
    {
        PasswordInfo PwInfo = new PasswordInfo ();
        Crytography  Decryptor = new Crytography ();
        string EncrytedData;
        string PlainJson;

        EncrytedData = PlayerPrefs.GetString(PwID);
		PlainJson = Decryptor.Decrypt (EncrytedData, PwID);

        PwInfo = PwInfo.CreateFromJSON (PlainJson);

        return PwInfo;
    }

	/**
	 * Data re-Encryption with Master Password
     * The Master Password is used as a parameter to Encrypt/Decrypt data
     * Hence every time a new Master Password is set, all data must first be decrypted using old Password before being encrypted using new one
	 */
	private void ReEncryptData(string OldPassword) 
	{
		Crytography Crypto = new Crytography ();

		for (int i = 0; i < NumberOfPasswords (); i++) {
			string PasswordData = PlayerPrefs.GetString (i.ToString ());
			PasswordData = Crypto.Decrypt (PasswordData, i.ToString (), OldPassword);
			PlayerPrefs.SetString (i.ToString (), Crypto.Encrypt (PasswordData, i.ToString ()));
		}
	}

    /**
     * Create new Master Password
     * Master Password will be hashed before saving
     * If old Password existed, all data must be re-encrypted
     */
	public void CreateMasterPassword (string NewPassword)
	{
		if (!PlayerPrefs.HasKey ("MasterPassword"))
			PlayerPrefs.SetString ("MasterPassword", NewPassword.GetHashCode ().ToString ());
		else {
			string OldPassword = PlayerPrefs.GetString ("MasterPassword");
			PlayerPrefs.SetString ("MasterPassword", NewPassword.GetHashCode ().ToString ());
			ReEncryptData (OldPassword);
		}
	}

	/**
	 * Authenticate Master Password
	 */
	public bool UserAuthenticated (string Input) 
	{
		string MasterPassword = PlayerPrefs.GetString ("MasterPassword");

		if (Input.GetHashCode().ToString () != MasterPassword)
			return false;

		return true;
	}

    /**
     * Save Password Expiration Setting 
     */
    public void SavePasswordExpirationSetting (int Time)
    {
        PlayerPrefs.SetInt ("PasswordExpiration", Time);
    }

    /*
     * Get Password Expiration Setting 
     */
    public int GetPasswordExpirationSetting ()
    {
        if (!PlayerPrefs.HasKey("PasswordExpiration"))
            return 2;

        return PlayerPrefs.GetInt ("PasswordExpiration");
    }

}
