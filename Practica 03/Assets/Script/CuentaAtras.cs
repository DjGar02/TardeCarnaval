using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CuentaAtras : MonoBehaviour
{
    public Button btn;
    public Image img;
    public Sprite[] numeros;

    private int mostrar;
    private bool contar;

    // Start is called before the first frame update
    void Start()
    {
        btn.onClick.AddListener(Pulsado);
        mostrar = 3;
        contar = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate() {
        if(contar){
            switch (mostrar){
                case 0: SceneManager.LoadScene("segundoNivel", LoadSceneMode.Single); break;
                case 1: img.sprite=numeros[0];break;
                case 2: img.sprite=numeros[1];break;
                case 3: img.sprite=numeros[2];break;
            }
            StartCoroutine(Esperar());
            contar = false;
            mostrar--;
        }
    }

    IEnumerator Esperar(){
        yield return new WaitForSeconds(1);
        contar = true;
    }

    void Pulsado(){
        img.gameObject.SetActive(true);
        btn.gameObject.SetActive(false);
        contar = true;
    }
}
