using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public GameObject bullet; //variable for a game object which is a bullet

    void Update()
    {
        //when the bullet position is less than or equal to -10, the bullet will be destroyed
        //this is used for performce 
        if (bullet.transform.position.y <= -10)
        {
            Destroy(bullet);
        }
    }
}
