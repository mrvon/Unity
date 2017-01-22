using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
[AddComponentMenu("Control Script/FPS Input")]
public class FPSInput : MonoBehaviour {
    public const float baseSpeed = 6.0f;
    public float speed = 0;
    public float gravity = -9.8f;
    private CharacterController _charController;

    // Use this for initialization
    void Start () {
        _charController = GetComponent<CharacterController>();
        speed = baseSpeed * PlayerPrefs.GetFloat("speed", 1);
    }
	
	// Update is called once per frame
	void Update () {
        float deltaX = Input.GetAxis("Horizontal") * speed;
        float deltaZ = Input.GetAxis("Vertical") * speed;
        Vector3 movement = new Vector3(deltaX, 0, deltaZ);
        movement = Vector3.ClampMagnitude(movement, speed);

        movement *= Time.deltaTime;
        movement = transform.TransformDirection(movement);
        movement.y = gravity;
        _charController.Move(movement);
	}

    private void Awake() {
        Messenger<float>.AddListener(GameEvent.SPEED_CHANGED, OnSpeedChanged);
    }

    private void OnDestroy() {
        Messenger<float>.RemoveListener(GameEvent.SPEED_CHANGED, OnSpeedChanged);
    }

    private void OnSpeedChanged(float value) {
        speed = baseSpeed * value;
    }
}
