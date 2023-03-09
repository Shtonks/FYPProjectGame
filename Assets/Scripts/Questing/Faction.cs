using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Faction
{
    // repuatation
    private int rep;
    protected string name;

    public Faction (){
        rep = 0;
    }

    public void increaseRep(int n) {
        rep += n;
    }

    public void decreaseRep(int n) {
        rep -= n;
    }

    public int getRep() {
        return rep;
    }

    public string getName() {
        return name;
    }
}

// NOTE: All factions are thread safe singletons

public class Jura : Faction
{
    private static Jura instance = null;
    private static readonly object padlock = new object();

    protected Jura() : base()
    {
        name = "Jura";
    }

    public static Jura Instance
    {
        get
        {
            lock (padlock)
            {
                if (instance == null)
                {
                    instance = new Jura();
                }
                return instance;
            }
        }
    }
}

public class Nardvaal : Faction
{
    private static Nardvaal instance = null;
    private static readonly object padlock = new object();

    protected Nardvaal() : base()
    {
        name = "Nardvaal";
    }

    public static Nardvaal Instance
    {
        get
        {
            lock (padlock)
            {
                if (instance == null)
                {
                    instance = new Nardvaal();
                }
                return instance;
            }
        }
    }
}

public class Welkan : Faction
{
    private static Welkan instance = null;
    private static readonly object padlock = new object();

    protected Welkan() : base()
    {
        name = "Welkan";
    }

    public static Welkan Instance
    {
        get
        {
            lock (padlock)
            {
                if (instance == null)
                {
                    instance = new Welkan();
                }
                return instance;
            }
        }
    }
}
