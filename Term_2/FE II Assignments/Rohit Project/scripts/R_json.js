$(document).ready(function(){
    $.getJSON("../scripts/R_team.json", function(data){
      $.each(data.R_teammembers, function(key, value) {
        $("#R_team").append(
          '<div class="R-team-member">' +
            '<div class="name">' + value.name + '</div>' +
            '<div class="title">' + value.title + '</div>' +
            '<div class="bio">' + value.bio + '</div>' +
          '</div>'
        );
      });
    });
  });