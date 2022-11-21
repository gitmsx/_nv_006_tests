using UnityEngine;



public class InitFieldChess : MonoBehaviour
{


    public GameObject BulletPF;
    public GameObject BulletPF2;
    private GameObject BoxClone;

    void Start()
    {
        ChessBoard();
    }



    void ChessBoard()
    {

        float scale_pf = _global.Global_Scale;
        GameObject[] ChessTmp = new GameObject[2];

        ChessTmp[0] = BulletPF;
        ChessTmp[1] = BulletPF2;

        for (int i = 0; i < 20; i++)
            for (int j = 0; j < 20; j++)
            {
                Vector3 NewPos = new Vector3(scale_pf * i, 0, scale_pf * j);
                BoxClone = Instantiate(ChessTmp[(i + j) % 2], NewPos, transform.rotation);
                BoxClone.transform.localScale = new Vector3(2, 0.1f, 2);
            }

    }

}
