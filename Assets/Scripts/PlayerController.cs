using UnityEngine;


[RequireComponent(typeof(PlayerMotor))]
[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour
{



    public GameObject gameMaster;
    private AmmoInventory ammoInventory;

    [SerializeField]
    private float speed = 10f;

    [SerializeField]
    private float lookSensitivity = 3f;

    [SerializeField]
    private float jumpForce = 7;
    private Vector3 jump;

    public bool isGrounded;

    public LayerMask groundLayers;

    public CapsuleCollider col;

    Rigidbody rb;


    private PlayerMotor motor;

    private void Start()
    {
        ammoInventory = gameMaster.GetComponent<AmmoInventory>();
        rb = GetComponent<Rigidbody>();
        col = GetComponent<CapsuleCollider>();

        motor = GetComponent<PlayerMotor>();

        jump = new Vector3(0.0f, 2.0f, 0.0f);

        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;


    }


    private void OnCollisionStay(Collision collision)
    {


        isGrounded = true;

    }


    private void OnCollisionExit(Collision collision)
    {

        isGrounded = false;
    }

    private void FixedUpdate()
    {
        if(Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {

            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);



        }







        //Calculate movement velocity as a 3D vector
        float xMov = Input.GetAxisRaw("Horizontal");
        float zMov = Input.GetAxisRaw("Vertical");

        Vector3 moveHorizontal = transform.right * xMov;
        Vector3 moveVertical = transform.forward * zMov;


        //Final Movement Vector
        Vector3 _velocity = (moveHorizontal + moveVertical).normalized
 * speed;

        //Apply Movement

        motor.Move(_velocity);


        //calclulate roation as a 3d vector - Turning Around

        float yRot = Input.GetAxisRaw("Mouse X");

        Vector3 _rotation = new Vector3(0f, yRot, 0f) * lookSensitivity;


        // Apply Rotation

        motor.Rotate(_rotation);




        //calclulate Camera rotation as a 3d vector - Turning Around

        float xRot = Input.GetAxisRaw("Mouse Y");

        Vector3 _cameraRotation = new Vector3(xRot, 0f, 0f) * lookSensitivity;


        // Apply Rotation

        motor.RotateCamera(-_cameraRotation);

    }



        }







