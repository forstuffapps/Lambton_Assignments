package Assignment_03;

public class Truck extends Vehicle{
	
	   double maxPayload;
	   double bedLength;
	   
	   public Truck(String Data_make, String Data_model, int Data_year, double Data_maxPayload, double Data_bedLength){
		   
		   make=Data_make;
		   model=Data_model;
		   year=Data_year;
		   maxPayload=Data_maxPayload;
		   bedLength=Data_bedLength;
	   }

	}