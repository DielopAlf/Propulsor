using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Playercontroller : MonoBehaviour
{
    Rigidbody2D body;
    Vector2 direction;

    [SerializeField]
    float IMPULSE = 2f;

    [SerializeField]
    TextMeshProUGUI labelFuel;


    float gasolinaActual = 100f;


    [SerializeField]
    GameObject prefabParticles;

    [SerializeField]
    GameObject deadScreen;

    [SerializeField]
  
    void Start()
    {

        gasolinaActual = 100f;
        body = GetComponent<Rigidbody2D>();


    }






    void Update()
    {



        direction.x = Input.GetAxis("Horizontal") * Time.deltaTime * IMPULSE;
        direction.y = Input.GetAxis("Vertical") * Time.deltaTime * IMPULSE;

        gasolinaActual = gasolinaActual - 1f * Time.deltaTime;
        labelFuel.text = gasolinaActual.ToString("00") + "%";


        if (gasolinaActual <= 0.0f)
        {

           deadScreen.SetActive(true);
           this.enabled = false;
        }

    }
    private void FixedUpdate()
    {

        body.AddForce(direction, ForceMode2D.Impulse);
    }
    private void OnTriggerEnter2D(Collider2D collision)

    {
        if (collision.tag == "fuel" && gasolinaActual> 0.0f)
        {
            gasolinaActual += 10f;
            if (gasolinaActual > 100f)
            {
                gasolinaActual = 100f;

            }
            //reproducir sonido
            collision.GetComponent<AudioSource>().Play();
            //desactivar colisiones
            collision.enabled = false;
            //creat particulas
            Instantiate(prefabParticles, collision.transform.position, collision.transform.rotation);
            //destruirlo en 0.2segundos
            Destroy(collision.gameObject,0.2f);


        }
    }
    public void ClickEnBoton()
    {
        
        Debug.Log("ha clicado");
        SceneManager.LoadScene(0);        
    
    }
}


    


