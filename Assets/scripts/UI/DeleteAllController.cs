using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEditor;

/**
 * Controller of Delete All Button on Settings Screen
 */
public class DeleteAllController : MonoBehaviour, IPointerDownHandler, IPointerUpHandler {

	private void DeleteAllPasswords () {
		int num = 0;
		while (PlayerPrefs.HasKey (num.ToString ())) {
			PlayerPrefs.DeleteKey (num.ToString ());
			num++;
		}
	}

	public void OnPointerUp (PointerEventData eventData) {
		//Do Nothing
	}

	public void OnPointerDown (PointerEventData eventData) {
		bool DeleteConfirmed = EditorUtility.DisplayDialog("削除しますか？", "削除したデータは復元できません！", "削除", "キャンセル");
		if (DeleteConfirmed) {
			this.DeleteAllPasswords ();
			Camera.main.GetComponent<SceneController> ().changeScene ("HomeScreen");
		}
	}

}
