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
            Vector3 cameraMoveVector = new Vector3(moveVector.x, moveVector.z, 0);
            Camera.main.gameObject.transform.Translate(cameraMoveVector);
        }

        // Rotation
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = 10f;
        mousePos = Camera.main.ScreenToWorldPoint(mousePos);
        
        
        float angle = Mathf.Atan2(mousePos.x - transform.position.x, mousePos.z - transform.position.z) * Mathf.Rad2Deg;
        Vector3 rotationVector = new Vector3(0, angle, 0);
        transform.rotation = Quaternion.Euler(rotationVector);
    }
}
