$(document).ready(function() {
    $(".sd_heading").mouseenter(function() {
      $(this).css({
        backgroundColor: "#0A2239",
        color: "#fff"
      });
    }).mouseleave(function() {
      $(this).css({
        backgroundColor: "#eee",
        color: "#000"
      });
    });
  });