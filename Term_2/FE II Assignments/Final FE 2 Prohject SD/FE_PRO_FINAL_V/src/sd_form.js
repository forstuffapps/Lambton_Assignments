$(document).ready(
  
  function() 
{


  
    // validating the form using jQuery validation plugin
    $('#contact_form').validate(
    {
        // writing these rules
      rules: 
      {
        // writing the rules for arrival date. stating the required and date
        sd_dob: 
        {
          required: true,
          dateISO: true
        },
        // writing the riules for nights. stating the required, making sure it only has digits and minimum of 1 number
        
        // making sure it has a name
        sd_fname: 
        {
          required: true
        },
        sd_lname: 
        {
          required: true
        },
        sd_email: // making sur ethe format is in email eith @
        {
          required: true,
          email: true
        }
      },
      messages: 
      {
        // defining the messages for the above rules
        sd_dob: 
        {
          required: 'This field is required',
          dateISO: 'Please enter a valid date format YYYY-MM-DD.'
        },
        
        sd_fname: 
        {
          required: 'This field is required'
        },
        sd_lname: 
        {
          required: 'This field is required'
        },
        sd_email: 
        {
          required: 'This field is requiredd',
          email: 'Please enter a valid email address.'
        }
        
      }
    });
  }
  
  

  
  );
  