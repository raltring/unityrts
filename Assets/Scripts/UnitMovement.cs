using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitMovement : MonoBehaviour
{
    public Rigidbody2D body;
    public BoxCollider2D collision;
    public float MAX_SPEED;
    public float APPROACH_DISTANCE;
    public SpriteRenderer m_SpriteRenderer;
    private Vector2 movePosition;
    private bool moving = false;
    
    // Start is called before the first frame update
    void Start(){
        gameObject.name = "Warrior1";
    }

    // Update is called once per frame
    void Update(){
        CheckMouseActivity();
        UpdatePosition();   
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

        if(gameObject.tag == "UserSelected" && Input.GetMouseButtonDown(1)){
            movePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            moving = true;
            //body.bodyType = RigidbodyType2D.Dynamic;
        }
    }

    void OnMouseDown(){
        transform.tag = "UserSelected";
    }

    void UpdatePosition(){
        if(moving == true){
            Vector2 transformPosition = transform.position;
            if(transformPosition.x > movePosition.x){
                m_SpriteRenderer.flipX = true;
            }
            else{
                m_SpriteRenderer.flipX = false;
            }            
            float distance = Vector2.Distance(transformPosition,movePosition);
            Debug.Log(string.Format("Distance between {0} and {1} is {2}",transformPosition, movePosition,
            distance));
            if(distance <= APPROACH_DISTANCE){
                moving = false;
                //body.bodyType = RigidbodyType2D.Static;
                Debug.Log(string.Format("{0} has reached its destination",gameObject.name));
            }
            else{
                Vector2 moveDirection = new(movePosition.x - transform.position.x,
                movePosition.y - transform.position.y);
                moveDirection.Normalize();
                transform.Translate(moveDirection * MAX_SPEED);
            }
        }
    }
}
