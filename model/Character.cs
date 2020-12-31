using System;

public class Character {

    private int regardForOthers = 0;
    private int favoredTerrain = 0;
    private int bravery = 0;

    private int regardForOthersBias = 0;
    private int favoredTerrainBias = 0;
    private int braveryBias = 0;

    public string Name{
        get;
    }
    public int Level {
        get;
    }
    public int Xp{ 
        get;
    }

    public int Mind{
        get;set;
    }
    public int Body{
        get; set;
    }

    public int Soul{
        get; set;
    }

    private bool onAdventure = false;
    private int adventureId = 0;

    public Character(string charName, int startingXp, int mind, int body, int soul){
        Random rnd = new Random();
        this.name = charName;
        this.xp = startingXp;
        this.level = calculateLevel(xp);
        this.regardForOthers = rnd.Next(-10,10) + regardForOthersBias;
        this.favoredTerrain = rnd.Next(-10,10) + favoredTerrainBias;
        this.bravery = rnd.Next(-10,10) + braveryBias;

        this.Mind(mind);
        this.Body(body);
        this.Soul(soul);

    }

    private int calculateLevel(int xp){
        //Call level up config data
        return (xp/1000) + 1;
    }

    public int updateXp(int value){
        this.xp += value;

        if (this.level < calculateLevel(this.xp)){
            levelUp();
        }
        return this.xp;
    }

    public void assignToAdventure(int adventure){
        this.onAdventure = true;
        this.adventureId = adventure;
    }

    public void adventureClear(){
        this.onAdventure = false;
        this.adventureId = 0;
    }

    public void levelUp(){
        this.level++;
    }
    
}