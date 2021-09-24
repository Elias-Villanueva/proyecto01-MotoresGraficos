using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ControlJugador : MonoBehaviour
{
    public Rigidbody rb;
    public float speed;
    public float maxSpeed;
    public GameObject referencia;
    public Text textoCantidadRecolectados;
    public Text textoGanaste;
    private int cont;
    public LayerMask capaPiso;
    public SphereCollider col;
    public int CantSaltos = 1;
    public int PotenciaSalto = 1;
    public int SaltosHechos = 0;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        col = GetComponent<SphereCollider>();
        cont = 0;
        textoGanaste.text = "";
        setearTextos();
    }

    private void setearTextos()
    {
        textoCantidadRecolectados.text = "Cantidad recolectados: " + cont.ToString();
        if (cont >= 5)
        {
            textoGanaste.text = "Ganaste!";
        }
    }


    private void FixedUpdate() {

        float moverHorizontal = Input.GetAxis("Horizontal");
        float moverVertical = Input.GetAxis("Vertical");
        
        if (rb.velocity.magnitude > maxSpeed)
        {
            rb.velocity = rb.velocity.normalized * maxSpeed;
        }

        rb.AddForce (moverVertical * referencia.transform.forward * speed);
        rb.AddForce (moverHorizontal * referencia.transform.right * speed);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("coleccionable") == true)
        {
            cont = cont + 1;
            setearTextos();
            other.gameObject.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (SaltosHechos < CantSaltos && Input.GetKeyDown(KeyCode.Space))
        {
            rb.velocity = new Vector3(rb.velocity.x, 0, rb.velocity.z);

            rb.AddForce(0, PotenciaSalto, 0, ForceMode.Impulse);
            SaltosHechos++;

        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Suelo")
        {
            SaltosHechos = 0;
        }
    }

}
