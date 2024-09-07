using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    // Start is called before the first frame update
   Rigidbody2D rb;

    void Awake(){
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnTriggerEnter2D(Collider2D other){
        if(other.gameObject.CompareTag("LaserEye")){
            Destroy(this.gameObject);
        }

        if(other.gameObject.CompareTag("Cow 31")){
            Destroy(other.gameObject);
        }

    }
}
