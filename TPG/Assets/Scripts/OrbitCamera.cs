using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbitCamera : MonoBehaviour {
    [SerializeField]
    private Transform target = null;

    public float rotateSpeed = 1.5f;

    private float _rotateY;
    private Vector3 _offset;

	// Use this for initialization
	void Start () {
        _rotateY = transform.eulerAngles.y;
        _offset = target.position - transform.position;
	}

    private void LateUpdate() {
        float horInput = Input.GetAxis("Horizontal");
        if (horInput != 0) {
            _rotateY += horInput * rotateSpeed;
        } else {
            _rotateY += Input.GetAxis("Mouse X") * rotateSpeed * 3;
        }

        Quaternion rotation = Quaternion.Euler(0, _rotateY, 0);
        transform.position = target.position - (rotation * _offset);
        transform.LookAt(target);
    }

    // Update is called once per frame
    void Update () {
	}
}
