using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawner : MonoBehaviour
{
    public List<GameObject> players;
    public string playerName;
    
    private void OnEnable()
    {
        SetPlayer();
        GenPalyer();
    }

    void SetPlayer()
    {
        playerName = "Spin"; // юс╫ц
    }

    void GenPalyer()
    {
        foreach (var player in players)
        {
            if (player.name == $"Player_{playerName}")
            {
                Instantiate(player, this.transform.position, this.transform.rotation, this.transform);
                break;
            }
        }
    }
}
