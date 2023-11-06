public enum Resources : int
{
    Tree = 1,
    Stone = 2,
    Copper = 3,
    Iron = 4,
    Gold = 5,
    Platinum = 6,
    Crystal = 0, // то что надо собрать для цели игры
}

public enum UpgradableTools : int
{
    None = 0,
    Pickaxe = 1,
    Axe = 2,
    Sword = 4,
    Helmet = 5,
    Chestplate = 6,
    Leggings = 7,
    Boots = 8,
}

public enum Tools : int
{
    None = 0,
    Boat = 1,
}

public enum ItemType : int
{
    UpgradableTool = 1,
    Tool = 2,
    Amulete = 3,
}
