using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dinoid : MonoBehaviour
{
    // Start is called before the first frame update
    Rigidbody2D rb;

    void Awake(){
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = new UnityEngine.Vector3(Random.Range(-3f, 3f), Random.Range(-3f, 3f), Random.Range(-3f, 3f));
        rb.AddTorque(Random.Range(-4f, 4f));
    }

    private void OnTriggerEnter2D(Collider2D other){
        if(other.gameObject.CompareTag("LaserEye")){
            Destroy(this.gameObject);
            Destroy(other.gameObject);
        }

        if(other.gameObject.CompareTag("Background")){
            Destroy(this.gameObject);
        }


    }
}
