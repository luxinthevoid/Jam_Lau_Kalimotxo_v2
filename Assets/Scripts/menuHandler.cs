using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class menuHandler : MonoBehaviour
{
    [SerializeField] Button btnJugar;
    [SerializeField] Button btnOpciones;
    [SerializeField] Button btnSalir;
    [SerializeField] Button btnVolver;
    //[SerializeField] TextMeshProUGUI instrucciones;

    void OnEnable()
    {
        btnJugar.gameObject.SetActive(true);
        btnOpciones.gameObject.SetActive(true);
        btnSalir.gameObject.SetActive(true);
        btnVolver.gameObject.SetActive(false);
        //instrucciones.gameObject.SetActive(false);
    }

    public void clickJugar()
    {
        SceneManager.LoadScene("Cocina");
        Debug.Log("Cargar escena de juego");
    }

    public void clickOpciones()
    {
        Debug.Log("Mostrar opciones");
        btnJugar.gameObject.SetActive(false);
        btnOpciones.gameObject.SetActive(false);
        btnSalir.gameObject.SetActive(false);
        btnVolver.gameObject.SetActive(true);
        //instrucciones.gameObject.SetActive(true);
    }

    public void clickSalir()
        {
            Application.Quit();
            Debug.Log("Salir del juego");
    }

    public void clickVolver()
    {
        Debug.Log("Mostrar opciones");
        btnJugar.gameObject.SetActive(true);
        btnOpciones.gameObject.SetActive(true);
        btnSalir.gameObject.SetActive(true);
        btnVolver.gameObject.SetActive(false);
        //instrucciones.gameObject.SetActive(false);
    }
}
