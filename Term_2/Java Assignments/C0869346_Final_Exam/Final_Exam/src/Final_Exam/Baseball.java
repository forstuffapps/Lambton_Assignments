package Final_Exam;

public class Baseball extends Sports
{
boolean hasDesignatedHitter;
String homeField;

public Baseball(String Name,int Player_Count,boolean Is_Team_Sport,boolean Has_Designated_Hitter, String Home_Field){
	this.name=Name;
	this.playerCount=Player_Count;
	this.isTeamSport=Is_Team_Sport;
	this.hasDesignatedHitter=Has_Designated_Hitter;
	this.homeField=Home_Field;
	
	
}

public boolean Get_Designated() {
	return hasDesignatedHitter;
}



public String Get_HomeField() {
	return homeField;
}



}
