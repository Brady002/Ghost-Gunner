using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StrafeEnemy : MonoBehaviour
{

    private Rigidbody enemyRb; //sets a variable to a rigidbody
    public float speed; // speed variable
    private GameObject player; //sets a gameobject variable

    // Start is called before the first frame update
    void Start()
    {
        //grabs enemy rigidbody and player object
        enemyRb = GetComponent<Rigidbody>();
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        //moves strafe enemy around the player
        transform.RotateAround(player.transform.position, Vector3.up, 50 * Time.deltaTime);
        enemyRb.transform.position += ((player.transform.position - transform.position).normalized * speed * Time.deltaTime);
    }
}
