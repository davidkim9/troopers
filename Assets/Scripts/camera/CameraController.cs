using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Camera))]
public class CameraController : MonoBehaviour {

	public Transform cameraTarget;
	public Camera cameraComponent;

	void Start() {
		cameraComponent = GetComponent<Camera> ();
	}

	// Update is called once per frame
	void Update () {
		CameraTarget pov = cameraTarget.GetComponent<CameraTarget> ();
		if (pov != null) {
//			cameraComponent.gameObject.transform.position = pov.position;
		} else {
//			cameraComponent.gameObject.transform.position = cameraTarget.position; 
		}
	}

	public Vector3 mouseLocation {
		get {
			Vector3 mousePos = Input.mousePosition;
//			mousePos.z = 0;
			return cameraComponent.ScreenToWorldPoint (mousePos);
		}
	}
}
