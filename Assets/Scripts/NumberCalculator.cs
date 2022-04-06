using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class NumberHolder : MonoBehaviour
{
    char sonuc;
    int temp = 0;
    public static int totalLetterValue;
    public GameObject arrow;
    public TextMeshPro totalLetter;
    char[] Letter = new char[4] { 'x', '÷', '+', '-' };
    public TextMeshPro input;
    string integerLetter;
    private int lowerHolder;
    protected static int convertIntegerLetter;

    private void Start()
    {
        totalLetterValue = 1;
        Time.timeScale = 1;
    }

    private void Update()
    {

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            integerLetter = input.text;
            Debug.Log("Sayý:" + integerLetter);

            for (int k = 0; k < integerLetter.Length; k++)
            {
                for (int j = 0; j < Letter.Length; j++)
                {
                    if (Letter[j] == integerLetter[k])
                    {
                        sonuc = Letter[j];
                        Debug.Log("Ýþlem Operatörü" + sonuc);
                        //mathProblems();
                        string[] words = integerLetter.Split('x', '÷', '+', '-');

                        int.TryParse(words[1], out convertIntegerLetter);
                        switch (sonuc)
                        {

                            case 'x':
                                totalLetterValue = convertIntegerLetter * totalLetterValue;
                                break;
                            case '÷':
                                totalLetterValue = totalLetterValue / convertIntegerLetter;
                                break;
                            case '+':
                                temp = temp + convertIntegerLetter;
                                totalLetterValue = temp + totalLetterValue;
                                break;
                            case '-':
                                temp = temp - convertIntegerLetter;
                                totalLetterValue = temp + totalLetterValue;
                                break;
                        }
                        int[] arrayTotalLetter = new int[totalLetterValue];
                        totalLetter.text = totalLetterValue.ToString();

                        //arrowGenerator.GenerateArrow();
                    }
                }
            }
        }
    }
}
