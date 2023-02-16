using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorPlatforms : MonoBehaviour
{
    int count = 0;
    MeshRenderer[] boxes = new MeshRenderer[4];
    public Material red;
    public Material green;
    // Start is called before the first frame update
    void Start()
    {
        foreach (MeshRenderer mr in this.gameObject.GetComponentsInChildren<MeshRenderer>())
        {
            boxes[count] = mr;
            count++;
        }
        count = 0;
        InvokeRepeating("ChangeColors", 0.1f, 1f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void ChangeColors()
    {
        switch (count)
        {
            case 0:
                boxes[3].material = green;
                boxes[0].material = green;
                boxes[1].material = red;
                boxes[2].material = red;
                count++;
                break;
            case 1:
                boxes[0].material = green;
                boxes[1].material = green;
                boxes[2].material = red;
                boxes[3].material = red;
                count++;
                break;
            case 2:
                boxes[1].material = green;
                boxes[2].material = green;
                boxes[3].material = red;
                boxes[0].material = red;
                count++;
                break;
            case 3:
                boxes[2].material = green;
                boxes[3].material = green;
                boxes[0].material = red;
                boxes[1].material = red;
                count++;
                break;
            default:
                count = 0;
                boxes[3].material = green;
                boxes[0].material = green;
                boxes[1].material = red;
                boxes[2].material = red;
                count++;
                break;
        }
    }
}
