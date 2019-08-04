/*  (c) Datal0re 2019
 *  Made for the GMTK 2019 Game Jam
 *  Theme: "Only One"
 */

using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Timer Timer;
    public Player Player;

    private void Awake()
    {
        Application.targetFrameRate = 1; // ONLY 1 FPS
        QualitySettings.vSyncCount = 0;

        //Screen.SetResolution(640, 360, false);
        Screen.SetResolution(1280, 1024, false);
    }

    private void Start()
    {
        Timer.GameStart();
    }

    public void GameOver()
    {
        Player.Die();
        Timer.GameEnd();
    }
}
