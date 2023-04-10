// This code sets up a search function that retrieves photos from Flickr based on tags
$(document).ready(function() {
  var searchQuery;
  $("#btnSearch").click(function() {
    searchQuery = "";
    // Check if search field is empty
    if ($("#search").val() == "") {
      alert("You must enter one or more tags!");
    } else {
      // Set the search query to the input value
      searchQuery = $("#search").val();
      // Construct the Flickr API URL with the search query
      var url = "http://api.flickr.com/services/feeds/" +
        "photos_public.gne?format=json&jsoncallback=?" +
        "&tags=" + searchQuery + "&tagmode=all";
      // Use jQuery's getJSON function to retrieve data from the URL
      $.getJSON(url, function(data) {
        // Initialize an empty string to hold the HTML code for the photos
        var html = "";
        // Loop through each item in the data array and append HTML code to the html variable
        $.each(data.items, function(index, item) {
          html += "<h2>" + item.title + "</h2>";
          html += "<img src=" + item.media.m + ">";
          html += "<p><b>Tags: </b>" + item.tags + "</p>";
        });
        // Replace the contents of the "photos" div with the HTML code
        $("#photos").html(html);
      });
    }
  });
});
