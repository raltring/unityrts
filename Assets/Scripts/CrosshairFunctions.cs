using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrosshairFunctions : MonoBehaviour
{
    public float aliveTime = 3;
    private float timeTillDead = 0;
    private 
    // Start is called before the first frame update
    void Start()
    {
        gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.activeSelf){
            timeTillDead -= Time.deltaTime;
            if(timeTillDead <= 0){
                gameObject.SetActive(false);
            }
        }
    }

    public void UpdateLocation(Vector2 location){
        gameObject.transform.position = location;
        MakeAlive();
    }

    void MakeAlive(){
        gameObject.SetActive(true);
        timeTillDead = aliveTime;
    }
}
