using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class terrainController : MonoBehaviour
{
    [SerializeField]
    private float speed;

    private float floorSpeed = 1.0f;

    private gameController gc;


    private void Awake()
    {
        GameObject goController = GameObject.FindGameObjectWithTag("gController");
        if (goController != null)
        {
            gc = goController.GetComponent<gameController>();
        }
    }
    void FixedUpdate()
    {
        if (!gc.gameOver)
        {
            transform.position = new Vector3(Vector3.left.x * floorSpeed * Time.fixedDeltaTime, -1f, 0f);
            floorSpeed += speed;
        }
    }
}
