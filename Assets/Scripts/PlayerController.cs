using UnityEngine;

public class PlayerController : MonoBehaviour {	
	public float movespeed = 5;
	public CameraController cameraController;
	public Unit unit;

	void Update () {
		Vector3 mousePos = Input.mousePosition;
		mousePos.z = 0;
		Vector3 mouseLocation = cameraController.cameraComponent.ScreenToWorldPoint (mousePos);
		Debug.Log ("mouse position3 " + cameraController.mouseLocation);
		Debug.Log ("mouse position3 " + mouseLocation);
		float xInput = 0;
		float yInput = 0;

		if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W))
			//move up
			yInput += 1;
		if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S))
			//move down
			yInput -= 1;
		if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
			//move right
			xInput += 1;
		if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
			//move left
			xInput -= 1;
		if (xInput != 0 || yInput != 0) {
			Vector3 moveVector = new Vector3(xInput, 0, yInput);
			moveVector = moveVector.normalized * movespeed * Time.deltaTime;

			transform.position = transform.position + moveVector;
		}

		// Rotation
		Vector3 relativeMousePos = cameraController.mouseLocation - transform.position;
		relativeMousePos.y = 0;
		float radian = Mathf.Atan2(relativeMousePos.x, relativeMousePos.z);
		float angle = radian * Mathf.Rad2Deg;
		Vector3 rotationVector = new Vector3(0, angle, 0);
		transform.rotation = Quaternion.Euler(rotationVector);


//		float cameraRadius = Mathf.Min(3, relativeMousePos.magnitude / 2);
//		Vector3 targetPosition = transform.position;
//		Vector3 cameraOffset = new Vector3(Mathf.Sin(radian) * cameraRadius, 0, Mathf.Cos(radian) * cameraRadius);
//		Vector3 cameraMoveVector = new Vector3(targetPosition.x, targetPosition.y + 10, targetPosition.z);
//		cameraMoveVector += cameraOffset;
//		Camera.main.gameObject.transform.position = cameraMoveVector; 
//		unit.cameraTarget.position = cameraMoveVector;
	}
}
