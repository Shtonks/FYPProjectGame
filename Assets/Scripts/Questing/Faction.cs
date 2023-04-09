using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Faction
{
    // repuatation
    private int rep;
    private int maxRep;
    private int minRep;
    protected string name;

    public Faction (){
        rep = 50;
        maxRep = 100;
        minRep = 0;
    }

    public void increaseRep(int n) {
        if(rep + n < maxRep) {
            rep += n;
        } else {
            rep = 100;
        }
    }

    public void decreaseRep(int n) {
        if(rep - n > minRep) {
            rep -= n;
        } else {
            rep = 0;
        }
    }

    public int getRep() {
        return rep;
    }

    public string getName() {
        return name;
    }

    public int getMaxRep() {
        return maxRep;
    }

    public int getMinRep() {
        return minRep;
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

public class RintochGateway : Faction
{
    private static RintochGateway instance = null;
    private static readonly object padlock = new object();

    protected RintochGateway() : base()
    {
        name = "RintochGateway";
    }

    public static RintochGateway Instance
    {
        get
        {
            lock (padlock)
            {
                if (instance == null)
                {
                    instance = new RintochGateway();
                }
                return instance;
            }
        }
    }
}