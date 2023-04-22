package Final_Exam;
import java.io.IOException;
import java.io.FileReader;
import java.io.BufferedReader;


public class HomeFieldReader 
{
	
	public void fileReader() {
        String filePath = "baseballHomefields.txt";
        System.out.println("\nALL Teams List");
        try (BufferedReader br = new BufferedReader(new FileReader(filePath))) {
            String line;
            while ((line = br.readLine()) != null) {
                System.out.println(line);
            }
        } catch (IOException e) {
            e.printStackTrace();
        }
    }
	
}
