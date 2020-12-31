class Manager {
    private List<Character> roster = new List<Character>();

    private List<Adventure> ongoingAdventures = new List<Adventure>();

    private List<Adventure> completedAdventures = new List<Adventure>();

    public int Income  {
        get; set;
    }

    public int Maintenance {
        get; set;
    }

    public int totalFunds {
        get; set;
    }

    public Manager(){

    }

    public void dayIncomeUpdate(){
        this.totalFunds += this.Income - this.Maintenance;
        if (this.totalFunds < 0){
            this.totalFunds = 0;
        }
    }

    public void progressAdventures(){
        this.ongoingAdventures.forEach(delegate(Adventure adventure){
            int result = adventure.advanceProgress();
            if (result > 0){
                this.totalFunds += result;
                this.completedAdventures.Add(adventure);
            }
        });

        //Delete completed adventures
    }

}