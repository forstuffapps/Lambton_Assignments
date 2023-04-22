package Assignment_03;

public class VehicleTest {

	public static void main(String[] args) {
		
		Vehicle [] Vehicles_Data = new Vehicle[5] ;
		
		Vehicles_Data[0]= new Car("McLaren","P1",2013,2,2);
		Vehicles_Data[1]= new Truck ("Freightliner","Argosy",208,140,26);
		Vehicles_Data[2]= new Car("Koenigsegg","Agera",2018,2,2);
		Vehicles_Data[3]= new Car ("Aston Martin","DB11",2016,2,2);
		Vehicles_Data[4]= new Truck ("Freightliner","FL86",2010,660,72);
		
		int size = 5;
		System.out.println("These are the famous car details");
		
		int i=0;
		while (i<5)
		{
			
			System.out.println("\nThe Maker : "+Vehicles_Data[i].make+"\nModel : "+Vehicles_Data[i].model+"\nRelease Year : "+Vehicles_Data[i].year);
			i++;
		}
		

	
}
}
