using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEditor;
using UnityEngine;

public class LaserEye : MonoBehaviour
{
    Rigidbody2D rb;
    public MAsteroid masterPrefab;
    public Dinoid dinoPrefab;
    public float speed = 2;
    void Awake(){
        rb = GetComponent<Rigidbody2D>();
    }

    void Update() 
    {    
        //transform.Translate(transform.forward * speed * Time.deltaTime);
    }

    public void Shoot(UnityEngine.Vector2 direction, UnityEngine.Vector2 speed){
        rb.velocity = direction+speed;
    }

    private void OnTriggerEnter2D(Collider2D other){
        if(other.gameObject.CompareTag("Background")){
            Destroy(this.gameObject);
        }

        Destroy(this.gameObject);
        if(other.gameObject.CompareTag("BigAsteroid")){
            UnityEngine.Vector2 lastPos = other.transform.position;
            Destroy(other.gameObject);
            MAsteroid thisMA = Instantiate(masterPrefab, lastPos, transform.localRotation);
            MAsteroid thatMA = Instantiate(masterPrefab, lastPos, transform.localRotation);
        }

        if(other.gameObject.CompareTag("MAsteroid")){
            UnityEngine.Vector2 lastPos = other.transform.position;
            Destroy(other.gameObject);
            Dinoid thisDA = Instantiate(dinoPrefab, lastPos, transform.localRotation);
            Dinoid thatDA = Instantiate(dinoPrefab, lastPos, transform.localRotation);
        }

    }


}
