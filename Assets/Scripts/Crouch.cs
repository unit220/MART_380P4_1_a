using UnityEngine;

public class Crouch : MonoBehaviour
{
    CharacterController controller;
    public UnityStandardAssets.Characters.FirstPerson.FirstPersonController controller2;
    bool isCrouching = false;
    public Transform headCheck;
    public LayerMask defaultMask;
    public float headDistance = 0.4f; // radius of sphere
    bool isUnder;
    float origincalHeight;
    [SerializeField] float crouchedHeight = 0.5f;
    public KeyCode crouchKey = KeyCode.LeftControl;
    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
        origincalHeight = controller.height;
    }

    // Update is called once per frame
    void Update()
    {
        // Are we under something
        if(Physics.CheckSphere(headCheck.position, headDistance, defaultMask)) {
            isUnder = true;
        } else {
            isUnder = false;
        }

        if(Input.GetKeyDown(crouchKey)) {
            if (isUnder && isCrouching) {
                return;
            } else {
            isCrouching = !isCrouching;
            checkCrouch();
            }
        }
    }

    void checkCrouch() {
        if(isCrouching == true) {
            controller.height = crouchedHeight;
            controller2.m_RunSpeed = 5;
        } else {
            controller.height = origincalHeight;
            controller2.m_RunSpeed = 10; // hard coded
        }
    }
}
