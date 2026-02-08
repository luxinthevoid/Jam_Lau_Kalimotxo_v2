using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections.Generic;

public class eventoTelefono : MonoBehaviour
{
    [SerializeField] BoxCollider2D cajaTelefono;
    [SerializeField] Button bueno;
    [SerializeField] Button malo;
    [SerializeField] TextMeshProUGUI txt1;
    [SerializeField] TextMeshProUGUI txt2;
    [SerializeField] Canvas canvas;

    [SerializeField] bool responder;
    [SerializeField] bool colgar;
    [SerializeField] int iteracion;

    public bool completado = false;

    List<string> txt2Lista = new List<string>() { "malo1", "malo2", "malo3", "malo4" };

    void OnEnable()
    {
        iteracion = 0;
        responder = false;
        bueno.onClick.AddListener(Colgar);
        malo.onClick.AddListener(BucleTxt);
        if (canvas != null)
            canvas.gameObject.SetActive(false);
        completado = false;
    }

    void OnDisable()
    {
        bueno.onClick.RemoveListener(Colgar);
        malo.onClick.RemoveListener(BucleTxt);
    }

    // Update is called once per frame
    void Update()
    {
        if (colgar)
        {
            Debug.Log("Evento completado");
            completado = true;
        }
    }

    void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0) && !responder)
        {
            cajaTelefono.enabled = false;
            responder = true;
            canvas.gameObject.SetActive(true);
            txt1.text = "'Colgar'";
            txt2.text = "'Responder'";
        }
    }

    void Colgar()
    {
        colgar = true;
    }

    void BucleTxt()
    {
        txt1.text = "Luego te llamo mamá";
        txt2.text = txt2Lista[iteracion];
        if(iteracion >= txt2Lista.Count - 1)
            iteracion=0;
        else
            iteracion++;
    }
}
