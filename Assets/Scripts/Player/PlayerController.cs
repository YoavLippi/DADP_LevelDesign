using UnityEngine;
 
public class PlayerController : MonoBehaviour
{
    CharacterController characterController;
    [SerializeField] private float playerSpeed =1;
    [SerializeField] private float gravityValue = 9.8f;
    [SerializeField] private float jumpHeight;
    [SerializeField] private CapsuleCollider Collision;
    [SerializeField] private Camera lookCamera;
    private float velocity = 0;
    private bool groundedPlayer;
    private Vector3 playerVelocity;

    #region crouch
        private Vector3 crouchScale = new Vector3(1, 0.5f, 1);
        private Vector3 playerScale = new Vector3(1, 1f, 1);
    #endregion

    private void Start()
    {
        characterController = GetComponent<CharacterController>();
    }
 
    void Update()
    {
        groundedPlayer = characterController.isGrounded;
        if (groundedPlayer && playerVelocity.y < 0)
        {
            playerVelocity.y = 0f;
        }

        float horiz = Input.GetAxis("Horizontal");
        float vert = Input.GetAxis("Vertical");
        Vector3 move = transform.right*horiz + transform.forward*vert;
        characterController.Move(move * (Time.deltaTime * playerSpeed));

        // Changes the height position of the player..
        if (Input.GetAxis("Jump") == 1 && groundedPlayer)
        {
            Debug.Log("Pressed");
            playerVelocity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravityValue);
        }

        playerVelocity.y += gravityValue * Time.deltaTime;
        characterController.Move(playerVelocity * Time.deltaTime);

        #region Handles Crouch
        
            if (Input.GetKeyDown(KeyCode.LeftShift))
            {
                playerSpeed = 2.1f;
                /*transform.localScale = crouchScale;
                transform.position = new Vector3(transform.position.x, transform.position.y-crouchScale.y, transform.position.z);*/
                characterController.height = 1.5f;
                characterController.center = new Vector3(0,-0.25f,0);
                Collision.height = characterController.height;
                Collision.center = characterController.center;
                lookCamera.transform.position = transform.position + new Vector3(0, 0f, 0);
            }

            if (Input.GetKeyUp(KeyCode.LeftShift))
            {
                playerSpeed = 5.5f;
                /*transform.localScale = playerScale;
                transform.position = new Vector3(transform.position.x, transform.position.y+crouchScale.y, transform.position.z);
                */
                characterController.height = 2f;
                characterController.center = Vector3.zero;
                Collision.height = characterController.height;
                Collision.center = characterController.center;
                lookCamera.transform.position = transform.position + new Vector3(0, 0.59f, 0);
            }
        
        #endregion


    }

    private Vector3 MultiplyComponents(Vector3 a, Vector3 b)
    {
        return new Vector3(a.x * b.x, a.y * b.y, a.z * b.z);
    }
}