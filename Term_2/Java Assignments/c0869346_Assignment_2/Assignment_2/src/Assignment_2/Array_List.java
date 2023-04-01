package Assignment_2;

public class Array_List {
	
	
	public static void sort(int[] toSort)
	{
		
		int Len_of_Array = toSort.length;
		
        for (int index_1 = 1; index_1 < Len_of_Array; index_1++) 
        {
        	
        	int index_2 = index_1 - 1;
        	
        	
            int K = toSort[index_1];
            
            
            while (index_2 >= 0 && toSort[index_2] > K) 
            {
            	toSort[index_2 + 1] = toSort[index_2];
                index_2 -= 1;
            }
            
            
            toSort[index_2 + 1] = K;
        }
		  
		
	}
	
	public static int max(int[] toSearch)
	{
		int Len_of_Array = toSearch.length;
		int Max_Number = -1;
		for (int index_1 = 1; index_1 < Len_of_Array; index_1++) 
        {	
			Max_Number = ( (Max_Number<toSearch[index_1]) ? toSearch[index_1] : Max_Number);
        }
		
		return Max_Number;
		
				
	}
	
	
	public static boolean search(String[] toSearch, String toFind)
	{
		
		for (int index = 0; index < toSearch.length; index++) 
		{
			if(toSearch[index]== toFind)
			{
				return true;
			} 	
		}
		
		return false;
		
	}
	
	
	public static int median(int[] toSearch){
		int Length_of_Array = toSearch.length;
		Array_List.sort(toSearch);
		
		int Median = toSearch[Length_of_Array/2];
		
		if(toSearch.length % 2 == 0)
		{
			Median += toSearch[Length_of_Array/2-1];
			Median /=2;
		}

		return Median;
		
	}
	


}