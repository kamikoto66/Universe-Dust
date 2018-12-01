using UnityEngine;
using System.Collections;

public static class TableLocator
{
    public static ItemTable _ItemTabl { get; private set; }

    static TableLocator()
    {
        _ItemTabl = new ItemTable("Table/Item");
    }
}
