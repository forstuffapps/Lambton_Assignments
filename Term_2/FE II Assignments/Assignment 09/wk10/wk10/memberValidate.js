/* memberValidate.js */
$(document).ready(function() {
	$("#email").focus();
	
	// apply the validate plugin, rules only, no custom err messages
	$("#member_form").validate({
		rules: {
			email: {
				required: true,
				email: true
			},
			password: {
				required: true,
				minlength: 6
			},
			verify: {
				required: true,
				equalTo: "#password"
			},
			first_name: {
				required: true
			},
			last_name: {
				required: true
			},
			state: {
				required: true,
				rangelength: [2, 2]
			},
			zip: {
				required: true,
				rangelength: [5, 10]
			},
			phone: {
				required: true,
				phoneUS: true
			},
			start_date: {
				required: true,
				date: true
			},
			card_number: {
				required: true,
				creditcard: true
			}
		}
	}); // end validate
	
}); // end of ready




