using UnityEngine;

public class Interactuable : MonoBehaviour
{
    public bool activated = false;

    public void Accion()
    {
        activated = !activated; 
        Debug.Log("Objeto " + gameObject.name + " ahora está: " + activated);
    }
}