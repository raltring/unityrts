using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnUnit : MonoBehaviour
{
    public Rigidbody2D body;
    public BoxCollider2D collision;
    public GameObject warrior;
    // Start is called before the first frame update
    void Start()
    {
        gameObject.name = "User Barracks";
    }

    // Update is called once per frame
    void Update()
    {
        CheckMouseActivity();
    }

    void CheckMouseActivity(){
        if(Input.GetMouseButtonDown(0)){
            if(collision.OverlapPoint(Camera.main.ScreenToWorldPoint(Input.mousePosition))){
                gameObject.tag = "UserSelected";
                Debug.Log(string.Format("{0} Selected",gameObject.name));
            }
            else{
                gameObject.tag = "Untagged";
                Debug.Log(string.Format("{0} not selected",gameObject.name));
            }
        }

        if(Input.GetMouseButtonDown(1) && gameObject.tag == "UserSelected"){
            Vector2 position = transform.position;
            CreateWarrior(position);
        }
    }

    void CreateWarrior(Vector2 position){
        Quaternion rotation = new Quaternion(0,0,0,0);
        Instantiate(warrior, position, rotation);
    }
}
