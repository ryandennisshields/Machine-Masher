using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    private PlayerInput playerInput; // Stores the Player Input script
    public PlayerInput.OnFootActions onFoot; // Stores the On Foot actions from the Player Input script
    private PlayerMotor motor; // Stores the motor variable from the Player Motor script
    private PlayerLook look; // Stores the look variable from the Player Motor script
    private PlayerWeapon weapon; // Stores the weapon variable from the Player Weapon script

    // Awake is called when the script is loaded
    void Awake()
    {
        playerInput = new PlayerInput(); // Create a new instance of the Player Input script to be used for the code
        onFoot = playerInput.OnFoot; // Set on foot to the Player Input's On Foot actions
        motor = GetComponent<PlayerMotor>(); // Set motor to the Player Motor script
        look = GetComponent<PlayerLook>(); //  Set look to the Player Look script
        weapon = GetComponent<PlayerWeapon>(); // Set weapon to the Player Weapon script
        
    }

    // FixedUpdate is called once per physics engine frame
    void FixedUpdate()
    {
        motor.ProcessMove(onFoot.Movement.ReadValue<Vector2>()); // Moves the player by processing a move in a direction dependant on the key pressed
        onFoot.Jump.performed += ctx => motor.Jump(); // Makes the player jump if the correct button is pressed/performed ("ctx" determines if the correct input was pressed/performed to jump)
        onFoot.Boost.performed += ctx => motor.Boost();  // Makes the player boost if the correct button is pressed/performed ("ctx" determines if the correct input was pressed/performed to boost)
        onFoot.UseWeapon.performed += ctx => weapon.Shoot();  // Makes the player fire if the correct button is pressed/performed ("ctx" determines if the correct input was pressed/performed to fire)
        if (onFoot.Jetpack.ReadValue<float>() > 0)
        { // If the jetpack button is pressed down/active,
            motor.Jetpack(); // Makes the player use the jetpack
        }
    }

    // Update is called once per frame
    void Update()
    {
        look.ProcessLook(onFoot.Look.ReadValue<Vector2>()); // Makes the player look around by processing looking in a direction dependant on the mouse's position
    }

    // OnEnable is called when the object is active
    void OnEnable()
    {
        onFoot.Enable(); // Enable the On Foot actions
    }

    // OnDisable is called when the object is inactive
    void OnDisable()
    {
        onFoot.Disable(); // Disable the On Foot actions
    }
}
