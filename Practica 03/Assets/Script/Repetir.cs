using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Repetir : MonoBehaviour
{
    public Button btn;
    // Start is called before the first frame update
    void Start()
    {
        btn.onClick.AddListener(Pulsado);
    }
    
    void Pulsado(){
	SceneManager.LoadScene("pantallaInicio", LoadSceneMode.Single);
    }
}
