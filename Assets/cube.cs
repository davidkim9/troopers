using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cube : MonoBehaviour {
    public float movespeed = 5;

	// Use this for initialization
	void Start () {
        print("test");
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
            transform.Translate(moveVector);
        }
	}
}
