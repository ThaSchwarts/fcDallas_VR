using UnityEngine;
using System.Collections;

public class PlayerArray : MonoBehaviour
{
    public GameObject[] players;
    public Renderer[] playersRend;
    public MeshCollider[] playersCol;

	// Use this for initialization
	void Start ()
    {
        playersRend = new Renderer[players.Length];
        playersCol = new MeshCollider[players.Length];

        for (int i = 0; i < players.Length; i++)
        {
            playersRend[i] = players[i].GetComponentInChildren<Renderer>();
            playersCol[i] = players[i].GetComponentInChildren<MeshCollider>();
        }
	}

}
