$(document).ready(function() {
  // When the mouse enters the heading area
  $(".ct").mouseenter(function() {
    // Change the background color to blue and text color to white
    $(this).css({
      backgroundColor: "#ff0000",
      color: "#fff"
    });
  }).mouseleave(function() {
    // When the mouse leaves the heading area, change the background color back to gray and text color back to black
    $(this).css({
      backgroundColor: "#eee",
      color: "#000"
    });
  });
});



