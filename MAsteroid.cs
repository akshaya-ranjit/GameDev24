using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MAsteroid : MonoBehaviour
{
    // Start is called before the first frame update
    Rigidbody2D rb;
    public Dinoid dinoPrefab;

    void Awake(){
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = new UnityEngine.Vector3(Random.Range(-2f, 2f), Random.Range(-2f, 2f), Random.Range(-2f, 2f));
        rb.AddTorque(Random.Range(-4f, 4f));
    }

    private void OnTriggerEnter2D(Collider2D other){
        if(!other.gameObject.CompareTag("LaserEye")&& !other.gameObject.CompareTag("Background")){
            UnityEngine.Vector2 lastPos = this.transform.position;
            Destroy(this.gameObject);
            Dinoid thisDA = Instantiate(dinoPrefab, lastPos, transform.localRotation);
            Dinoid thatDA = Instantiate(dinoPrefab, lastPos, transform.localRotation);
        }

        if(other.gameObject.CompareTag("Background")){
            Destroy(this.gameObject);
        }


    }
}
