using UnityEngine;

public class RoomBehaviour : MonoBehaviour
{
    public GameObject[] doors; // 0-up, 1- down, 2- right, 3- left


    public void UpdateRoom(bool[] status)
    {
        for (int i = 0; i < status.Length; i++)
        {
            doors[i].SetActive(!status[i]);
        }
    }
}
