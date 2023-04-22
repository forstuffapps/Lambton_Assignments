package Final_Exam;

public class Basketball extends Sports
{
	boolean hasThreePointLine;
	  String teamColor;

	public Basketball(String Name,int Player_Count,boolean Is_Team_Sport, boolean Has_Three_Point_Line,String Team_Color ){
		this.name=Name;
		this.playerCount=Player_Count;
		this.isTeamSport=Is_Team_Sport;
		this.hasThreePointLine= Has_Three_Point_Line;
		this.teamColor=Team_Color;
		
	}
	public boolean Get_Three_Point_Line() {
		return hasThreePointLine;
	}
	
	
	
}
