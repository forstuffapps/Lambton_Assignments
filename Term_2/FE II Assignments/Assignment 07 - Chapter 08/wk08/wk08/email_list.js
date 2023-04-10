/* email_list.js */
$(document).ready(function() {
	$("#join_list").click(function(){
		var emailAddress1 = $("#email_address1").val();
		var emailAddress2 = $("#email_address2").val();
		var isValid = true;
		
		// validate the 1st email address
		if (emailAddress1 == ""){
			$("#email_address1").next().text("This field is required");
			isValid = false;
		} else {
			$("#email_address1").next().text("");
		}
		
		// validate the 2nd email address
		if (emailAddress2 == ""){
			$("#email_address2").next().text("This field is required");
			isValid = false;
		} else if (emailAddress1 != emailAddress2) {
			$("#email_address2").next().text("This entry must equal 1st entry");
			isValid = false;
		} else {
			$("#email_address2").next().text("");
		}
		
		// validate the first name
		if ($("#first_name").val() == "") {
			$("#first_name").next().text("This field is required");
			isValid = false;
		} else {
			$("#first_name").next().text("");
		}
		
		// submit the for is all entries are validate
		if(isValid) {
			$("#email_form").submit();
		}
				
	});
});