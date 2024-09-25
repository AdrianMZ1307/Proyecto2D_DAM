using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraController : MonoBehaviour
{
    [SerializeField]
    private float delay = 0.125f;

    [SerializeField]
    private Vector3 offset = new Vector3(0f,0f,0f);

    private GameObject objective;

    void Start()
    {
        objective = GameObject.FindGameObjectWithTag("Player");
    }

    void FixedUpdate()
    {
        if (objective != null)
        {
            Vector3 finalPosition = new Vector3(objective.transform.position.x + offset.x, 0f,-10f);
            Vector3 delayPosition = Vector3.Lerp(transform.position, finalPosition, delay);
            transform.position = delayPosition;
        }
    }
}
