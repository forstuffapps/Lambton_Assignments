$(document).ready(function() 
{


    // move focus to arrival date text box on pae loading
    $('arrival_date').focus();
  
    // validating the form using jQuery validation plugin
    $('#reservation_form').validate(
    {
        // writing these rules
      rules: 
      {
        // writing the rules for arrival date. stating the required and date
        arrival_date: 
        {
          required: true,
          date: true
        },
        // writing the riules for nights. stating the required, making sure it only has digits and minimum of 1 number
        nights: 
        {
          required: true,
          digits: true,
          min: 1
        },
        // making sure it has a name
        name: 
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
        arrival_date: 
        {
          required: 'Required Field',
          date: 'Please enter a valid date format YYYY-MM-DD.'
        },
        nights: 
        {
          required: 'Required Field',
          digits: 'Please enter a positive integer.',
          min: 'Please enter a positive integer.'
        },
        name: 
        {
          required: 'Required Field'
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
  