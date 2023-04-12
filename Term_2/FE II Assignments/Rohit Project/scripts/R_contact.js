$(document).ready(
  
    function() 
  {
  
  
    
      // validating the form using jQuery validation plugin
      $('#R_contact').validate(
      {
          // writing these rules
        rules: 
        {
          // writing the rules for arrival date. stating the required and date
          R_dob: 
          {
            required: true,
            dateISO: true
          },
          // writing the riules for nights. stating the required, making sure it only has digits and minimum of 1 number
          
          // making sure it has a name
          R_first_name: 
          {
            required: true
          },
          R_last_name: 
          {
            required: true
          },
          R_email: // making sur ethe format is in email eith @
          {
            required: true,
            email: true
          },
          R_phone: 
          {
            required: true,
            phone: true
          }
        },
        messages: 
        {
          // defining the messages for the above rules
          R_dob: 
          {
            required: 'This field is required',
            dateISO: 'Please enter a valid date format YYYY-MM-DD.'
          },
          
          R_first_name: 
          {
            required: 'This field is required'
          },
          R_last_name: 
          {
            required: 'This field is required'
          },
          R_email: 
          {
            required: 'This field is requiredd',
            email: 'Please enter a valid email address with xyz@xyz.qwe.'
          },
          R_phone: 
          {
            required: 'This field is required',
            phone: 'Please enter a valid Phone Number xxx-xxx-xxxx'
          }
        }
      });
    }
    
    
  
    
    );
    