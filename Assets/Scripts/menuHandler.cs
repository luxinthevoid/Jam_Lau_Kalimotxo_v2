using UnityEngine;
using UnityEngine.SceneManagement;

public class menuHandler : MonoBehaviour
{
    public void clickJugar(int escena)
    {
        SceneManager.LoadScene(escena);
        Debug.Log("Cargar escena de juego");
    }

    public void clickOpciones()
    {
        Debug.Log("Mostrar opciones");
    }

    public void clickSalir()
        {
            Application.Quit();
            Debug.Log("Salir del juego");
    }

    public void clickVolver()
    {
        Debug.Log("Mostrar opciones");
    }
}
