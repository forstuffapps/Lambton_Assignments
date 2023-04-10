$(document).ready(function() {
        $('form').submit(function(event) {
          // prevent the form from submitting
          event.preventDefault();
      
          // validate the form
          if(validateForm()) {
            // if the form is valid, submit it
            $(this).unbind('submit').submit();
          }
        });
      });
      
      function validateForm() {
        var isValid = true;
      
        // check if the first name field is empty
        if($('input[type="text"]:eq(0)').val() === '') {
          $('input[type="text"]:eq(0)').addClass('error');
          isValid = false;
        } else {
          $('input[type="text"]:eq(0)').removeClass('error');
        }
      
        // check if the last name field is empty
        if($('input[type="text"]:eq(1)').val() === '') {
          $('input[type="text"]:eq(1)').addClass('error');
          isValid = false;
        } else {
          $('input[type="text"]:eq(1)').removeClass('error');
        }
      
        // check if the email field is empty or has an invalid format
        var emailPattern = /^[^\s@]+@[^\s@]+\.[^\s@]+$/;
        if($('input[type="email"]').val() === '' || !emailPattern.test($('input[type="email"]').val())) {
          $('input[type="email"]').addClass('error');
          isValid = false;
        } else {
          $('input[type="email"]').removeClass('error');
        }
      
        // check if the phone field is empty or has an invalid format
        var phonePattern = /^\d{10}$/;
        if($('input[type="number"]').val() === '' || !phonePattern.test($('input[type="number"]').val())) {
          $('input[type="number"]').addClass('error');
          isValid = false;
        } else {
          $('input[type="number"]').removeClass('error');
        }
      
        // check if a gender option is selected
        if(!$('input[name="gender"]').is(':checked')) {
          $('.options-container').addClass('error');
          isValid = false;
        } else {
          $('.options-container').removeClass('error');
        }
      
        // check if at least one notification option is selected
        if(!$('input[name="gender"]:checked').length) {
          $('.col-options').addClass('error');
          isValid = false;
        } else {
          $('.col-options').removeClass('error');
        }
      
        // check if a referral source is selected
        if($('#reference').val() === 'ad') {
          $('#reference').addClass('error');
          isValid = false;
        } else {
          $('#reference').removeClass('error');
        }
      
        return isValid;
      }
      