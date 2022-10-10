using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreezePowerUp : MonoBehaviour
{
    public float freeze; //length of time for freeze power
    //public GameObject powerUpIndicator; //indicator on screen to show power is active

    private void OnTriggerEnter(Collider other)
    {
        //needs rigidbody and collider set to 'is trigger'
        if (other.CompareTag("bullet"))
        {
            Debug.Log("powerup start");
            StartCoroutine(PowerupCountdown()); //calls method

            this.GetComponent<MeshRenderer>().enabled = false; //disables mesh so object is invisible
            this.GetComponent<SphereCollider>().enabled = false; //disables sphere collider so it can't be activated again

            //can't destroy object here because IEnumerator doesn't work if the object it's on is destroyed

            //powerUpIndicator.gameObject.SetActive(true); //indicator is activated
        }
    }
    IEnumerator PowerupCountdown()
    {
        EnemyController[] enemies = FindObjectsOfType<EnemyController>(); //looks for all objects in scene with EnemyController script attached
        StrafeEnemy[] strafers = FindObjectsOfType<StrafeEnemy>(); //looks for all objects in scene with StrafeEnemy script attached

        foreach (EnemyController enemy in enemies) //loops for all objects that were found with EnemyController script
        {
            enemy.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll; //freezes all the position and rotation constraints in the rigidbody
            enemy.GetComponent<EnemyController>().enabled = false; //disables the script component
        }
        foreach (StrafeEnemy enemy in strafers) //loops for all objects that were found with StrafeEnemy script
        {
            enemy.GetComponent<StrafeEnemy>().enabled = false;
        }

        Debug.Log("powerup timer started");
        yield return new WaitForSeconds(freeze); //counts in seconds for the number 'freeze' is set to in the freeze power's prefab
        Debug.Log("powerup timer ended");

        //these just do put things back to where they were
        foreach (EnemyController enemy in enemies)
        {
            enemy.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
            enemy.GetComponent<EnemyController>().enabled = true;
        }
        foreach (StrafeEnemy enemy in strafers)
        {
            enemy.GetComponent<StrafeEnemy>().enabled = true;
        }

        Debug.Log("powerup end");
        //powerUpIndicator.gameObject.SetActive(false); //turns off indicator
        Destroy(gameObject, 5f);
    }
}