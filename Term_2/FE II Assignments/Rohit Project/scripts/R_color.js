$(document).ready(function() {
    $(".R_color").mouseenter(function() {
      $(this).css({
        backgroundColor: "#5204ee",
        color: "#fff"
      });
    }).mouseleave(function() {
      $(this).css({
        backgroundColor: "#eee",
        color: "#000"
      });
    });
  });