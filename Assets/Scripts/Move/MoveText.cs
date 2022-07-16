using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveText : MonoBehaviour
{
    public delegate void BoxChangePlaceDelegats();
    public event BoxChangePlaceDelegats event_ChangePlaceAllOfText;

    [SerializeField] private CheckButton CheckButton;
 
    public List<GameObject> boxObjects = new List<GameObject>();
    public List<GameObject> newPositionForTextFromBox = new List<GameObject>();

    [SerializeField] private int timeForMove;
    public void MixTextFromBox()
    {
        CheckButton.OffButton();

        SetRandomposition();
    }

    private void SetRandomposition()
    {
        newPositionForTextFromBox.Clear();
        GameObject[] _newPositionForTextFromBox = new GameObject[boxObjects.Count];

        _newPositionForTextFromBox = boxObjects.ToArray();

        System.Random rnd = new();

        for (int i = _newPositionForTextFromBox.Length - 1; i >= 1; i--)
        {
            int j = rnd.Next(i + 1);
            var temp = _newPositionForTextFromBox[j];
            _newPositionForTextFromBox[j] = _newPositionForTextFromBox[i];
            _newPositionForTextFromBox[i] = temp;
        }

        newPositionForTextFromBox.AddRange(_newPositionForTextFromBox);

        StartMove();
    }

    private void StartMove()
    {
        for (int i = 0; i < boxObjects.Count; i++)
        {
            boxObjects[i].GetComponent<BoxMoveSelf>().SetSpeedAndTarget(timeForMove, newPositionForTextFromBox[i].transform);
        }

        StartCoroutine(CheckTime());
    }

    private IEnumerator CheckTime()
    {
        yield return new WaitForSeconds((float)timeForMove / 60);
        CheckButton.OnButton();
    }
}
