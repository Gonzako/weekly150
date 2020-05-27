using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Doozy.Engine.UI;

public class MenuViewManager : MonoBehaviour
{


    bool onGameplay = true;
    [SerializeField] UIView pauseView, gameplayView;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            if (onGameplay)
            {
                onGameplay = false;
                pauseView.Show();
                gameplayView.Hide();
            }
            else
            {
                onGameplay = true;
                pauseView.Hide();
                gameplayView.Show();
            }
        }
    }
}
