using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    /// <summary>
    /// Valor del movimiento del jugador.
    /// </summary>
    [Header("Movement")]
    // Valor para la velocidad del movimiento.
    private float moveSpeed;
    // Valor para la velocidad al caminar.
    public float walkSpeed;
    // Valor para la velocidad de correr.
    public float strintSpeed;

    // Valor para la fricción de los movimientos del jugado en el suelo.
    public float groundDrag;

    // Valor para la fuerza de salto.
    public float jumpForce;
    // Valor para el reseteo del salto.
    public float jumpCooldown;
    // Valor del salto en el aire.
    public float airMultiplier;
    // Estado del salto.
    bool readyToJump;

    /// <summary>
    /// Asigna las teclas que ejecute el salto y el correr.
    /// </summary>
    [Header("Keybinds")]
    // Tecla space para saltar.
    public KeyCode jumpKey = KeyCode.Space;
    // Tecla LeftShift para correr.
    public KeyCode strintKey = KeyCode.LeftShift;

    /// <summary>
    /// Asigna un valor para el suelo.
    /// </summary>
    [Header("Ground Check")]
    // Valor para el peso del jugador.
    public float playerHeight;
    // Valor para el suelo.
    public LayerMask whatIsGround;
    // Estado del suelo.
    bool grounded;

    /// <summary>
    /// Orientación del jugador.
    /// </summary>
    // Valor para la orientaciónd el jugador.
    public Transform orientation;
    // Valor del movimiento del jugador en Horizontal.
    float horizontalInput;
    // Valor del movimiento del jugador en Vertical.
    float verticalInput;

    // Dirección de movimiento para el jugador.
    Vector3 moveDirection;
    // Valor para el Ribidbody del jugador.
    Rigidbody rb;

    /// <summary>
    /// Asignan digerentes estados para el jugador.
    /// </summary>
    public MovementState State;
    public enum MovementState {
        // Estado para caminar.
        walking,
        // Estado para correr.
        sptrinting,
        // Estado al estar en el aire. 
        air
    }
    //Asigna un valor para la invoar funciones de otro script.
    public Sounds sound;

    /// <summary>
    /// Activa los valores asigandos para movimiento del jugador y los sonidos.
    /// </summary>
    private void Start()
    {
        // Obtiene los componentes del Script Sounds.
        sound=GameObject.Find("AudioEffects").GetComponent<Sounds>();

        // Obtiene los componentes del Rigidbody.
        rb = GetComponent<Rigidbody>();
        // La rotación del Rigidbody está bloqueada.
        rb.freezeRotation = true;

        // Estado del salto, listo para saltar.
        readyToJump = true;
    }

    /// <summary>
    /// Actualiza las condiciones en los movimientos del jugador.
    /// </summary>
    private void Update()
    {
        // Revisa si se trata de un suelo.
        grounded = Physics.Raycast(transform.position, Vector3.down, playerHeight * 0.5f + 0.2f, whatIsGround);

        // Invoca la función MyInput.            
        MyInput();
        // Invoca la función SpeedControl.
        SpeedControl();
        // Invoca la función StateHandler.
        StateHandler();

        // Si es un suelo la fricción del rigidboy es igual a la fricción asignada. De lo contrario es cero.
        if (grounded)
            rb.drag = groundDrag;
        else
            rb.drag = 0;
    }

    /// <summary>
    /// Actualiza en tiempo real los vomivientos del jugador.
    /// </summary>
    private void FixedUpdate(){
        // Invoca la función MovePlayer.
        MovePlayer();
    }

    /// <summary>
    /// Asigna los valores de la posición del jugador.
    /// </summary>
    private void MyInput(){
        //Asigna los valores horizonales y verticales del jugador.
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");

        //Si se preciona ka tecla del salto, el estado del salto es true y esta en un suelo, puede saltar, de lo contrario, no puede.
        if(Input.GetKey(jumpKey) && readyToJump && grounded)
        {
            readyToJump = false;

            Jump();

            Invoke(nameof(ResetJump), jumpCooldown);
        }
    }

    /// <summary>
    /// Asigna el estado del jugador.
    /// </summary>
    private void StateHandler(){
        // Si esta en un suelo y preciona el teclado de correr, cambia su velocidad al valor asignado para correr.
        if(grounded && Input.GetKey(strintKey)){
            State = MovementState.sptrinting;
            moveSpeed = strintSpeed;
        }

        // Si esta en un suelo cambia su velocidad al valor asignado para caminar.
        else if (grounded){
            State = MovementState.walking;
            moveSpeed = walkSpeed;
        }

        // Si esta en el aire, cambia su velocidad al valor asignado cuando se cuentra en el aire.
        else{
            State = MovementState.air;
        }

    }
    /// <summary>
    /// Indica si el jugador se encuentra en una superficie.
    /// </summary>
    private void MovePlayer(){
        // Calcula la dirección del movimiento.
        moveDirection = orientation.forward * verticalInput + orientation.right * horizontalInput;
        
        // Asigna la fuerza de movimiento estando en el suelo.
        if(grounded)
            rb.AddForce(moveDirection.normalized * moveSpeed * 10f, ForceMode.Force);

        // Asigna la fuerza de movimiento estando en el aire.
        else if(!grounded)
            rb.AddForce(moveDirection.normalized * moveSpeed * 10f * airMultiplier, ForceMode.Force);
    }
    /// <summary>
    /// Asigna la velocidad de movimiento del jugador.
    /// </summary>
    private void SpeedControl(){
        // Asigna la velocidad de control.
        Vector3 flatVel = new Vector3(rb.velocity.x, 0f, rb.velocity.z);

        // Si la velocidad obtenida es mayor a la velocidad asignada, la velocidad de limitará al valor asignado.
        if(flatVel.magnitude > moveSpeed){
            Vector3 limitedVel = flatVel.normalized * moveSpeed;
            rb.velocity = new Vector3(limitedVel.x, rb.velocity.y, limitedVel.z);
        }
    }
    /// <summary>
    /// Asigna la fuerza y velocidad de saldo del jugador.
    /// </summary>
    private void Jump()
    {   
        // Reproducira un sonido de salto.
        sound.soundJump();
        // La velocidad de restablese al saltar.
        rb.velocity = new Vector3(rb.velocity.x, 0f, rb.velocity.z);

        // Asigna la fuersa del salto.
        rb.AddForce(transform.up * jumpForce, ForceMode.Impulse);
    }
    /// <summary>
    /// Tiempo que tarda para resetear el salto en su vesión original.
    /// </summary>
    private void ResetJump()
    {
        //Estado del salto en true.
        readyToJump = true;
    }

}
