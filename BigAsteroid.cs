using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigAsteroid : MonoBehaviour
{
    // Start is called before the first frame update
    Rigidbody2D rb;
    public MAsteroid masterPrefab;

    void Awake(){
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = new UnityEngine.Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f));
        rb.AddTorque(Random.Range(-4f, 4f));
    }

    void FixedUpdate(){
        //rb.velocity = new UnityEngine.Vector2(Random.Range(-4f, 4f), Random.Range(-4f, 4f));
    }

    private void OnTriggerEnter2D(Collider2D other){
        if(!other.gameObject.CompareTag("LaserEye") && !other.gameObject.CompareTag("Background")){
            UnityEngine.Vector2 lastPos = this.transform.position; //the this might be the problem
            Destroy(this.gameObject);
            MAsteroid thisMA = Instantiate(masterPrefab, lastPos, transform.localRotation);
            MAsteroid thatMA = Instantiate(masterPrefab, lastPos, transform.localRotation);
        }

        if(other.gameObject.CompareTag("Background")){
            Destroy(this.gameObject);
        }

    }
}
