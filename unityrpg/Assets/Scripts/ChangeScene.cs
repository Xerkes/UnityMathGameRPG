using UnityEngine;
using System.Collections;

public class ChangeScene : MonoBehaviour
{

    public SceneFader fader;

    public void Select(string levelName)
    {
        fader.FadeTo(levelName);
    }
}