using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class toca : MonoBehaviour
{
    public AudioSource quienemite;
    public AudioClip elsonido;
    public float volumen = 1f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter (Collider other){
        quienemite.PlayOneShot(elsonido, volumen);
        Destroy(gameObject, 0.4f);
    }
}
