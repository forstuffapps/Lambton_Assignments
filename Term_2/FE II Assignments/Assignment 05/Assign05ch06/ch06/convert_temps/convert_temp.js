"use strict";
var $ = function(id) { return document.getElementById(id); };

// defininig the convert temp function
var convertTemp = function() 
{

    // declaring he fareheit and celcius variables
    var Temp_Fareheit, Temp_Celcius;  

    // writing the condition if the celcius is checked
    if ( $("to_celsius").checked ) 
    {    

        // coverting the entered values to float
        Temp_Fareheit = parseFloat( $("degrees_entered").value );

        // checking if the Farenheit value is NULL
        if (isNaN(Temp_Fareheit)) 
        { 
            alert("You must enter a valid number for degrees.");                    
        }                 
		else 
        {
        	Temp_Celcius = (Temp_Fareheit - 32) * 5/9;
	        $("degrees_computed").value = Temp_Celcius.toFixed(0);
		}


    }
    else 
    {
        // writing the condiotn if celcius is unchecked
        Temp_Celcius = parseFloat( $("degrees_entered").value );   
        if (isNaN(Temp_Celcius)) 
        { 
            alert("You must enter a valid number for degrees.");
        }
		else 
        {
			Temp_Fareheit = Temp_Celcius * 9/5 + 32;
	        $("degrees_computed").value = Temp_Fareheit.toFixed(0);
		}
        
    }
};



// definignth e to celcisu function
var toCelsius = function() 
{
    // efining with teh first child node values
    $("degree_label_1").firstChild.nodeValue = "Enter F degrees:";
    $("degree_label_2").firstChild.nodeValue = "Degrees Celsius:";
    // calling the clear boxes method
    clearTextBoxes();

    // shiftiing the focus to degrees entered
	$("degrees_entered").focus();
};

// defining the to farenheit function
var toFahrenheit = function() 
{

    // defining with teh first child node values
    $("degree_label_1").firstChild.nodeValue = "Enter C degrees:";
    $("degree_label_2").firstChild.nodeValue = "Degrees Fahrenheit:";

    // calling the clear boxes method
    clearTextBoxes();

    // shiftiing the focus to degrees entered
	$("degrees_entered").focus();
};


// definign the clear text boxes value
var clearTextBoxes = function() 
{
    $("degrees_entered").value = "";
    $("degrees_computed").value = "";
};


// defining the onliad function
window.onload = function() 
{
    $("convert").onclick = convertTemp;
    $("to_celsius").onclick = toCelsius;
    $("to_fahrenheit").onclick = toFahrenheit;
	$("degrees_entered").focus();
};