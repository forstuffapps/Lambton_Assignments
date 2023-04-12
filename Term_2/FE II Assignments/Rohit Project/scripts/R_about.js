$(document).ready(function() {

    // Add a click event handler to all <a> elements
    $('a').click(function() {
  
      // Toggle the "hide" class of the previous sibling element with class "hide"
      $(this).prev('div').toggleClass('hide');
  
      // Check if the previous sibling element with class "hide" still has the class
      if ($(this).prev('div').hasClass('hide')) {
  
        // If it does, change the text of the clicked link to "Show more"
        $(this).text('Show more');
  
      } else {
  
        // If it doesn't, change the text of the clicked link to "Show less"
        $(this).text('Show less');
  
      }
    });
  });






