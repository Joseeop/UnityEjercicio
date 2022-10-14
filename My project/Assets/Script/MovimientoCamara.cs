using System.Diagnostics;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoCamara : MonoBehaviour
{
    public float velocidad=10;
    private float multiplicadorTurbo=1;
    private HashSet<GameObject> terrenosActuales;
    private HashSet<KeyCode> teclasMovimientoPulsadas;
    public float velocidadRotacion=10;



    private void OnGUI() {
        Event e=Event.current;

        if(e.type.Equals(EventType.KeyDown)){
            if(e.keyCode==KeyCode.UpArrow||e.keyCode==KeyCode.DownArrow
            ||e.keyCode==KeyCode.LeftArrow||e.keyCode==KeyCode.RightArrow){
                teclasMovimientoPulsadas.Add(e.keyCode);
            }
        }
        if(e.type.Equals(EventType.KeyUp)){
            if(e.keyCode==KeyCode.UpArrow||e.keyCode==KeyCode.DownArrow
            ||e.keyCode==KeyCode.LeftArrow||e.keyCode==KeyCode.RightArrow){
                teclasMovimientoPulsadas.Remove(e.keyCode);
            }
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        terrenosActuales=new HashSet<GameObject>();
        teclasMovimientoPulsadas=new HashSet<KeyCode>();
    }

    // Update is called once per frame
    void Update()
    {
        float anguloY=velocidadRotacion*Input.GetAxis("Mouse X");
        transform.Rotate(0,anguloY,0);

        if(this.terrenosActuales.Count>0){
            if (Input.GetKey(KeyCode.LeftShift))
            {
                multiplicadorTurbo=5;
            }else{
                multiplicadorTurbo=1;
            }

            if(Input.GetKey(KeyCode.Q)){
                this.transform.Rotate(0,velocidad*Time.deltaTime,0);
            }
            if(Input.GetKey(KeyCode.E)){
                this.transform.Rotate(0,-velocidad*Time.deltaTime,0);
            }
            
            if(teclasMovimientoPulsadas.Contains(KeyCode.UpArrow)){
                transform.Translate(transform.forward*Time.deltaTime*velocidad,Space.World);
                
           }
            if(teclasMovimientoPulsadas.Contains(KeyCode.DownArrow)){
                transform.Translate(-transform.forward*Time.deltaTime*velocidad,Space.World);
                
           }
            if(teclasMovimientoPulsadas.Contains(KeyCode.LeftArrow)){
                this.transform.Rotate(0,-0.5f,0);
               
            }
            if(teclasMovimientoPulsadas.Contains(KeyCode.RightArrow)){
                this.transform.Rotate(0,0.5f,0);
                
             }
            if(Input.GetKey(KeyCode.Space)){
                this.GetComponent<Rigidbody>().AddForce(0,200*velocidad,0);
            }
            if(teclasMovimientoPulsadas.Contains(KeyCode.UpArrow)&&
            teclasMovimientoPulsadas.Contains(KeyCode.LeftArrow)){
                
                transform.Translate(new Vector3(0.7f*multiplicadorTurbo*velocidad*Time.deltaTime,0,
                0.7f*multiplicadorTurbo*velocidad*Time.deltaTime),Space.World);
                
            }
            if(teclasMovimientoPulsadas.Contains(KeyCode.UpArrow)&&
            teclasMovimientoPulsadas.Contains(KeyCode.RightArrow)){
                transform.Translate(new Vector3(0.7f*multiplicadorTurbo*velocidad*Time.deltaTime,0,
                -0.7f*multiplicadorTurbo*velocidad*Time.deltaTime),Space.World);
               
            }
            if(teclasMovimientoPulsadas.Contains(KeyCode.DownArrow)&&
            teclasMovimientoPulsadas.Contains(KeyCode.LeftArrow)){ 
                transform.Translate(new Vector3(-0.7f*multiplicadorTurbo*velocidad*Time.deltaTime,0,
                0.7f*multiplicadorTurbo*velocidad*Time.deltaTime),Space.World);
                
            
            }
            if(teclasMovimientoPulsadas.Contains(KeyCode.DownArrow)&&
            teclasMovimientoPulsadas.Contains(KeyCode.RightArrow)){
                transform.Translate(new Vector3(-0.7f*multiplicadorTurbo*velocidad*Time.deltaTime,0,
                -0.7f*multiplicadorTurbo*velocidad*Time.deltaTime),Space.World);
               
            }
        }   
     
    }

    private void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.tag==("Terreno")){
            this.terrenosActuales.Add(other.gameObject);
        }
    }

    private void OnCollisionExit(Collision other)
    {
        if(other.gameObject.tag==("Terreno")){
            this.terrenosActuales.Remove(other.gameObject);
        }
        
    }
}
  
