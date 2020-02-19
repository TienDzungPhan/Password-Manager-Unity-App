using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using UnityEngine;

/**
 * Encrypt / Decrypt data with AES algorithm
 */
public class Crytography {

	// Create Shared Key and Initialization Vector (IV)
	private string pw;
	private string salt;

	private RijndaelManaged GetRijndael () {
		RijndaelManaged rijndael = new RijndaelManaged ();
		rijndael.KeySize = 128;
		rijndael.BlockSize = 128;

		byte[] bSalt = Encoding.UTF8.GetBytes (salt);
		Rfc2898DeriveBytes deriveBytes = new Rfc2898DeriveBytes (pw, bSalt);
		deriveBytes.IterationCount = 1000;       

		rijndael.Key = deriveBytes.GetBytes (rijndael.KeySize / 8);
		rijndael.IV = deriveBytes.GetBytes (rijndael.BlockSize / 8);

		return rijndael;
	}


	private void SetKey (string Password, string s) 
	{
		pw = Password;
		salt = string.Concat (s, "P455w0rdM4n4g3r");
	}

	public string Encrypt (string plain_data, string Salt, string Password = null) {

		if (Password == null)
			Password = PlayerPrefs.GetString ("MasterPassword");
		SetKey (Password, Salt);

		RijndaelManaged rijndael = new RijndaelManaged ();
		rijndael = this.GetRijndael ();

		// Encrypting
		byte[] bData = Encoding.UTF8.GetBytes (plain_data);
		ICryptoTransform encryptor = rijndael.CreateEncryptor ();
		byte[] encrypted = encryptor.TransformFinalBlock (bData, 0, bData.Length);

		encryptor.Dispose ();

		return System.Convert.ToBase64String(encrypted);
	
	}

	public string Decrypt (string encrypted_data, string Salt, string Password = null) {

		if (Password == null)
			Password = PlayerPrefs.GetString ("MasterPassword");
		SetKey (Password, Salt);

		RijndaelManaged rijndael = new RijndaelManaged ();
		rijndael = this.GetRijndael ();

		// Decrypting
		byte[] bEncrypt = System.Convert.FromBase64String (encrypted_data);
		ICryptoTransform decryptor = rijndael.CreateDecryptor ();
		byte[] plain = decryptor.TransformFinalBlock (bEncrypt, 0, bEncrypt.Length);

		decryptor.Dispose ();

		return System.Text.Encoding.ASCII.GetString(plain);

	}
		
}