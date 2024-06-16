using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PieceScript : MonoBehaviour
{
    public GameObject MainGame;
    public int x;
    public int y;
    public bool ValidMove;
    private void OnMouseDown()
    {
        if (ValidMove)
        {
            if (MainGame.GetComponent<GameMain>().IsWhite)
            {
                MainGame.GetComponent<GameMain>().CheckWhiteMove(x, y);
            }
            else
            {
                MainGame.GetComponent<GameMain>().CheckBlackMove(x, y);
            }
            MainGame.GetComponent<GameMain>().ChangeStatus();
            MainGame.GetComponent<GameMain>().CheckValid();
        }
    }
}
