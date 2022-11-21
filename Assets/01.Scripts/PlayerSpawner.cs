using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 플레이어를 생성하는 스크립트
public class PlayerSpawner : MonoBehaviour
{
    public List<GameObject> players; // 플레이어 프리팹을 담은 List
    public string playerName; // 플레이어 종류
    
    private void OnEnable()
    {
        SetPlayer(); // 플레이어 셋팅
        GenPalyer(); // 플레이어 생성
    }

    void SetPlayer()
    {
        playerName = "Spin"; // 임시
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
