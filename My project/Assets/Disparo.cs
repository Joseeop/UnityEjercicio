using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Disparo : MonoBehaviour
{

    public GameObject bala;
    private long momentoUltimoDisparo;
    public GameObject objetivoDisparo;
    private long momentoActual;
    private bool accion;
    // Start is called before the first frame update
    void Start()
    {
        accion=true;
    }

    // Update is called once per frame
    void Update()
    {
      //GetMouseButtonDown detecta solo el instante 
        //En que se hace click
       /* if(Input.GetMouseButtonDown(0)){
            this.momentoUltimoDisparo=
            new DateTimeOffset(DateTime.UtcNow).ToUnixTimeMilliseconds();
            this.transform.LookAt(this.objetivoDisparo.transform.position);
             GameObject balaActual=Instantiate(bala,this.transform.position-this.transform.forward*1.2f,this.transform.rotation);
                balaActual.GetComponent<Rigidbody>().AddForce(balaActual.transform.forward*4000);

            
        }*/

        if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.DownArrow) ||Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.RightArrow)){
            accion = true;
        }
        //GetMouseButton se ejecuta continuamente mientras
        //El botón izquierdo esté pulstado
        
             if(accion==true){
            //Instanciando objetos a una distancia (también se puede usar transform.forward, dependiendo de donde estén los ejes del arma.
             this.momentoActual=
            new DateTimeOffset(DateTime.UtcNow).ToUnixTimeMilliseconds();
            if(momentoActual-momentoUltimoDisparo>3000){
                this.transform.LookAt(this.objetivoDisparo.transform.position);
                GameObject balaActual=Instantiate(bala,this.transform.position-this.transform.forward*1.2f,this.transform.rotation);
                balaActual.GetComponent<Rigidbody>().AddForce(balaActual.transform.forward*4000);
                this.momentoUltimoDisparo=momentoActual;
                
            }
        }
        
        
        
        
        
        
        
        /*if(Input.GetMouseButton(0)){
            //Instanciando objetos a una distancia (también se puede usar transform.forward, dependiendo de donde estén los ejes del arma.
             this.momentoActual=
            new DateTimeOffset(DateTime.UtcNow).ToUnixTimeMilliseconds();
            if(momentoActual-momentoUltimoDisparo>3000){
                this.transform.LookAt(this.objetivoDisparo.transform.position);
                GameObject balaActual=Instantiate(bala,this.transform.position-this.transform.forward*1.2f,this.transform.rotation);
                balaActual.GetComponent<Rigidbody>().AddForce(balaActual.transform.forward*4000);
                this.momentoUltimoDisparo=momentoActual;
                
            }
        }*/

    }
}
