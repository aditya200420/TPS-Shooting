using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BulletProjectile : MonoBehaviour
{
    [SerializeField] private Transform vfxHitBlue;
    [SerializeField] private Transform vfxHitYellow;
    private Rigidbody bulletRigidbody;
  
     

    private void Awake()
    {
        bulletRigidbody = GetComponent<Rigidbody>();
       

    }
    // Start is called before the first frame update
    void Start()
    {
        float speed = 80f;
        bulletRigidbody.velocity = transform.forward * speed;
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.GetComponent<BulletTarget>() != null)
        {
            Instantiate(vfxHitBlue, transform.position, Quaternion.identity);
        }
        else
        {
            Instantiate(vfxHitYellow, transform.position, Quaternion.identity);
        }
        Destroy(gameObject);

    }
    
    
}
