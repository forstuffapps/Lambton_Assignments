"use strict";
var $ = function(id) { return document.getElementById(id); };


// defining the toggle funcion
var toggle = function() {
    var h2 = this;                    // clicked h2 tag     
    var div = h2.nextElementSibling;  // h2 tag's sibling div tag

    // declaring the div siblingf to access the parent node of h2
    var div_Siblings = h2.parentNode.getElementsByTagName("div");

    // iterating through the loop to remove the class attributes of h2 i.e text
    for (var index_1 = 0; index_1 < div_Siblings.length; index_1++) 
    {
        if (div_Siblings[index_1] !== div) 
        {
            div_Siblings[index_1].removeAttribute("class");
        }
    }


     // deckallring the h2 parent node of h2
     var h2_Siblings = h2.parentNode.getElementsByTagName("h2");

     // iterating theought the loop to remove all the minus attributes
     for (var index_2 = 0; index_2 < h2_Siblings.length; index_2++) 
     {
         if (h2_Siblings[index_2] !== h2) 
         {
             h2_Siblings[index_2].removeAttribute("class");
         }
     }



    
    if (h2.hasAttribute("class")) 
    {     
        h2.removeAttribute("class");	
    } else 
    { 
        h2.setAttribute("class", "minus"); 
    }


    if (div.hasAttribute("class")) 
    { 
        div.removeAttribute("class");
    } else 
    { 
        div.setAttribute("class", "open"); 
    } 
    
    
};


// defingint he onload function
window.onload = function() 
{
    var faqs = $("faqs");
    var h2Elements = faqs.getElementsByTagName("h2");
    
    for (var i = 0; i < h2Elements.length; i++ ) 
    {
    	h2Elements[i].onclick = toggle;
    }
    h2Elements[0].firstChild.focus();       
};
