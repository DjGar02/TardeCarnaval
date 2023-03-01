using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MovimientoJugador : MonoBehaviour
{
    public GameObject prefabSuelo;
    public GameObject prefabMoneda;
    public Camera cam;
    public int velocidad;
    public Text texto;

    private Vector3 offset;
    private float miX, miZ;
    private Rigidbody rb;
    private Vector3 direccionActual;
    private int monedas = 0;

    // Start is called before the first frame update
    void Start()
    {
        offset = cam.transform.position;
        miX = 0;
        miZ = 0;
        rb = GetComponent<Rigidbody>();
        direccionActual = Vector3.forward;
	    monedas = 0;
        SueloInicial();
    }

    // Update is called once per frame
    void Update()
    {
        cam.transform.position = this.transform.position + offset;

        if(rb.position.y < -10){
            SceneManager.LoadScene("GameOver", LoadSceneMode.Single);
        }

        if(Input.GetKeyUp(KeyCode.Space)){
            if(direccionActual == Vector3.forward){
                direccionActual = Vector3.right;
            }else{
                direccionActual = Vector3.forward;
            }
        }

        float tiempo = velocidad * Time.deltaTime;
        rb.transform.Translate(direccionActual * tiempo);
    }

    void SueloInicial(){
        for(int i=0; i<3; i++){
            miZ += 6.0f;
            GameObject cubo = Instantiate(prefabSuelo, new Vector3(miX, 0, miZ), Quaternion.identity) as GameObject;
        }
    }

    void OnCollisionExit(Collision other) {
        Debug.Log("deja de tocar");
        if(other.transform.tag == "suelo"){
            StartCoroutine(CrearSuelo(other));
        }
    }

    IEnumerator CrearSuelo(Collision col){
        Debug.Log("cae");
        yield return new WaitForSeconds(0.5f);
        col.rigidbody.isKinematic = false;
        col.rigidbody.useGravity = true;
        Destroy(col.gameObject, 5f);
        float ran = Random.Range(0f, 1f);
	    float ranmoneda = Random.Range(-3f, 3f);
        if(ran < 0.5f){
            miX += 6;
	        GameObject premio = Instantiate(prefabMoneda, new Vector3(miX, 1, miZ+ranmoneda), Quaternion.identity) as GameObject;
        }else{
            miZ += 6;
	        GameObject premio = Instantiate(prefabMoneda, new Vector3(miX+ranmoneda, 1, miZ), Quaternion.identity) as GameObject;
        }
        GameObject cubo = Instantiate(prefabSuelo, new Vector3(miX, 0, miZ), Quaternion.identity) as GameObject;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(SceneManager.GetActiveScene().name == "tercerNivel"){
            if(other.gameObject.CompareTag("Moneda"))
            {
                monedas++;
                texto.text = "MONEDAS: " + monedas;
            }
            if(monedas == 20)
            {
                Debug.Log("Has termiando el juego");
                SceneManager.LoadScene("pantallaInicio", LoadSceneMode.Single);
            }
        }
        else{
            if(other.gameObject.CompareTag("Moneda"))
            {
                monedas++;
                texto.text = "MONEDAS: " + monedas;
            }
            if(monedas == 10)
            {
                Debug.Log("Has termiando el juego");
                SceneManager.LoadScene("Carga", LoadSceneMode.Single);
            }
        }
    }
}
