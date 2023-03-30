 // the $ method
 var $ = function(id) {
	 return document.getElementById(id);
 };
 
 // the joinlist function
 var joinList = function() {
	 // declare variables and populate from the form
	 var emailAddress1 = $("email_address1").value;
	 var emailAddress2 = $("email_address2").value;
	 var firstName = $("first_name").value;
	 var errorMessage = "";
	 
	 // validate the entries
	 if (emailAddress1 == "") {
		 errorMessage = "First email entry is required";
		 $("email_address1").focus();
	 } else if (emailAddress2 == "") {
		 errorMessage = "Second email entry is required";
		 $("email_address2").focus();
	 } else if (emailAddress1 != emailAddress2) {
		 errorMessage = "Both email addresses must match";
		 $("email_address2").focus();
	 } else if (firstName == "") {
		 errorMessage = "First Name is Required";
		 $("first_name").focus();
	 }
	 	 
	 // show results
	 if(errorMessage == ""){
		 $("email_form").submit();
	 } else {
		 alert(errorMessage);
	 }
 };
 
 // window onload with listeners
 window.onload = function() {
	 $("join_list").onclick = joinList;
	 $("email_address1").focus();
 };