using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fallingRock : MonoBehaviour
{
    Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if( rb.IsSleeping() ) Destroy(gameObject);
    }

    void OnCollisionEnter(Collision collision)
    {
        GameObject other = collision.collider.gameObject;
        // if( !other.name.Contains("Rock") ) Debug.Log("collision with " + other.name);
        if( other.name.Contains("Sheep") ){
            other.GetComponent<Animator>().SetTrigger("destroy");
        }
    }
}
