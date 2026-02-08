using UnityEngine;
using UnityEngine.UI;

public class eventoFinalMoneda : MonoBehaviour
{
    [SerializeField] Button cara;
    [SerializeField] Button cruz;
    [SerializeField] GameObject monedaGiratoria;
    [SerializeField] int probGanar = 5;
    [SerializeField] bool ganar = false;
    [SerializeField] bool perder = false;
    [SerializeField] bool animacion = false;
    [SerializeField] int resultado=-1;
    [SerializeField] string txt="";

    void OnEnable()
    {
        cara.gameObject.SetActive(true);
        cruz.gameObject.SetActive(true);
        monedaGiratoria.SetActive(false);
        ganar = false;
        perder = false;
        string txt = "";
    }


    void Update()
    {
        if (animacion) //cuando se acabe la animación se cambia a true para ejecutar esto
        {
            if (resultado == 0)
            {
                Debug.Log("Ha salido" + txt);
                ganar = true;
                this.gameObject.SetActive(false); //Quitar esto!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
            }
            else
            {
                Debug.Log("No ha salido" + txt);
                perder = true; //se puede hacer que cuando la animación de girar la moneda termine
                               //cambie los bool ganar o perder, para que los devuelva después de la animación.
                if(probGanar>1)
                    probGanar--;
                else
                    probGanar = 1;

                //para probar que se repita cuando pierdes
                cara.gameObject.SetActive(true);
                cruz.gameObject.SetActive(true);
                monedaGiratoria.SetActive(false);
                ganar = false;
                perder = false;
                animacion = false;
            }
        }
    }

    public void elección(string eleccion)
    {
        resultado = Random.Range(0, probGanar);
        Debug.Log(resultado);
        monedaGiratoria.SetActive(true);
        cara.gameObject.SetActive(false);
        cruz.gameObject.SetActive(false);
        txt = eleccion;
        animacion = true;   //temporal para probar que va
    }
}
