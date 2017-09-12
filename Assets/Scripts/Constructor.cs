using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Constructor : MonoBehaviour, Constructable
{
    public Transform[] elements;
    public float animationTime = 0.1f;
    public float boomScale = 1.2f;
	public float maxScale = 1;

    private int elementIndex = 0;
    private int amountOfNumbers;
    void Start()
    {
        amountOfNumbers = elements.Length;
        foreach (Transform element in elements)
        {
            element.localScale = new Vector3(0, 0, 0);
        }
    }

    public void Construct()
    {
        if (elementIndex == amountOfNumbers)
        {
            return;
        }
        StartCoroutine(Grow(elements[elementIndex]));
        elementIndex++;
    }

    IEnumerator Grow(Transform element)
    {
        float currentTime = 0;
        Vector3 scaleZero = new Vector3();
		Vector3 blownScale = new Vector3(maxScale, maxScale, maxScale) * boomScale;
		Vector3 fullScale = new Vector3(maxScale, maxScale, maxScale);
        while (currentTime < animationTime)
        {
            currentTime += Time.deltaTime;
            float progress = currentTime / animationTime;
            if (progress < 0.75f)
            {
                element.localScale = Vector3.Lerp(scaleZero, blownScale, (progress / 0.75f));
            }
            else
            {
                element.localScale = Vector3.Lerp(blownScale, fullScale, progress);
            }
            yield return null;
        }
    }
}
