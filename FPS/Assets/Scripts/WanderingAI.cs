using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WanderingAI : MonoBehaviour {
    [SerializeField] private GameObject fireballPrefab = null; // assignment in editor
    private GameObject _fireball;
    public const float baseSpeed = 3.0f;
    public float speed = 0;
    public float obstacleRange = 5.0f;
    private bool _alive;

	// Use this for initialization
	void Start () {
        _alive = true;
        speed = baseSpeed * PlayerPrefs.GetFloat("speed", 1);
    }

    // Update is called once per frame
    void Update () {
        if (!_alive) {
            return; 
        }

        transform.Translate(0, 0, speed * Time.deltaTime);

        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;
        if (Physics.SphereCast(ray, 0.75f, out hit)) {
            GameObject hitObject = hit.transform.gameObject;
            if (hitObject.GetComponent<PlayerCharacter>()) { // a player
                if (_fireball == null) {
                    _fireball = Instantiate(fireballPrefab) as GameObject;
                    _fireball.transform.position = transform.TransformPoint(Vector3.forward * 1.5f);
                    _fireball.transform.rotation = transform.rotation;
                }
            } else { // other obstacle
                if (hit.distance < obstacleRange) {
                    float angle = Random.Range(-110, 110);
                    transform.Rotate(0, angle, 0);
                }
            }
        }
	}

    public void setAlive(bool alive) {
        _alive = alive;
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
