using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private int rows;
    [SerializeField] private int cols;
    [SerializeField] private GameObject[] boardGameObjects;
    
    private int[,] matrixBoard;

    void Start()
    {
    
    }
}