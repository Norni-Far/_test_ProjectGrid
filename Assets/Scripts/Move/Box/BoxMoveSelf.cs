using System.Collections;
using UnityEngine;

public class BoxMoveSelf : MonoBehaviour
{
    [SerializeField] private GameObject transformOfText;

    [SerializeField] private RectTransform posOftext;

    [SerializeField] private Vector2 startPos;
    [SerializeField] private Vector2 speed;

    private void Start()
    {
        posOftext = transformOfText.gameObject.GetComponent<RectTransform>();
    }

    public void SetSpeedAndTarget(int time, Transform target)
    {
        transformOfText.transform.parent = target;
        startPos = new Vector2(posOftext.anchoredPosition.x, posOftext.anchoredPosition.y);
        speed = startPos / time;

        StartCoroutine(StartMove(time));
    }

    private IEnumerator StartMove(int time)
    {
        for (int i = 0; i < time; i++)
        {
            Step();

            yield return new WaitForSeconds(0.01f);
        }

        EndMove();
    }

    public void Step() => posOftext.anchoredPosition = new Vector2(posOftext.anchoredPosition.x - speed.x, posOftext.anchoredPosition.y - speed.y);

    public void EndMove() => posOftext.anchoredPosition = new Vector2(0, 0);

}
