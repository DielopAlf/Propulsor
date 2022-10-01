using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playercontroller : MonoBehaviour
{
    Rigidbody2D body;
    Vector2 direction;

    [SerializeField]
    float impulse = 2f;
    //Start is called before the first frame update
    void Start ()
    {
    
    
    body = GetComponent<Rigidbody2D>();
    
    
    }
        
      
         
    

    // Update is called once per frame
    void Update()
    {



        direction.x = Input.GetAxis ("Horizontal") * Time.deltaTime * impulse;
        direction.y = Input.GetAxis ("Vertical") * Time.deltaTime * impulse;

    }
    private void FixedUpdate()
    {

      body.AddForce(direction, ForceMode2D.Impulse);
    
    }
    
}

    


