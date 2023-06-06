using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    public Rigidbody personaje;
    public float velocidadMovimiento = 5f;
    public Vector2 sensibilidad;
    public Transform camara;
    void Start()
    {
        personaje = GetComponent<Rigidbody>();
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        moverPersonaje();
        moverCamara();
    }

    private void moverCamara() {
        float horizontal = Input.GetAxis("Mouse X");
        float vertical = Input.GetAxis("Mouse Y");

        if (horizontal != 0) {
            transform.Rotate(0, horizontal * sensibilidad.x, 0);
        }
        
        if (vertical != 0) {
            Vector3 rotation = camara.localEulerAngles;
            rotation.x = (rotation.x - vertical * sensibilidad.y + 360) % 360;
            if (rotation.x > 80 && rotation.x < 180) {
                rotation.x = 80;
            } else if (rotation.x < 280 && rotation.x > 180) {
                rotation.x = 200;
            }
            camara.Rotate(-vertical * sensibilidad.y, 0, 0);
        }
    }

    private void moverPersonaje() {
        // Variables que contendran los valores en posicion de cada eje
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        Vector3 velicidad = Vector3.zero;
        if (horizontal != 0 || vertical != 0)
        {
            Vector3 direccion = (transform.forward * vertical + transform.right * horizontal).normalized;
            velicidad = direccion * velocidadMovimiento;
        }
        velicidad.y = personaje.velocity.y;
        personaje.velocity = velicidad;
    }
}
