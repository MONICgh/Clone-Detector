using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace BinaryTree;

public class BinaryNode
{
    public int Id { get; set; }
    public BinaryNode? Left { get; set; }
    public BinaryNode? Right { get; set; }

    private int Size()
    {
        var leftSize = Left?.Size() ?? 0;
        var rightSize = Right?.Size() ?? 0;
        var size = 1 + 2 * Math.Max(leftSize, rightSize);
        return size;
    }

    public override bool Equals(object? obj)
    {
        if (obj is BinaryNode node)
        {
            return node.Id == Id && Equals(node.Left, Left) && Equals(node.Right, Right);
        }

        return false;
    }

    public override string ToString()
    {
        return $"( {Left} {Id} {Right} )";
    }

    public BinaryNode(int id)
    {
        Id = id;
        Left = null;
        Right = null;
    }

    public BinaryNode(string serialized)
    {
        List<BinaryNode?> nodes = serialized
            .Split(',')
            .Select(it =>
                {
                    if (it.Length == 0)
                        return null;
                    return new BinaryNode(int.Parse(it));
                })
            .ToList();
        for (int i = nodes.Count - 1; i >= 0; i--)
        {
            var node = nodes[i];
            if (node != null && 2 * i + 2 < nodes.Count)
            {
                node.Left = nodes[2 * i + 1];
                node.Right = nodes[2 * i + 2];
            }
            
        }

        Id = nodes[0].Id;
        Left = nodes[1];
        Right = nodes[2];
    }

    public string Serialize()
    {
        var preSerialized = new List<BinaryNode?>(Size());
        for (int i = 0; i < Size(); i++)
        {
            preSerialized.Add(null);
        }

        preSerialized[0] = this;

        for (int i = 0; i < Size(); i++)
        {
            var node = preSerialized[i];
            if (node != null)
            {
                if (node.Left != null)
                    preSerialized[2 * i + 1] = node.Left;
                if (node.Right != null)
                    preSerialized[2 * i + 2] = node.Right;
            }
        }
        
        return string.Join(',', preSerialized.Select(it => it?.Id ));
    }
}
