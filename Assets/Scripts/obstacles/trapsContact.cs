using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trapsContact : MonoBehaviour
{
    private gameController gc;


    private void Awake()
    {
        GameObject goController = GameObject.FindGameObjectWithTag("gController");
        if (goController != null)
        {
            gc = goController.GetComponent<gameController>();
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Destroy(collision.gameObject);
            gc.GameOver();

        }
    }
}
