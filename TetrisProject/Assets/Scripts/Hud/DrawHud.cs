using UnityEngine;
using UnityEngine.UI;

public class DrawHud : MonoBehaviour
{
    private Text score;
    private Text level;
    private Text lines;
    private Text burn;
    private Text drought;
    private Text message;

    void Start()
    {
        score = GameObject.Find("Score").GetComponent<Text>();
        level = GameObject.Find("Level").GetComponent<Text>();
        lines = GameObject.Find("Lines").GetComponent<Text>();
        burn = GameObject.Find("Burn").GetComponent<Text>();
        drought = GameObject.Find("Drought").GetComponent<Text>();
        message = GameObject.Find("Message").GetComponent<Text>();
    }

    void Update()
    {
        score.text = Global.score.ToString();
        level.text = Global.level.ToString();
        lines.text = Global.lines.ToString();
        burn.text = Global.burn.ToString();
        drought.text = Global.drought.ToString();
        message.text = Global.message;
    }
}
