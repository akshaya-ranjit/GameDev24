using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerEntry : MonoBehaviour
{
    // Start is called before the first frame update    
    Rigidbody2D rb;
    public float speed;
    public float vertical;
    private Vector2 startpos;
    private Vector2 initforce;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        startpos = new Vector2(0, 0);
        initforce = new Vector2(0, speed);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate(){
        if (rb.position.y <= startpos.y){
            speed = 2;
            vertical = 2;
            rb.AddForce(initforce, ForceMode2D.Force);
            transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, transform.eulerAngles.z + 2);
        }else{
            vertical = 0;
        }

        rb.velocity = new Vector2(rb.velocity.x, vertical*speed);
    }

    void OnSceneChange(){
        SceneManager.LoadScene (sceneName:"Playing Scene");
    }
}
