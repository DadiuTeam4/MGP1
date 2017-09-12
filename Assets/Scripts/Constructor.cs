using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(ParticleSystem))]
public class Constructor : MonoBehaviour, Constructable
{
    public Transform[] elements;
    public float animationTime;

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
        while (currentTime < animationTime)
        {
            currentTime += Time.deltaTime;
            print((currentTime / animationTime));
            element.localScale = Vector3.Lerp(new Vector3(), new Vector3(1, 1, 1), (currentTime / animationTime));
            yield return null;
        }
    }
}
