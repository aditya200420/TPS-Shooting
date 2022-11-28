using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDestroyer : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {

       
        if(collision .gameObject.CompareTag("Enemy"))
        {
            Destroy(collision.gameObject, 5f);
        }
    }
}
