using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamShake : MonoBehaviour {

    public float power = 0.7f;
    public float duration = 1.0f;
    public Transform camPos;
    public float slowDownRate = 1.0f;
    public bool shakeNow = false;

    Vector3 startPos;
    float initDuration;

    private void Start()
    {
        camPos = Camera.main.transform;
        startPos = camPos.localPosition;
        initDuration = duration;
    }

    private void Update()
    {
        if (shakeNow)
        {
            if(duration > 0)
            {
                camPos.localPosition = startPos + Random.insideUnitSphere * power;
                duration -= Time.deltaTime * slowDownRate;
            }
            else
            {
                shakeNow = false;
                duration = initDuration;
                camPos.localPosition = startPos;
            }
        }
    }
}
