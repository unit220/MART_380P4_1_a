using UnityEngine;

public class Crouch : MonoBehaviour
{
    CharacterController controller;
    bool isCrouching = false;
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
        if(Input.GetKeyDown(crouchKey)) {
            isCrouching = !isCrouching;
            checkCrouch();
        }
    }

    void checkCrouch() {
        if(isCrouching == true) {
            controller.height = crouchedHeight;
        } else {
            controller.height = origincalHeight;
        }
    }
}
