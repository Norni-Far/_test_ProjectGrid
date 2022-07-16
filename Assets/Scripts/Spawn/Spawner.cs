using System;
using UnityEngine;
using UnityEngine.UI;

public class Spawner : MonoBehaviour
{
    public delegate void BoxDestroyDelegats(Spawner spawner);
    public event BoxDestroyDelegats event_destroyAllBox;

    [SerializeField] private MoveText MoveText;

    [SerializeField] private GameObject prefab_BoxObject;

    [SerializeField] private GridLayoutGroup gridSettings;
    [SerializeField] private RectTransform contentTransform;

    [SerializeField] private TMPro.TMP_InputField inputWidthArray;
    [SerializeField] private TMPro.TMP_InputField inputHieghtArray;

    private int widthArray = 1;
    private int hieghtArray = 1;

    public void StartWorkSpawner()
    {
        if (contentTransform.transform.childCount != 0) event_destroyAllBox?.Invoke(this);

        widthArray = CheckNumber(Convert.ToInt32(inputWidthArray.text));
        hieghtArray = CheckNumber(Convert.ToInt32(inputHieghtArray.text));

        inputWidthArray.text = widthArray.ToString();
        inputHieghtArray.text = hieghtArray.ToString();

        SetSettingsForGrid();
    }

    private void SetSettingsForGrid()
    {
        int widthOfBox = (int)((contentTransform.rect.width - (5 * widthArray)) / widthArray) > 350 ? 350 : (int)((contentTransform.rect.width - (5 * widthArray)) / widthArray);
        int hieghtOfBox = (int)((contentTransform.rect.height - (5 * hieghtArray)) / hieghtArray) > 350 ? 350 : (int)((contentTransform.rect.height - (5 * hieghtArray)) / hieghtArray);

        if (widthOfBox > hieghtOfBox)
            gridSettings.cellSize = new Vector2(hieghtOfBox, hieghtOfBox);
        else
            gridSettings.cellSize = new Vector2(widthOfBox, widthOfBox);

        gridSettings.constraintCount = widthArray;

        SpawnObjects(widthArray * hieghtArray);
    }

    private void SpawnObjects(int colOfSpawn)
    {
        MoveText.boxObjects.Clear();
        MoveText.newPositionForTextFromBox.Clear();

        for (int i = 0; i < colOfSpawn; i++)
        {
            BoxSelf inst = Instantiate(prefab_BoxObject, contentTransform.transform).GetComponent<BoxSelf>();
            event_destroyAllBox += inst.DestroyBox;
            MoveText.boxObjects.Add(inst.gameObject);
        }
    }

    private int CheckNumber(int num)
    {
        if (num < 1) return 1;
        else if (num > 50) return 50;
        else return num;
    }
}
