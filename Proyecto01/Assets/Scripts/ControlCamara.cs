using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlCamara : MonoBehaviour
{
    public GameObject jugador;
    public GameObject referencia;
    private Vector3 distancia;
    // Start is called before the first frame update
    void Start()
    {
        distancia = transform.position - jugador.transform.position;
    }
    // Update is called once per frame
    void LateUpdate()
    {
      distancia = Quaternion.AngleAxis(Input.GetAxis ("Mouse X") * 2, Vector3.up) * distancia;

      transform.position = jugador.transform.position + distancia;
      transform.LookAt (jugador.transform.position);

      Vector3 copiaRotacion = new Vector3 (0, transform.eulerAngles.y, 0);
      referencia.transform.eulerAngles = copiaRotacion;  
    }
}
