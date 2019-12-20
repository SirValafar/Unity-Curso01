using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    enum PlayerAction { Attack, Defend, Fire, Jump};

    PlayerAction action = PlayerAction.Attack;

    //Variables
    public float moveSpeed = 800;
    public float rotateSpeed = 10000;
    public float VelocidadSalto = 5f;

    private float currentMoveSpeed, currentRotateSpeed; 
    private float holdJump = 0.0f;
    private float hInput, vInput;

    public float DistanciaDelSuelo = 0.1f;

    public LayerMask suelo;

    private CapsuleCollider _col;
    private Rigidbody _rb;


    /// <summary>
    /// Variables de la bala
    /// </summary>
    public GameObject Bala;
    public Transform PuntoDeDisparo;
    public float VelocidadDeDisparo= 100f;

    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        currentMoveSpeed = moveSpeed;
        currentRotateSpeed = rotateSpeed;
        _col = GetComponent<CapsuleCollider>();

        int actionValue = (int)action;
    }

    // Update is called once per frame
    void Update()
    {
        //relantizar con la accion de un boton
        if (Input.GetAxis("Fire1")>0.1)
        {
            currentMoveSpeed = moveSpeed / 2.0f;
            currentRotateSpeed = rotateSpeed / 2.0f; ;
        }
        else
        {
            currentMoveSpeed = moveSpeed;
            currentRotateSpeed = rotateSpeed;
        }
        
        //Aca se esta realizando el fenomeno fisico movimiento = Velocidad por Tiempo
        hInput = Input.GetAxis("Horizontal") * currentRotateSpeed;
        vInput = Input.GetAxis("Vertical") * moveSpeed;
        //Salto = Input.GetAxis("Jump") * Salto * Time.deltaTime;

        if(Input.GetMouseButtonDown(0))
        {
            GameObject newBala = Instantiate(Bala,
                                            PuntoDeDisparo.position,
                                            PuntoDeDisparo.rotation)
                                            as
                                            GameObject;

            Rigidbody BalaRB = newBala.GetComponent<Rigidbody>();

            BalaRB.velocity = PuntoDeDisparo.forward * VelocidadDeDisparo;

        }

        if(IsOnTheGround() && Input.GetKeyDown(KeyCode.Space))
        {
            _rb.AddForce(Vector3.up * VelocidadSalto, ForceMode.Impulse);
        }


    }

    private void FixedUpdate()
    {
        Vector3 rotation = Vector3.up * hInput;
        Quaternion angleRot = Quaternion.Euler(rotation * Time.fixedDeltaTime);

        _rb.MovePosition(this.transform.position+
                         this.transform.forward * vInput * Time.fixedDeltaTime);

        _rb.MoveRotation(_rb.rotation * angleRot);
    }
    
    /// <summary>
    /// comprueba si el personaje esta tocando el suelo o no
    /// </summary>
    /// <returns>si es un si podra volver a saltar, si es un no, no puede saltar</returns>

    bool IsOnTheGround()
    {
        Vector3 CapsuleButton = new Vector3(_col.bounds.center.x, 
                                            _col.bounds.min.y, 
                                            _col.bounds.center.z);

        bool onTheGround = Physics.CheckCapsule(_col.bounds.center,
                                                CapsuleButton,
                                                DistanciaDelSuelo,
                                                suelo,
                                                QueryTriggerInteraction.Ignore);
        return onTheGround;
    }


}
