$(document).ready(function() {
// code moves focus to arrival date text box
$('#Todays_date').focus();
// validation form using jQuery 
  $('#reservation_form').validate({
// fields required to submit (mandatory) to fill
    rules: {
      Todays_date: {
        required: true,
        dateISO: true
      },
      
      firstname: {
        required: true
      },
	  lastname: {
        required: true
      },
      email: {
        required: true,
        email: true
      },
      phone: {
        required: true,
        number: true,
		minlength:10,
		maxlength:10
      },
	  subject:{
		  required: true
	  }
  },
// messages to be appeared if entered invalid or no data
    messages: {
      Todays_date: {
        required: 'This field is requied.',
        dateISO: 'Please enter a valid date in the format YYYY-MM-DD.'
      },
      
      firstname: {
        required: 'This field is requied.'
      },
	   lastname: {
        required: 'This field is requied.'
      },
      email: {
        required: 'This field is requied.',
        email: 'Please enter a valid email address.'
      },
      phone: {
        required: 'Please Specify a valid phone number.',
        phone: 'Please specify phone number with 10 digits.'
	  },
	 subject: {
required: 'This field is requied.',
	 }	 
		
	}
  });
});