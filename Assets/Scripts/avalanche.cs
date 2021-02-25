using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class avalanche : MonoBehaviour
{

    public GameObject rockPrefab;
    
    public float period = 1.0f;
    private float nextActionTime = 0.0f;
    
    
     // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame 
    void Update () {
        if (Time.time > nextActionTime ) {
            nextActionTime = Time.time + period;

            // Instantiate at position (0, 0, 0) and zero rotation.
            Instantiate(rockPrefab, 
                        new Vector3(Random.Range(-10.0f, -12.0f),
                                    Random.Range( 20.0f,  30.0f), 
                                    Random.Range( 30.0f,  39.0f)), 
                        new Quaternion (Random.Range(-180.0f, 180.0f), 
                                        Random.Range(-180.0f, 180.0f),
                                        Random.Range(-180.0f, 180.0f), 
                                        1), 
                        transform);
        }
    }
}
