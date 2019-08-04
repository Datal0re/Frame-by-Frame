/*  (c) Datal0re 2019
 *  Made for the GMTK 2019 Game Jam
 *  Theme: "Only One"
 */

using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject[] obstacles;

    public void Spawn()
    {
        int rand = Random.Range(0, obstacles.Length);
        _ = Instantiate(obstacles[rand], obstacles[rand].transform.position, Quaternion.identity);
    }
}
