using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DoyunLee
{
    public class GainableSpawner : MonoBehaviour
    {
        public GameObject gainablePanel;
        public GameObject[] gainablePrefabs;
        Vector2[] gainablePositions;

        List<GameObject> gainables;
        int count;

        void Awake()
        {
            count = gainablePanel.transform.childCount;
            gainablePositions = new Vector2[count];
            gainables = new List<GameObject>();
        }

        void OnEnable()
        {
            MoveGainablesToPoolPosition(); // gainables를 안 보이는 곳으로 옮긴다
            PlaceGainablePositions(); // gainablePositions를 새로 채운다
            PlaceGainables(); // gainables를 새로 배치한다
        }

        void Start()
        {
            PlaceGainablePositions(); // gainablePositions를 새로 채운다
            FillGainables(); // gainables를 추가한다
            PlaceGainables(); // gainables를 새로 배치한다
        }

        void PlaceGainablePositions()
        {
            for (int i = 0; i < count; i++)
            {
                gainablePositions[i] = gainablePanel.transform.GetChild(i).position;
            }
        }

        void FillGainables()
        {
            Vector2 poolPosition = new Vector2(0, -50);
            for (int i = 0; i < gainablePrefabs.Length; i++)
            {
                int number = (i == 0) ? count * 2 : 1;
                for (int j = 0; j < number; j++)
                {
                    GameObject gainable = Instantiate(gainablePrefabs[i], poolPosition, Quaternion.identity, gainablePanel.transform);
                    gainables.Add(gainable);
                }
            }
        }

        void PlaceGainables()
        {
            if (gainables.Count > 0)
            {
                List<int> numbers = new List<int>();
                for (int i = 0; i < gainablePositions.Length; i++)
                {
                    int randomNumber;
                    while (true)
                    {
                        randomNumber = Random.Range(0, gainables.Count);
                        if (numbers.Contains(randomNumber) == true)
                        {
                            continue;
                        }
                        else
                        {
                            numbers.Add(randomNumber);
                            break;
                        }
                    }
                    gainables[randomNumber].transform.position = gainablePositions[i];
                }
            }
        }

        void MoveGainablesToPoolPosition()
        {
            Vector2 poolPosition = new Vector2(0, -50);
            if (gainables.Count > 0)
            {
                foreach (var gObj in gainables)
                {
                    gObj.transform.position = poolPosition;
                    if (gObj.activeSelf == false)
                    {
                        gObj.SetActive(true);
                    }
                }
            }
        }
    }
}
