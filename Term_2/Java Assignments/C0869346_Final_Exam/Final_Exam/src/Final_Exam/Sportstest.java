package Final_Exam;
import java.io.IOException;
import java.io.PrintWriter;



public class Sportstest 
{
	 
	public static void main(String[] args) {
		// TODO Auto-generated method stub
		
		Sports[] ALL_Sports_Data = new Sports[10];
		
		ALL_Sports_Data[0]= new Sports("FootBall",12,false);
		ALL_Sports_Data[1]= new Basketball("Basketball",12,true,false,"Red");
		ALL_Sports_Data[2]= new Baseball("Baseball",12,false,true,"TITANS");
		ALL_Sports_Data[3]= new Sports("Hockey",21,true);
		ALL_Sports_Data[4]= new Basketball("Basketball",12,false,true,"voilet");
		ALL_Sports_Data[5]= new Sports("Kabaddi",8,true);
		ALL_Sports_Data[6]= new Basketball("Basketball",11,true,true,"cyan");
		ALL_Sports_Data[7]= new Baseball("Baseball",11,false,false,"RETRO");
		ALL_Sports_Data[8]= new Sports("Ice-Water",65,false);
		ALL_Sports_Data[9]= new Baseball("Baseball",12,true,true,"NIGHTS");
		
		
		int size = ALL_Sports_Data.length;
		
		System.out.println("We will be printing all the sports data. All the data is structurized");
		
		int i=0;
		while(i<size)
		{
		
			
			System.out.println("\n"+ALL_Sports_Data[i].name);
			
			if (ALL_Sports_Data[i] instanceof Basketball)
			{
				System.out.println("Name : "+ALL_Sports_Data[i].name+"\nHasThreePointLine T/F???: "+((Basketball) ALL_Sports_Data[i]).Get_Three_Point_Line());
			}
			if (ALL_Sports_Data[i] instanceof Baseball)
			{
				System.out.println("Name : "+ALL_Sports_Data[i].name+"\nHome Field : "+((Baseball) ALL_Sports_Data[i]).Get_HomeField());
			}
			
			i++;
		}
		
		
		
		try {
		    PrintWriter Writer_Pointer = new PrintWriter("baseballHomefields.txt");
		    
		    for(Sports Sport_Pointer: ALL_Sports_Data) 
		    {
		        if(Sport_Pointer instanceof Baseball) 
		        {
		            Writer_Pointer.println(((Baseball) Sport_Pointer).Get_HomeField());
		        }
		    }
		    
		    Writer_Pointer.close();
			} 
		catch(IOException Caught_Exception) 
		{
		    System.out.println("An error occurred.");
		}
		
		
		HomeFieldReader reader =new HomeFieldReader();
		reader.fileReader();
		    
	}
}
