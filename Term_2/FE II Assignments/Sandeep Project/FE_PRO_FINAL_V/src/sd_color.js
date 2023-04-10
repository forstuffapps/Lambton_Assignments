$(document).ready(function() {
    $(".sd_highlight").mouseenter(function() {
      $(this).css({
        backgroundColor: "#ffff00",
        color: "#fff"
      });
    }).mouseleave(function() {
      $(this).css({
        backgroundColor: "#eee",
        color: "#000"
      });
    });
  });