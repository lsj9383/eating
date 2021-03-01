using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float intensity = 10.0f;
    public GameObject camera;
    public GameObject icon;
    public GameObject realground;

    int score = 0;
    string id;

    void Awake() {
        id = Random.Range(0, 99999999).ToString();
    }

    // Update is called once per frame
    void FixedUpdate() {
        float v = Input.GetAxis("Vertical");
        float h = Input.GetAxis("Horizontal");

        float actual_intensity = intensity;
        if (Input.GetKey(KeyCode.LeftShift)) {
            actual_intensity *= 5;
        }

        Rigidbody rg = this.GetComponent<Rigidbody>();
        rg.AddForce(new Vector3(h * actual_intensity, 0, v * actual_intensity));
    }

    void OnTriggerEnter(Collider o) {
        if (o.gameObject.CompareTag("Food")) {
            Destroy(o.gameObject);

            score += 1;

            // update score show
            GameObject panel = GameObject.FindGameObjectWithTag ("Panel");
            Panel panelsc = panel.GetComponent<Panel>();
            panelsc.UpdateScore(id, score);

            // add new one food
            GameObject root = GameObject.FindGameObjectWithTag ("Root");
            Root rootsc = root.GetComponent<Root>();
            rootsc.InitialFood();

            // bigger
            this.transform.localScale = new Vector3(this.transform.localScale.z + 0.1f,
                                                    this.transform.localScale.z + 0.1f,
                                                    this.transform.localScale.x + 0.1f);

            // adjust camera
            CameraFollow camerasc = camera.GetComponent<CameraFollow>();
            camerasc.distance += 0.1f;

            // adjust icon
            IconFollow iconsc = icon.GetComponent<IconFollow>();
            iconsc.distance += 0.1f;

            // adjust ground
            realground.transform.position = new Vector3(realground.transform.position.x,
                                                        realground.transform.position.y - 0.1f,
                                                        realground.transform.position.z);
        }
    }

    public int GetScore() {
        return score;
    }

    public string GetID() {
        return id;
    }
}
