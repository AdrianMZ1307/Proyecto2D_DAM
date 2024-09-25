using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroyer : MonoBehaviour
{
    [SerializeField]
    private GameObject spawnPosition;
    [SerializeField]
    private GameObject[] terrains;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.tag == "Terrain")
        {
            Destroy(collision.gameObject);

            Vector3 position = new Vector3(
                spawnPosition.transform.position.x+1.3f,
                -1f,
                0f
                );

            GameObject randomAsteroid = terrains[Random.Range(0, terrains.Length)];

            GameObject terrain = Instantiate(randomAsteroid, position, Quaternion.Euler(new Vector3(0f, 0f, 0f)));

            terrain.transform.parent = GameObject.FindGameObjectWithTag("parentTerrain").transform;
        }
    }
}
