$(document).ready(function() {
    $(".ad_color_trans").mouseenter(function() {
      $(this).css({
        backgroundColor: "#fa0909",
        color: "#fff"
      });
    }).mouseleave(function() {
      $(this).css({
        backgroundColor: "#eee",
        color: "#000"
      });
    });
  });