using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cube : MonoBehaviour {
    public float movespeed = 5;

	// Use this for initialization
	void Start () {
        print(Camera.main.gameObject.transform.position);
	}

    // Update is called once per frame
    void Update() {
        float xInput = 0; // Input.GetAxis("Horizontal");
        float yInput = 0; // Input.GetAxis("Vertical");

        if (Input.GetKey(KeyCode.UpArrow))
            //move up
            yInput += 1;
        if (Input.GetKey(KeyCode.DownArrow))
            //move down
            yInput -= 1;
        if (Input.GetKey(KeyCode.RightArrow))
            //move right
            xInput += 1;
        if (Input.GetKey(KeyCode.LeftArrow))
            //move left
            xInput -= 1;
        if (xInput != 0 || yInput != 0) {
            Vector3 moveVector = new Vector3(xInput, 0, yInput);
            moveVector = moveVector.normalized * movespeed * Time.deltaTime;

            transform.position = transform.position + moveVector;
        }

        // Rotation
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = 10f;
        mousePos = Camera.main.ScreenToWorldPoint(mousePos);
        Vector3 relativeMousePos = mousePos - transform.position;
        relativeMousePos.y = 0;
        float radian = Mathf.Atan2(relativeMousePos.x, relativeMousePos.z);
        float angle = radian * Mathf.Rad2Deg;
        Vector3 rotationVector = new Vector3(0, angle, 0);
        transform.rotation = Quaternion.Euler(rotationVector);

        // Camera Shit
        float cameraRadius = Mathf.Min(3, relativeMousePos.magnitude * 0.5f);
        Vector3 cameraOffset = new Vector3(Mathf.Sin(radian) * cameraRadius, 0, Mathf.Cos(radian) * cameraRadius);
        Vector3 cameraMoveVector = new Vector3(transform.position.x, 10, transform.position.z);
        cameraMoveVector += cameraOffset;
        Camera.main.gameObject.transform.position = cameraMoveVector; 
    }
}
