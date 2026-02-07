using UnityEngine;

public class telefonillop : MonoBehaviour
{
    [SerializeField] bool finEvento = false;
    [SerializeField] botonAbrir abrir;

    // Update is called once per frame
    void Update()
    {
        if (abrir.colgar)
        {
            finEvento = true;
            Debug.Log("fin de evento interfono");
        }
    }
}
