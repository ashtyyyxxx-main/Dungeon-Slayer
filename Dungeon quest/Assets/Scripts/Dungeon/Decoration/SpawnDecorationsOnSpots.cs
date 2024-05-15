using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SpawnDecorationsOnSpots : MonoBehaviour
{
    public List<GameObject> smallObjects;
    public List<GameObject> mediumObjects;
    public List<GameObject> bigObjects;

    private void Start()
    {

    }

    private Decoration[] FindAllDecorations()
    {
        return FindObjectsOfType<Decoration>();
    }

    public void DestroyDecorTest()
    {
        Decoration[] decorations = FindAllDecorations();

        foreach (Decoration decoration in decorations)
        {
            for (int i = 0; i < decoration.transform.childCount; i++)
            {
                Destroy(decoration.transform.GetChild(i).gameObject);
            }
        }
    }

    public void SpawnDecoration()
    {
        Decoration[] decorations = FindAllDecorations();

        foreach (Decoration decoration in decorations)
        {
            switch (decoration.decorType)
            {
                case DecorType.small:
                    if(smallObjects.Count != 0)
                    {
                        int randomIndexS = Random.Range(0, smallObjects.Count);
                        Instantiate(smallObjects[randomIndexS], decoration.gameObject.transform);
                        decoration.GetComponent<MeshRenderer>().enabled = false;
                        decoration.GetComponent<Collider>().enabled = false;
                    }

                    break;

                case DecorType.medium:
                    if(mediumObjects.Count != 0)
                    {                    
                        int randomIndexM = Random.Range(0, mediumObjects.Count);
                        Instantiate(mediumObjects[randomIndexM], decoration.gameObject.transform);
                        decoration.GetComponent<MeshRenderer>().enabled = false;
                    }
                    break;

                case DecorType.big:
                    if(bigObjects.Count != 0)
                    {
                        int randomIndexB = Random.Range(0, bigObjects.Count);
                        Instantiate(bigObjects[randomIndexB], decoration.gameObject.transform);
                        decoration.GetComponent<MeshRenderer>().enabled = false;
                    }

                    break;

            }
        }
    }
}

[System.Serializable]
public enum DecorType
{
    small,
    medium,
    big
}