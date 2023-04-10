$(document).ready(function(){
    $.getJSON("employees.json", function(data){
      $.each(data.employees, function(key, value) {
        $("#vj_team").append(
          '<div class="vj-team-member">' +
            '<div class="name">' + value.name + '</div>' +
            '<div class="title">' + value.title + '</div>' +
            '<div class="bio">' + value.bio + '</div>' +
          '</div>'
        );
      });
    });
  });