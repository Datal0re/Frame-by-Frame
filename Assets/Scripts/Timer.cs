/*  (c) Datal0re 2019
 *  Made for the GMTK 2019 Game Jam
 *  Theme: "Only One"
 */

using UnityEngine;
using TMPro;
using System.Collections;

public class Timer : MonoBehaviour
{

    public TMP_Text FrameNumberText;
    public TMP_Text TitleText;
    public TMP_Text GameOverText;
    public TMP_Text FinalScoreText;
    public Spawner Spawner;

    public int FrameNumber;

    void Update()
    {
        Count();
    }

    private void Count()
    {
        FrameNumber++;

        // Subtracting 4 makes sure that after the title coroutine
        // is done, the counter starts at 0.
        FrameNumberText.text = "Frame: " + (FrameNumber - 4).ToString();

        if (FrameNumber % 5 == 0)
        {
            Spawner.Spawn();
        }
    }

    public void GameStart()
    {
        _ = StartCoroutine("GameStartCoRoutine");
    }

    public void GameEnd()
    {
        _ = StartCoroutine("GameEndCoRoutine");
    }

    public IEnumerator GameStartCoRoutine()
    {
        GameOverText.gameObject.SetActive(false);
        FinalScoreText.gameObject.SetActive(false);
        FrameNumberText.gameObject.SetActive(false);

        TitleText.gameObject.SetActive(true);
        TitleText.text = "FRAME";
        yield return new WaitForEndOfFrame();
        TitleText.text = "FRAME by";
        yield return new WaitForEndOfFrame();
        TitleText.text = "FRAME by FRAME";
        yield return new WaitForEndOfFrame();
        TitleText.gameObject.SetActive(false);

        FrameNumberText.gameObject.SetActive(true);
    }

    public IEnumerator GameEndCoRoutine()
    {
        // Subtracting 4 makes sure that it counts the score from after the
        // title coroutine finished.
        int finalScore = FrameNumber - 4;
        FrameNumberText.gameObject.SetActive(false);

        GameOverText.gameObject.SetActive(true);
        yield return new WaitForEndOfFrame();

        FinalScoreText.gameObject.SetActive(true);
        FinalScoreText.text = "Survived " + finalScore.ToString() + " frames";
    }
}
