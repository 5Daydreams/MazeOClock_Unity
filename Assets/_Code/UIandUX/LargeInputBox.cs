﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using _Code.MainCode;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class LargeInputBox : MonoBehaviour
{
    [SerializeField] private Button _closeWindowButton;
    [SerializeField] private Button _confirmButton;
    [SerializeField] private MazeGenerator _maze;

    private void OnEnable()
    {
        if (!gameObject.activeInHierarchy)
            return;
        _closeWindowButton.onClick.AddListener(() => CloseThisWindow());
        _confirmButton.onClick.AddListener(() =>
        {
            _maze.NewMaze();
            _maze.GenerateMaze();
            CloseThisWindow();
        });
    }
    
    public void CloseThisWindow()
    {
        this.gameObject.SetActive(false);
    }

    public void OpenThisWindow()
    {
        this.gameObject.SetActive(true);
    }
}