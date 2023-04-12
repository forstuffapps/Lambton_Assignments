$(document).ready(function(){
    $.getJSON("sd_team.json", function(data){
      $.each(data.teammembers, function(key, value) {
        $("#sd_team").append(
          '<div class="sd-team-member">' +
            '<div class="name">' + value.name + '</div>' +
            '<div class="title">' + value.title + '</div>' +
            '<div class="bio">' + value.bio + '</div>' +
          '</div>'
        );
      });
    });
  });