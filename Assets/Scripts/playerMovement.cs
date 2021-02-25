using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    Animator animator;
    public Rigidbody rb;
    //public GameObject myPrefab;

    public float rotSpeed;
    public float runSpeed;
    public float influenceSphereRadius;

    private bool isCarrying = false;
    private Animator pickableAnimator;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        rb = this.GetComponent<Rigidbody>();

        // Instantiate at position (0, 0, 0) and zero rotation.
        //Instantiate(myPrefab, new Vector3(758.37f, 7.2f, 753.28f), Quaternion.identity);
    }

    // Update is called once per frame
    void FixedUpdate()
    {        
        if(Input.GetAxis("Horizontal") < 0){
            // Move the object forward along its z axis 1 unit/second.
            transform.Rotate(-Vector3.up * rotSpeed * Time.deltaTime);
        }        
        if(Input.GetAxis("Horizontal") > 0){
            // Move the object forward along its z axis 1 unit/second.
            transform.Rotate(Vector3.up * rotSpeed * Time.deltaTime);
        }
        if(Input.GetAxis("Vertical") < 0){
            animator.SetBool("Running", true);
            // Move the object upward in world space 1 unit/second.
            rb.AddForce(-transform.forward * runSpeed);
            //transform.Translate(-transform.forward * Time.deltaTime, Space.World);
        }
        if(Input.GetAxis("Vertical") > 0){
            animator.SetBool("Running", true);
            // Move the object upward in world space 1 unit/second.
            rb.AddForce(transform.forward * runSpeed);
            //transform.Translate(transform.forward * Time.deltaTime, Space.World);
        }
        if(Input.GetAxis("Vertical") == 0){
            animator.SetBool("Running", false);
        }
        if(Input.GetButtonDown("Attack")){
            animator.SetTrigger("Attack");

            int foxLayerId = 9;
            int layerMask = 1 << foxLayerId;
            
            // FINDING NEIGHBOURS
            Collider[] ennemies = Physics.OverlapSphere(transform.position, influenceSphereRadius, layerMask);
            foreach (Collider ennemy in ennemies){
                Animator ennemyAnimator = ennemy.gameObject.GetComponent<Animator>(); 
                ennemyAnimator.SetTrigger("Die");
            }
        } 
        if(Input.GetButtonDown("Pick")){
            if( isCarrying == false ){
                int pickableObjectLayerId = 10;
                int layerMask = 1 << pickableObjectLayerId;
            
                // FINDING NEIGHBOURS
                Collider[] pickableObjects = Physics.OverlapSphere(transform.position, influenceSphereRadius, layerMask);
                foreach (Collider pickable in pickableObjects){
                    pickableAnimator = pickable.gameObject.GetComponent<Animator>(); 
                    pickableAnimator.SetBool("isPicked", true);
                    isCarrying = true;
                    break; // Ugly way to pick only first...
                           // because pickableObjects.length didn't seem to work...
                           // Quick solution was to used a loop without need to check existense... 
                           // TODO: find cleaner solution if I got time.
                }
            }
            else {
                pickableAnimator.SetBool("isPicked", false);                
                isCarrying = false;
            }

        } 
    }

    /*
    void OnTriggerEnter(Collider collider)
    {
        if( collider.name != "Terrain" ){
            Debug.Log(collider.name);
            animator.SetTrigger("Hit");
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision.collider.name);
        //if( collision.collider.name != "Terrain" )
    }
    */

}
