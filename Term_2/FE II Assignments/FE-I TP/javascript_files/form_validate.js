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
        dob: 
        {
          required: true,
          dateISO: true
        },
        // writing the riules for nights. stating the required, making sure it only has digits and minimum of 1 number
        
        // making sure it has a name
        fname: 
        {
          required: true
        },
        lname: 
        {
          required: true
        },
        email: // making sur ethe format is in email eith @
        {
          required: true,
          email: true
        },
        phone: 
        {
          required: true,
          phoneUS: true
        }
      },
      messages: 
      {
        // defining the messages for the above rules
        dob: 
        {
          required: 'This field is required',
          dateISO: 'Please enter a valid date format YYYY-MM-DD.'
        },
        
        fname: 
        {
          required: 'This field is required'
        },
        lname: 
        {
          required: 'This field is required'
        },
        email: 
        {
          required: 'This field is requiredd',
          email: 'Please enter a valid email address.'
        },
        phone: 
        {
          required: 'This field is required',
          phoneUS: 'Please enter a valid Phone Number'
        }
      }
    });
  }
  
  

  
  );
  