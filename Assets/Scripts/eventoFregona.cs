using UnityEngine;

public class eventoFregona : MonoBehaviour
{
    [SerializeField] GameObject mancha;
    [SerializeField] fregona freg;

    float timer;
    int cont;
    
    void OnEnable()
    {
        cont=3;
    }

    // Update is called once per frame
    void Update()
    {
        
        timer += Time.deltaTime;
        if (cont > 0)
        {
            if (timer > 1f)
            {
                CrearMancha();
                timer = 0f;
                cont--;
            }
        }

        if(freg.limpio)
        {
            Debug.Log("Evento completado");
            this.enabled = false;
        }
    }
           

    void CrearMancha()
    {
        Instantiate(mancha, new Vector3(Random.Range(-4f, 4f), Random.Range(-1, 1f),  0f), Quaternion.identity);
    }
}