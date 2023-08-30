using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// static singleton that holds the game values
/// using simple thread-safety from: https://csharpindepth.com/articles/singleton
/// </summary>
public sealed class GameValues {
    private static GameValues _gameValuesInstance;
    private static readonly object padlock = new object();
    
      GameValues(){}

      public static GameValues Instance
      {
          get
          {
              lock (padlock)
              {
                  if (_gameValuesInstance == null)
                  {
                      _gameValuesInstance = new GameValues();
                  }
                  return _gameValuesInstance;
              }
          }
      }
    
    public  Pet _petInstance;
    public  NeedsManager _needsManager;
    
}
