using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class NewTestScript
{
    private Board game;

    [UnityTest]
    public IEnumerator SpawnPiece()
    {
        GameObject gameGameObject = 
            MonoBehaviour.Instantiate(Resources.Load<GameObject>("Tests/Board"));
        
        game = gameGameObject.GetComponent<Board>();
        
        Assert.NotNull(game.activePiece);
        
        yield return null;

        Assert.NotNull(game.activePiece);
        
        var initialData = game.activePiece.data;
        
        game.SpawnPiece();
        
        Assert.NotNull(game.activePiece);
        Assert.AreNotEqual(game.activePiece.data, initialData);
        
        Object.Destroy(game.gameObject);
    }
    
    [UnityTest]
    public IEnumerator GameOver()
    {
        GameObject gameGameObject = 
            MonoBehaviour.Instantiate(Resources.Load<GameObject>("Tests/Board"));
        
        game = gameGameObject.GetComponent<Board>();

        var initSize = game.tilemap.size;
        
        yield return null;
        
        game.GameOver();
        
        Assert.AreEqual(game.tilemap.size, initSize);
        
        Object.Destroy(game.gameObject);
    }
    
    [UnityTest]
    public IEnumerator IsLineFull()
    {
        GameObject gameGameObject = 
            MonoBehaviour.Instantiate(Resources.Load<GameObject>("Tests/Board"));
        
        game = gameGameObject.GetComponent<Board>();
        
        yield return null;
        
        game.activePiece.HardDrop();
        
        yield return null;
        
        var row = game.Bounds.yMax - 1;
        
        var lineFull = game.IsLineFull(row);
        
        Assert.AreEqual(false, lineFull);
        
        Object.Destroy(game.gameObject);
    }
}
