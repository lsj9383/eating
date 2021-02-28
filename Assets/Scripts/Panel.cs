using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Panel : MonoBehaviour
{
    public Text SelfText;
    public Text RankText;
    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        string id = player.GetComponent<Player>().GetID();
        SelfText.text = id + ":0";
        RankText.text = "";
    }

    public void UpdateScore(string id, int score) {
        SelfText.text = id + ":" + score.ToString();
    }
}
