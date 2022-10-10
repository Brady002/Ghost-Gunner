using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    //declares rigidbody, speed and player variables
    private Rigidbody enemyRb;
    public float speed;
    private GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        //grabs rigidbody and player from scene
        enemyRb = GetComponent<Rigidbody>();
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        //moves enemy to player
        transform.LookAt(player.transform);

        enemyRb.position += ((player.transform.position - transform.position).normalized * speed * Time.deltaTime);
    }
}
