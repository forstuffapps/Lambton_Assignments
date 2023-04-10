$(document).ready(function() 
{


    // move focus to arrival date text box on page loading
    $('arrival_date').focus();
  
    // validating the form using jQuery validation plugin
    $('#reservation_form').validate(
    {
        // writing these rules
      rules: 
      {
		// writing the rules for arrival date. stating the required and date
        name: 
        {
          required: true
        },
		name1: 
        {
          required: true
        },
        dob: 
        {
          required: true,
          date: true
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
          required: 'Required Field',
          date: 'Please enter a valid date format YYYY-MM-DD.'
        },
		name: 
        {
          required: true
        },
		name1: 
        {
          required: true
        },
        email: 
        {
          required: 'Required Field',
          email: 'Please enter a valid email address.'
        },
        phone: 
        {
          required: 'Required Field',
          phoneUS: 'Please enter a valid Phone Number'
        }
      }
    });
  });
  