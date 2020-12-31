interface IRequirements{

    bool isMet{
        get;set;
    }

    void testMeetiing();

}

class SuccessRequirements : IRequirements{


    private int _isMet;
    public bool isMet{
        get => _isMet;
        set => _isMet = value; 
    }

    public int Level {
        get; set;
    }

    public int  Mind{
        get; set;
    }

    public int Body {
        get; set;
    }

    public int Soul {
        get; set;
    }
    public SuccessRequirements(int level, int mind, int body, int soul){
        this.Level(level);
        this.Mind(mind);
        this.Body(body);
        this.Soul(soul);
        
        this.isMet(false);
    }

    public void testMeeting(int level, int mind, int body, int soul){
        if (this.Mind < mind && this.Level < level && this.Body < body && this.Soul < soul){
            this.isMet(true);
        }
    }
}
class AvailabilityRequirements : IRequirements{


    private int _isMet;
    public bool isMet{
        get => _isMet;
        set => _isMet = value; 
    }

    public int calendarDay {
        get; set;
    }

    public int  calendarSeason{
        get; set;
    }

    public AvailabilityRequirements(int calendarDay, int calendarSeason){
        this.calendarDay(calendarDay);
        this.calendarSeason(calendarSeason);

        this.isMet(false);
    }

    public void testMeeting(int currentDay, int currentSeason){
        if (this.calendarDay  >= currentDay && this.calendarSeason == currentSeason){
            this.isMet(true);
        }
    }
}