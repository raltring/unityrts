using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public float MAX_SPEED = 1.0f;
    public GameObject crosshair;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ShiftCamera();
        CheckMouseState();
    }

    void ShiftCamera(){
        //Evaluate horizontal direction
        if(Input.GetKey(KeyCode.D)){
            transform.Translate(Vector3.right * MAX_SPEED);
        }
        else if(Input.GetKey(KeyCode.A)){
            transform.Translate(Vector3.left * MAX_SPEED);
        }
        //Evaluate vertical direction
        if(Input.GetKey(KeyCode.W)){
            transform.Translate(Vector3.up * MAX_SPEED);
        }
        else if(Input.GetKey(KeyCode.S)){
            transform.Translate(Vector3.down * MAX_SPEED);
        }
    }

    void CheckMouseState(){
        if(Input.GetMouseButtonDown(1)){
            CrosshairFunctions script = crosshair.GetComponent<CrosshairFunctions>();
            Vector2 location = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            script.UpdateLocation(location);
        }
    }
}
