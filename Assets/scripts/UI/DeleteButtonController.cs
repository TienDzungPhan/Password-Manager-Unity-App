using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;// Required when using Event data.
using UnityEditor;

/**
 * Controller of Delete Button on Password Create Scene
 */
public class DeleteButtonController : MonoBehaviour, IPointerDownHandler, IPointerUpHandler {

	//GameObject SceneController;

	void Start () {
		if (string.IsNullOrEmpty (CrossSceneData.CrossSceneInformation))
			Destroy (gameObject);
	}

	public void OnPointerDown (PointerEventData eventData) {
		//Do Nothing
	}

	public void OnPointerUp (PointerEventData eventData) {
		bool DeleteConfirmed = EditorUtility.DisplayDialog("Are you sure to want to delete this Password and all related Information?", "You cannot undo this action！", "Delete", "Cancel");
		if (DeleteConfirmed) {
			PlayerPrefs.DeleteKey (CrossSceneData.CrossSceneInformation);
			Camera.main.GetComponent<SceneController>().changeScene ("HomeScreen");
		}
	}

}
