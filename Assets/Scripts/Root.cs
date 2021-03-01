using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Root : MonoBehaviour
{
    public GameObject player;
    public GameObject ground;
    public GameObject prefood;
    public GameObject endpanel;
    public int foodcount = 150;

    float _fadeDuration = 1f;
    float _displayImageDuration = 1f;
    float _endtimer = 0;


    public static Color RandomColor(float a = 1.0f) {
        float r = Random.Range(0, 255) / 255.0f;
        float g = Random.Range(0, 255) / 255.0f;
        float b = Random.Range(0, 255) / 255.0f;
        return new Color(r, g, b, a);
    }

    public void InitialFood() {
        float max_ground_x =   ground.GetComponent<Collider>().bounds.size.x / 2.0f;
        float min_ground_x = - ground.GetComponent<Collider>().bounds.size.x / 2.0f;
        float max_ground_z =   ground.GetComponent<Collider>().bounds.size.z / 2.0f;
        float min_ground_z = - ground.GetComponent<Collider>().bounds.size.z / 2.0f;

        Vector3 pos = new Vector3(Random.Range(min_ground_x, max_ground_x),
                                  0.5f,
                                  Random.Range(min_ground_z, max_ground_z));
        GameObject o = Instantiate(prefood, pos, Quaternion.identity);
        o.GetComponent<Renderer>().material.color = RandomColor();
    }

    // Start is called before the first frame update
    void Start()
    {
        // init player color
        player.GetComponent<Renderer>().material.color = RandomColor();

        // init food
        for (int i = 0; i < foodcount; ++i) {
            InitialFood();
        }
    }

    void Update() {
        if (player.transform.position.y < -1.0f) {
            CanvasGroup imageCanvasGroup = endpanel.GetComponent<CanvasGroup>();

            _endtimer += Time.deltaTime;
            imageCanvasGroup.alpha = _endtimer / _fadeDuration;
            if(_endtimer > _fadeDuration + _displayImageDuration)
            {
                Application.Quit ();
            }
        }
    }
}
