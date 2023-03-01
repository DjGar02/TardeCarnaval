using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Rotacioncoin : MonoBehaviour
{

    public float velocidad;

    // Start is called before the first frame update
    void Start()
    {
	transform.Rotate(90,0,0);
    if(SceneManager.GetActiveScene().name == "tercerNivel"){
        Destroy(this.gameObject, 2.5f);
    }else{
        Destroy(this.gameObject, 5f);
    }
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.up, Time.deltaTime * velocidad, Space.World);
    }

    void OneDestroy(){
	Vector3 posactual = new Vector3(transform.position.x, 0.5f, transform.position.z);
	Debug.Log("Se destruye");
    }
}