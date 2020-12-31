using System;
using System.Collections.Generic;

class Adventure{
    public int adventureId;
    public string title;
    public string description;
    public int duration;
    private List<Character> party = new List<Character>();
    private int currentProgress = 0;

    private Reward rewards;

    private SuccessRequirements sReqs;
    private AvailabilityRequirements aReqs;

    public Adventure(int id, string adventureTitle, string desc, int adventureDuration, AvailabilityRequirements availabilityReqs, SuccessRequirements successReqs, Reward reward){
        this.adventureId = id;
        this.title = adventureTitle;
        this.description = desc;
        this.duration = adventureDuration;

        this.sReqs = successReqs;
        this.aReqs = availabilityReqs;
        this.rewards = reward;
    }

    public bool isAvailable(){
        return this.aReqs.isMet;
    }

    public int advanceProgress(){
        //Aggregate the party values for mind, body and soul
        this.currentProgress++;
        
        if (this.currentProgress > this.duration){
            int soulSum = 0;
            int mindSum = 0;
            int bodySum = 0;
            int levelSum = 0;
            party.ForEach(delegate(Character character){
                soulSum += character.Soul;
                mindSum += character.Mind;
                bodySum += character.Body;
                levelSum += character.levelSum;
            });

            this.sReqs.testMeeting(levelSum, mindSum, bodySum, soulSum);
            if(this.sReqs.isMet){
                return this.resolveAdventure();
            }
        }
    }

    private int ResolveAdventure(){
        int xpReward = Math.Floor(this.rewards.XP/party.Count);
        party.ForEach(delegate(Character character){
            character.updateXp(xpReward);
            character.adventureClear();
        });
        return this.rewards.Gold;
    }



}