/* rollover.js */
"use strict";

$(document).ready(function() {
	$("#image_rollovers img").each(function() {
		var oldURL = $(this).attr("src");
		var newURL = $(this).attr("id");
		
		//preload the rollover images
		var rolloverImage = new Image();
		rolloverImage.src = newURL;
		
		// set up event handlers
		$(this).hover(
			function(){
				$(this).attr("src", newURL);
			},
			function(){
				$(this).attr("src", oldURL);
			}
		);
	});
});