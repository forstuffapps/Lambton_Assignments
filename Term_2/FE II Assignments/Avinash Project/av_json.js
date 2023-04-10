$(document).ready(function(){
    $.getJSON("AV_team.json", function(data){
      $.each(data.employees, function(key, value) {
        $("#av_team").append(
          '<div class="av-team-member">' +
            '<div class="name">' + value.name + '</div>' +
            '<div class="title">' + value.title + '</div>' +
            '<div class="bio">' + value.department + '</div>' +
            '<div class="bio">' + value.bio + '</div>' +
          '</div>'
        );
      });
    });
  });