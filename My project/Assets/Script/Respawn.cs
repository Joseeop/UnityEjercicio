using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour
{
    private Rigidbody body;
    // Start is called before the first frame update
    void Start()
    {
         body=GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.y <56){
            //POSICIÓN A LA QUE SE VA A TELETRANSPORTAR
            body.transform.position=new Vector3(195,61,225);
        }
    }
}// COMENTARIO PRUEBA GIT