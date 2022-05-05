using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AxiePosition : AxieBehavior
{

    public string status;

    void Start()
    {
       // Debug.Log(status);
        spawn = GameObject.FindGameObjectWithTag("Tilemap").GetComponent<SpawnChar>();
    }

    void Update()
    {

    

    }
    public void setStatus()
    {

        if (transform.name == "axie2anim(Clone)")
        {
            status = "friend";

        }
        else status = "Enemy";
    }
}
