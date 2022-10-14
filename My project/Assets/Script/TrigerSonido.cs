using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrigerSonido : MonoBehaviour
{
    private bool yaHePasado;
    
    // Start is called before the first frame update
    void Start()
    {
        yaHePasado=false;
    }

    private void OnTriggerEnter(Collider other) {
      

    UnityEngine.Debug.Log("Atravesando el trigger");
    if(!yaHePasado){
        yaHePasado=true;
          AudioSource source=GetComponent<AudioSource>();
        source.Play();
    }
   }



}
