using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class NavigateMenu : MonoBehaviour
{
    private Text[] menu = new Text[3];
    private int selectedItem = 0;
    private int selectedLevel = 0;
    private string selectedSong = "Coming Soon";

    void Start()
    {
        menu[0] = GameObject.Find("Music").GetComponent<Text>();
        menu[1] = GameObject.Find("Level").GetComponent<Text>();
        menu[2] = GameObject.Find("Start").GetComponent<Text>();
    }

    void Update()
    {
        for (int index = 0; index < menu.Length; index++)
        {
            if (selectedItem == index)
                menu[index].color = Color.white;
            else
                menu[index].color = Color.grey;

            if (menu[index].text.Contains("Level"))
                menu[index].text = "Level: " + selectedLevel.ToString();
            else if (menu[index].text.Contains("Music"))
                menu[index].text = "Music: " + selectedSong;
        }

        if (menu[selectedItem].text.Contains("Level") && Input.GetButtonDown("Right"))
            selectedLevel = Mathf.Min(19, selectedLevel + 1);
        else if (menu[selectedItem].text.Contains("Level") && Input.GetButtonDown("Left"))
            selectedLevel = Mathf.Max(0, selectedLevel - 1);
        else if (menu[selectedItem].text.Contains("Music") && Input.GetButtonDown("Right"))
            ;
        else if (menu[selectedItem].text.Contains("Music") && Input.GetButtonDown("Left"))
            ;
        else if (Input.GetButtonDown("Up"))
            selectedItem = Mathf.Max(0, selectedItem - 1);
        else if (Input.GetButtonDown("Down"))
            selectedItem = Mathf.Min(menu.Length - 1, selectedItem + 1);
        else if (menu[selectedItem].text.Contains("Start") && (Input.GetButtonDown("A") || Input.GetButtonDown("Start")))
            SceneManager.LoadScene("MainBoard");
    }
}
