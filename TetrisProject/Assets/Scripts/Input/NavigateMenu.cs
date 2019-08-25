using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class NavigateMenu : MonoBehaviour
{
    private Text[] menu = new Text[3];
    private string[] songs;
    private int selectedItem = 0;
    private int selectedSong = 0;

    void Start()
    {
        menu[0] = GameObject.Find("Music").GetComponent<Text>();
        menu[1] = GameObject.Find("Level").GetComponent<Text>();
        menu[2] = GameObject.Find("Start").GetComponent<Text>();

        songs = new string[AudioManager.Instance.musicTracks.Length];
        for (var index = 0; index < AudioManager.Instance.musicTracks.Length; index++)
            songs[index] = AudioManager.Instance.musicTracks[index].name;

        AudioManager.PlayMusic(songs[selectedSong]);
        Global.song = songs[selectedSong];
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
                menu[index].text = "Level: " + Global.level.ToString();
            
            else if (menu[index].text.Contains("Music"))
                menu[index].text = "Music: " + songs[selectedSong];
        }

        if (Input.GetButtonDown("Up"))
            selectedItem = Mathf.Max(0, selectedItem - 1);
        else if (Input.GetButtonDown("Down"))
            selectedItem = Mathf.Min(menu.Length - 1, selectedItem + 1);
        else if (menu[selectedItem].text.Contains("Music") && Input.GetButtonDown("Left"))
            selectedSong = Mathf.Max(0, selectedSong - 1);
        else if (menu[selectedItem].text.Contains("Level") && Input.GetButtonDown("Right"))
            Global.level = Mathf.Min(19, Global.level + 1);
        else if (menu[selectedItem].text.Contains("Level") && Input.GetButtonDown("Left"))
            Global.level = Mathf.Max(0, Global.level - 1);
        else if (menu[selectedItem].text.Contains("Music") && Input.GetButtonDown("Right"))
            selectedSong = Mathf.Min(menu.Length - 1, selectedSong + 1);
        else if (menu[selectedItem].text.Contains("Start") && (Input.GetButtonDown("A") || Input.GetButtonDown("Start")))
            SceneManager.LoadScene("MainBoard");
        else
            return;

        Global.song = songs[selectedSong];

        AudioManager.PlaySound("Rotate");

        foreach (var track in AudioManager.Instance.musicTracks)
            track.source.Stop();

        if (menu[selectedItem].text.Contains("Music"))
            AudioManager.PlayMusic(songs[selectedSong]);

        if (Input.GetKeyDown(KeyCode.Escape))
            Application.Quit();
    }
}