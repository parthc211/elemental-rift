using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrol : MonoBehaviour {

    Transform player;
    public float speed = 5.0f;
    public float followdistance = 10;

    private GameObject pl;
    private void Start()
    {
        pl = GameObject.FindGameObjectWithTag("Player");
    }
    void Update()
    {
        player = pl.transform;
        var direction = player.position - transform.position;
        var angle = Vector3.Angle(direction, this.transform.forward);
        if (angle < 180 && direction.magnitude < followdistance)
        {
            var rotation = Quaternion.Slerp(
                this.transform.rotation, Quaternion.LookRotation(direction), Time.deltaTime);
            rotation.x = 0;
            rotation.z = 0;
            transform.rotation = rotation;

            if (direction.magnitude > 0.5f)
                transform.Translate(0, 0, Time.deltaTime * speed);
        }
    }
}
