using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBall : MonoBehaviour {

    public GameObject blastCollider;
    private GameObject colliderObj;

    private Input_Manager im;
    private GameObject player;
    private Vector3 initialPos;
    private Vector3 finalPos;
    private float speed;
    private float timeToReachTargetPosition;
    private float time;

    public GameObject afterEffect;
    // Use this for initialization
    void Start() {
        player = GameObject.FindGameObjectWithTag("Player");
        im = player.GetComponent<Input_Manager>();
        //initialPos = im.initialfb;
        initialPos = gameObject.transform.position;
        finalPos = im.finalfb;
        speed = 20.0f;
        time = 0.0f;
        timeToReachTargetPosition = Vector3.Distance(initialPos, finalPos) / speed;
    }

    // Update is called once per frame
    void Update() {

        
        if (time < 1)
        {
            time += Time.deltaTime / timeToReachTargetPosition;    // Get the current time gap
            transform.position = Vector3.Lerp(initialPos, finalPos, time);    // Set the position accordingly
        }

        if (time >= 1)
        {
            colliderObj = (GameObject)Instantiate(blastCollider, transform.position, transform.rotation);
            GameObject ae = (GameObject)Instantiate(afterEffect, finalPos, Quaternion.identity);
            Destroy(ae, 1.5f);
            Destroy(gameObject);
        }
    }
}
